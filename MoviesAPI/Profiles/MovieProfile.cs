using AutoMapper;
using MoviesAPI.Data.Dtos;
using MoviesAPI.Models;

namespace MoviesAPI.Profiles;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<CreateMovieDto, Movie>().ReverseMap();
        CreateMap<UpdateMovieDto, Movie>().ReverseMap();
        CreateMap<ReadMovieDto, Movie>().ReverseMap();
    }
}