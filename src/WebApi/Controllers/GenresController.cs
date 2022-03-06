﻿using Microsoft.AspNetCore.Mvc;
using WebApi.WebApi.Interfaces;
using WebApi.WebApi.Models.Dto.Genres;

namespace WebApi.WebApi.Controllers
{
    /// <summary>
    /// 2.7 - Контроллер жанра книг
    /// </summary>
    [ApiController]
    [Route("Genres")]
    public class GenresController : ControllerBase
    {
        private readonly IGenreRepository _iGenreRepository;

        public GenresController(IGenreRepository iGenreRepository)
        {
            _iGenreRepository = iGenreRepository;
        }

        /// <summary>
        /// 2.7.4.1 - Получение списка всех жанров
        /// </summary>
        /// <returns></returns>
        [HttpGet("ListAllGenre")]
        public IActionResult GetListGenres()
        {
            var result = _iGenreRepository.GetListGenres();

            if (result.IsSuccess is false)
                return BadRequest(result.Message);

            return Ok(result.Content);
        }

        /// <summary>
        /// 2.7.4.3 - Получение статистики жанров (жанр - количество книг)
        /// </summary>
        [HttpGet("NumberOfBooksByGenre")]
        public IActionResult GetStatisticsByGenres()
        {
            var result = _iGenreRepository.GetStatisticsByGenres();

            if (result.IsSuccess is false)
                return BadRequest(result.Message);

            return Ok(result.Content);
        }

        /// <summary>
        /// 2.7.4.2 - Добавление нового жанра
        /// </summary>
        [HttpPost("AddNewGenre")]
        public IActionResult AddGenre([FromQuery] AddGenre genreName)
        {
            var result = _iGenreRepository.Add(genreName);

            if (result.IsSuccess is false)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

    }
}