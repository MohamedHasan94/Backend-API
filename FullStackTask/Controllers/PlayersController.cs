using FullStackTask.Models;
using FullStackTask.Models.ViewModels;
using FullStackTask.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }
        

        /// <summary>
        /// Retrieves the data of all the players registered
        /// </summary>
        /// <returns>List of players</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_playerService.GetPlayers());
        }


        /// <summary>
        /// Gets A specific player by their Id and returns null if no player exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Player</returns>
        /// GET: /api/players/getById/{id}
        [HttpGet("GetById/{id}")]
        public IActionResult GetById([FromRoute]int id)
        {
            Player player = _playerService.GetPlayer(id);
            if (player == null) return NotFound();
            return Ok(player);
        }


        /// <summary>
        /// Gets a player image by providing its name
        /// </summary>
        /// <param name="imageName"></param>
        /// <returns>memory stream</returns>
        /// GET: /api/players/getImage/{imageName}
        [HttpGet("GetImage/{imageName}")]
        public IActionResult GetImage(string imageName)
        {
            try
            {
                var image = System.IO.File.OpenRead($"./wwwroot/images/PlayersImages/{imageName}");
                if (image == null) return NotFound("Couldn't find image at the specified path");
                System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
                image.CopyTo(memoryStream);
                return Ok(memoryStream.ToString());
            }
             catch (Exception)
            {
                return NotFound("Couldn't find image at the specified path");
            }
        }


        /// <summary>
        /// Gets players by team id and returns empty list if no players for that team
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns>List of players</returns>
        /// GET: /api/players/getByTeamId/{teamId}
        [HttpGet("GetByTeamId/{teamId}")]
        public IActionResult GetByTeamIdId([FromRoute] int teamId)
        {
            List<Player> players = _playerService.GetPlayersByTeamId(teamId);
            if (players.Count == 0)
                return NotFound("No players registered for that team");

            return Ok(players);
        }


        /// <summary>
        /// Adds a new player
        /// </summary>
        /// <param name="playerModel">A model consisting of Player object "Player" and an image "PlayerImage"</param>
        /// <returns>The player created</returns>
        /// POST: /api/players/
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public IActionResult AddPlayer([FromForm] PlayerModel playerModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                Player player = JsonConvert.DeserializeObject<Player>(playerModel.Player, new IsoDateTimeConverter { DateTimeFormat = "dd/mm/yyyy" });
                Player crearedPlayer = _playerService.AddPlayer(player, playerModel.Image);
                if (crearedPlayer == null) return BadRequest("Add new player failed.");

                return CreatedAtAction("GetById", new { id = crearedPlayer.Id }, crearedPlayer);
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong. Please try again.");
            }
        }


        /// <summary>
        /// Updates the data of an existing player
        /// </summary>
        /// <param name="playerModel">A model consisting of Player object "Player" and an image "PlayerImage"</param>
        /// <returns>The updated player</returns>
        /// PUT: /api/players/
        [HttpPut]
        [Authorize(Roles ="Admin")]
        public IActionResult UpdatePlayer([FromForm] PlayerModel playerModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                Player player = JsonConvert.DeserializeObject<Player>(playerModel.Player, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                Player updatedPlayer = _playerService.UpdatePlayer(player, playerModel.Image);

                if (updatedPlayer == null) return BadRequest("Updating  player failed.");

                return CreatedAtAction("GetById", new { id = updatedPlayer.Id }, updatedPlayer);
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong. Please try again.");
            }

        }


        /// <summary>
        /// Delete a player
        /// </summary>
        /// <param name="id">Player Id</param>
        /// <returns>true if deleting succeeded and false if not</returns>
        /// DELETE: /api/players
        [HttpDelete("{id}")]
        [Authorize(Roles ="Admin")]
        public IActionResult DeletePlayer([FromRoute]int id)
        {
            if (_playerService.DeletePlayer(id)) return Ok("Player deleted successfully.");

            return NotFound("Couldn't find the player");
        }
    }
}
