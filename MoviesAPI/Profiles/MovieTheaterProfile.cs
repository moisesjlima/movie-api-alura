using AutoMapper;
using MoviesAPI.Data.Dtos;
using MoviesAPI.Models;

namespace MoviesAPI.Profiles;

public class MovieTheaterProfile : Profile
{
    public MovieTheaterProfile()
    {
        CreateMap<MovieTheater, ReadMovieTheaterDto>()
            .ForMember(movieDto => movieDto.Address,
            opt => opt.MapFrom(movie => movie.Address))
            .ForMember(movieDto => movieDto.Sessions,
            opt => opt.MapFrom(movie => movie.Sessions));

        CreateMap<CreateMovieTheaterDto, MovieTheater>().ReverseMap();
        CreateMap<UpdateMovieTheaterDto, MovieTheater>().ReverseMap();
    }
}