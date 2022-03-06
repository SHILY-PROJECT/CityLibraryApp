﻿using System.Collections.Generic;
using WebApi.Enums;
using WebApi.Toolkit;
using WebApi.Models.Dto.Authors;
using WebApi.Models.Dto.Books;
using WebApi.Models.Entity;

namespace WebApi.Interfaces
{
    /// <summary>
    /// 3.1.1 - Интерфейс книги для реализации DI.
    /// </summary>
    public interface IBookRepository
    {
        /// <summary>
        /// Добавление новой книги.
        /// </summary>
        public ResultContent<Book> Add(NewBookDto newBook);

        /// <summary>
        /// Удаление книги по ID.
        /// </summary>
        public ResultContent<Book> Delete(int bookId);

        /// <summary>
        /// Обновление жанра книги.
        /// </summary>
        public ResultContent<BookDetailsDto> UpdateGenre(UpdateGenreOfBookDto bookUpdateGenre);

        /// <summary>
        /// Получение книг автора.
        /// </summary>
        public ResultContent<IEnumerable<BookDetailsDto>> GetListBooksByAuthor(AuthorDto authorSearch, BookSortingTypeEnum sortingType);

        /// <summary>
        /// Получение списка книг по жанру.
        /// </summary>
        public ResultContent<IEnumerable<BookDetailsDto>> GetListBooksByGenre(int genreId, BookSortingTypeEnum sortingType);
    }
}