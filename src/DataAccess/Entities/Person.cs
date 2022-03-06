﻿namespace DataAccess.Entities;

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public DateTime BirthDate { get; set; }

    public IEnumerable<LibraryCard> LibraryCard { get; set; }
}