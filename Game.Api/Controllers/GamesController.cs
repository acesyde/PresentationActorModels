using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Game.GrainInterfaces.Game;
using Microsoft.AspNetCore.Mvc;
using Orleans;

namespace HomeAutomation.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/games")]
    public class GamesController : Controller
    {
        private readonly IClusterClient clusterClient;

        public GamesController(IClusterClient clusterClient)
        {
            this.clusterClient = clusterClient;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var gameManager = clusterClient.GetGrain<IGameManagerGrain>("gameManager");
            if (gameManager == null)
                return NotFound();

            return Ok(await gameManager.ListGames());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var game = clusterClient.GetGrain<IGameGrain>(id);
            if (game == null)
                return NotFound();

            return Ok(await game.ListPlayers());
        }

        [HttpGet]
        public async Task<IActionResult> Post()
        {
            var gameManager = clusterClient.GetGrain<IGameManagerGrain>("gameManager");
            if (gameManager == null)
                return NotFound();

            return Ok(await gameManager.CreateGame());
        }
    }
}
