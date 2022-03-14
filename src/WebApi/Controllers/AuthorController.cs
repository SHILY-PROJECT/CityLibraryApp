﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Domain.Models;
using Domain.Interfaces.Services;
using WebApi.Models;

namespace WebApi.WebApi.Controllers;

[ApiController]
[Route("/api/author")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _service;
    private readonly IMapper _mapper;

    public AuthorController(IAuthorService authorService, IMapper mapper)
    {
        _service = authorService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<AuthorDto>>> GetAuthors()
    {
        var authors = await _service.GetAllAsync();
        var authorsResult = _mapper.Map<IReadOnlyCollection<AuthorDto>>(authors);
        return Ok(authorsResult);
    }

    [HttpGet("{authorId}/books")]
    public async Task<ActionResult<IReadOnlyCollection<AuthorDto>>> GetBooksByAuthor([FromRoute] Guid authorId)
    {
        var books = await _service.GetBooksByAuthorAsync(authorId);
        var booksResult = _mapper.Map<IReadOnlyCollection<AuthorDto>>(books);
        return Ok(booksResult);
    }

    [HttpPost]
    public async Task<ActionResult<AuthorDto>> AddAuthor([FromBody] AuthorDto authorDto)
    {
        var author = _mapper.Map<Author>(authorDto);
        var authorResult = await _service.NewAsync(author);
        return _mapper.Map<AuthorDto>(authorResult);
    }

    [HttpPost]
    public async Task<ActionResult> AddAuthor([FromBody] (AuthorDto authorDto, IEnumerable<BookDto> booksDto) authorWithBooksDto)
    {
        var author = _mapper.Map<Author>(authorWithBooksDto.authorDto);
        var books = _mapper.Map<IEnumerable<Book>>(authorWithBooksDto.booksDto);
        var authorWithBooks = await _service.NewAsync(author, books);
        var authorWithBooksResult = _mapper.Map<(AuthorDto authorDto, IEnumerable<BookDto> booksDto)>(authorWithBooks);
        return Ok(authorWithBooksResult);
    }

    [HttpDelete]
    public async Task<ActionResult<bool>> DeleteAuthor([FromQuery] Guid authorId)
    {
        return await _service.DeleteAsync(authorId);
    }
}