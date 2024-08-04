using Microsoft.AspNetCore.Mvc;
using MyBGList.Models;

namespace MyBGList.Controllers;

[ApiController]
[Route("[controller]")]
public class BoardGamesController(ILogger<BoardGamesController> logger) : ControllerBase
{

    private readonly ILogger<BoardGamesController> _logger = logger;

    [HttpGet(Name = "GetBoarGames")]
    public IEnumerable<BoardGame> Get()
    {
        return new[] {
            new BoardGame() {
                Id = 1,
                Name = "Axis & Allies",
                Year = 1981
            },
            new BoardGame() {
                Id = 2,
                Name = "Citadels",
                Year = 2000
            },
            new BoardGame() {
                Id = 3,
 
                Name = "Terraforming Mars",
                Year = 2016
            }
        };
    }
}
