using Blackjack.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blackjack.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly GameService _gameService;

        public GameController(GameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost("start-new-game")]
        public IActionResult StartNewGame()
        {
            try
            {
                _gameService.StartNewGame();
                return Ok(_gameService.GetGame());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("bet")]
        public IActionResult PlaceBet([FromQuery] int amount)
        {
            if (_gameService.PlayerBalance() < amount)
            {
                return BadRequest("Insufficient balance");
            }

            _gameService.PlaceBet(amount);
            return Ok("Bet placed successfully");
        }

        [HttpPost("deal-cards")]
        public IActionResult DealCards()
        {
            _gameService.DealCards();
            return Ok(_gameService.GetGame());
        }
        [HttpPost("hit")]

        public IActionResult Hit()
        {
            _gameService.Hit();
            return Ok(_gameService.GetGame());
        }
        [HttpPost("stand")]
        public IActionResult Stand()
        {
            _gameService.Stand();
            return Ok("Player stands");
        }
        [HttpPost("check-winner")]
        public IActionResult CheckWinner()
        {
         return Ok(_gameService.CheckWinner());
        }
    }
}
