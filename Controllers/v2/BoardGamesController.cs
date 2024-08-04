using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using MyBGList.Dto.v2;

namespace MyBGList.Controllers.v2;

[ApiController]
[ApiVersion(2.0)]
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
                Year = 1981,
                Players = 3
            },
            new BoardGame() {
                Id = 2,
                Name = "Citadels",
                Year = 2000,
                Players = 1

            },
            new BoardGame() {
                Id = 3,
 
                Name = "Terraforming Mars",
                Year = 2016,
                Players = 6
            }
        };
    }
}
