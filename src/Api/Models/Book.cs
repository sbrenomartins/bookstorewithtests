using System.ComponentModel.DataAnnotations;

namespace Api;

public class Book
{
    public Guid Id { get; set; }
    [Required]
    public string? Title { get; set; }
    [Required]
    public string? Author { get; set; }
}
