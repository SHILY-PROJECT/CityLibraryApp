﻿namespace CityLibrary.WebApi.Models;

public record GenreStatsDto
{
    public GenreDto Genre { get; init; }
    public int Quantity { get; init; }
}