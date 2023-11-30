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

        public virtual MovieTheater MovieTheater { get; set; }
    }
}