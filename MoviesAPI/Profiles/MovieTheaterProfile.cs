using AutoMapper;
using MoviesAPI.Data.Dtos;
using MoviesAPI.Models;

namespace MoviesAPI.Profiles;

public class MovieTheaterProfile : Profile
{
    public MovieTheaterProfile()
    {
        CreateMap<MovieTheater, ReadMovieTheaterDto>();
        CreateMap<CreateMovieTheaterDto, MovieTheater>().ReverseMap();
        CreateMap<UpdateMovieTheaterDto, MovieTheater>().ReverseMap();
    }
}