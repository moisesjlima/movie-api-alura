using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;

namespace MoviesAPI.Data;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> opts) : base(opts)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Session>()
            .HasKey(
            session => new
            {
                session.MovieId,
                session.MovieTheaterId
            });

        modelBuilder.Entity<Session>()
            .HasOne(session => session.Movie)
            .WithMany(movie => movie.Session)
            .HasForeignKey(session => session.MovieId);

        modelBuilder.Entity<Session>()
            .HasOne(session => session.MovieTheater)
            .WithMany(movieTheater => movieTheater.Sessions)
            .HasForeignKey(session => session.MovieTheaterId);

        modelBuilder.Entity<Address>()
            .HasOne(address => address.MovieTheater)
            .WithOne(movieTheater => movieTheater.Address)
            .OnDelete(DeleteBehavior.Restrict);
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<MovieTheater> MovieTheaters { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Session> Sessions { get; set; }
}