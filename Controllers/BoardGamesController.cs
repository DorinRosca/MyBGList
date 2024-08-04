using Microsoft.AspNetCore.Mvc;
using MyBGList.DTO;

namespace MyBGList.Controllers;

[ApiController]
[Route("[controller]")]
public class BoardGamesController(ILogger<BoardGamesController> logger) : ControllerBase
{
    private readonly ILogger<BoardGamesController> _logger = logger;

    [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 60)]
    [HttpGet(Name = "GetBoarGames")]
    public RestDto<BoardGame[]> Get()
    {
        return new RestDto<BoardGame[]>
        {
            Data =
            [
                new BoardGame
                {
                    Id = 1,
                    Name = "Axis & Allies",
                    Year = 1981
                },
                new BoardGame()
                {
                    Id = 2,
                    Name = "Citadels",
                    Year = 2000
                },
                new BoardGame()
                {
                    Id = 3,

                    Name = "Terraforming Mars",
                    Year = 2016
                }
            ],
            Links =
            [
                new LinkDto(Url.Action(null, "BoardGames", Request.Scheme)!,
                    "self",
                    "GET"
                )
            ]
        };
    }
}