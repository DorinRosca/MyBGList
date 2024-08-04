using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using MyBGList.Dto.v1;

namespace MyBGList.Controllers.v1;

[ApiController]
[ApiVersion(1.0)]
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
