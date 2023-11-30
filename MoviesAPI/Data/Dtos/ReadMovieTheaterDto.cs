namespace MoviesAPI.Data.Dtos
{
    public class ReadMovieTheaterDto
    {
        public int MovieTheaterId { get; set; }

        public string Name { get; set; }

        public ReadAddressDto Address { get; set; }
    }
}