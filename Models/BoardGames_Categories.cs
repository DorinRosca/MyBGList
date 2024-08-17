using System.ComponentModel.DataAnnotations;

namespace MyBGList.Models;

public record BoardGames_Categories
{
    [Key]
    [Required]
    public int BoardGameId { get; set; }

    [Key]
    [Required]
    public int CategoryId { get; set; }

    [Required]
    public DateTime CreatedDate { get; set; }
    
    public BoardGame? BoardGame { get; set; }
    public Categories? Domain { get; set; }
}