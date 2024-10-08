using System.ComponentModel.DataAnnotations;

namespace MyBGList.Models;

public record Categories
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string Name { get; set; }
    
    [Required]
    public DateTime CreatedDate { get; set; }

    [Required]
    public DateTime LastModifiedDate { get; set; }
    
    public ICollection<BoardGames_Categories>? BoardGames_Categories { get; set; }
}