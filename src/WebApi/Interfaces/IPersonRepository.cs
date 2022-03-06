﻿using System.Collections.Generic;
using WebApi.WebApi.Toolkit;
using WebApi.WebApi.Models.Dto;
using WebApi.WebApi.Models.Dto.Persons;
using WebApi.WebApi.Models.Entity;

namespace WebApi.WebApi.Interfaces
{
    /// <summary>
    /// 3.1.1 - Интерфейс пользователя для реализации DI.
    /// </summary>
    public interface IPersonRepository
    {
        /// <summary>
        /// Добавление нового пользователя.
        /// </summary>
        public ResultContent<Person> Add(PersonDto person);

        /// <summary>
        /// Обновление информации о пользователе.
        /// </summary>
        public ResultContent<Person> Update(UpdatePersonDto updatePerson);

        /// <summary>
        /// Удаление пользователя по ID.
        /// </summary>
        public ResultContent<Person> Delete(int personId);

        /// <summary>
        /// Удаление пользователя по ФИО.
        /// </summary>
        public ResultContent<IEnumerable<Person>> Delete(PersonDto persone);

        /// <summary>
        /// Получение книг пользователя.
        /// </summary>
        public ResultContent<IEnumerable<Book>> GetPersonBooks(int personId);

        /// <summary>
        /// Получение книги пользователем на руки.
        /// </summary>
        public ResultContent<LibraryCard> TakeBook(PersonBookDto personBook);

        /// <summary>
        /// Возврат книги пользователем с рук.
        /// </summary>
        public ResultContent<LibraryCard> ReturnBook(PersonBookDto personBook);
    }
}