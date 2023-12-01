using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class Session
    {
        [Key]
        [Required]
        public int SessionId { get; set; }
    }
}