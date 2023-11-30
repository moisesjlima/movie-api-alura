using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class Address
    {
        [Key]
        [Required]
        public int AddressId { get; set; }

        public string PublicArea { get; set; } //Logradouro

        public int Number { get; set; }

        public MovieTheater MovieTheater { get; set; }
    }
}