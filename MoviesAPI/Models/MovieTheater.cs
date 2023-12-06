using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models;

public class MovieTheater
{
    [Key]
    [Required]
    public int MovieTheaterId { get; set; }

    [Required(ErrorMessage = "name field is required!")]
    public string Name { get; set; }

    public int AddressId { get; set; }

    public virtual Address Address { get; set; }

    public virtual ICollection<Session> Sessions { get; set; }

}