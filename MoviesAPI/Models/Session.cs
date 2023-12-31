﻿namespace MoviesAPI.Models;

public class Session
{
    //[Key]
    //[Required]
    //public int SessionId { get; set; }

    public int? MovieId { get; set; }

    public virtual Movie Movie { get; set; }

    public int? MovieTheaterId { get; set; }

    public virtual MovieTheater MovieTheater { get; set; }

}