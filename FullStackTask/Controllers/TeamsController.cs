using FullStackTask.Models;
using FullStackTask.Models.ViewModels;
using FullStackTask.Services;
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
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }


        /// <summary>
        /// Returns a list of teams
        /// </summary>
        /// <returns>List of teams</returns>
        /// GET: /api/teams
        [HttpGet]
        public List<Team> GetTeams()
        {
            return _teamService.GetTeams();
        }


        /// <summary>
        /// Returns a team by its id
        /// </summary>
        /// <param name="id">The team id</param>
        /// <returns>Team</returns>
        /// GET: /api/teams/{id}
        [HttpGet("{id}")]
        public Team GetTeam([FromRoute]int id)
        {
            return _teamService.GetTeam(id);
        }


        /// <summary>
        /// Gets a team logo image by providing its name
        /// </summary>
        /// <param name="imageName"></param>
        /// <returns>memory stream</returns>
        /// GET: /api/teams/getImage/{imageName}
        [HttpGet("GetImage/{imageName}")]
        public IActionResult GetImage(string imageName)
        {
            try
            {
                var image = System.IO.File.OpenRead($"./wwwroot/images/TeamsImages/{imageName}");
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
        /// Adds a new team with its players
        /// </summary>
        /// <param name="model">consists of a team object "Team", list of players "Players", team Logo image "TeamImage" and list of players images "PlayersImages"  </param>
        /// <returns>The created team</returns>
        /// POST: /api/teams
        [Authorize(Roles ="Admin")]
        [HttpPost()]
        public IActionResult AddTeam([FromForm] TeamWithPlayers model)
        {
            try
            {
                Team team = JsonConvert.DeserializeObject<Team>(model.Team, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                List<Player> players = JsonConvert.DeserializeObject<List<Player>>(model.Players, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                Team crearedTeam = _teamService.AddTeam(team, players, model.TeamImage, model.PlayersImages);
                if (crearedTeam == null) return BadRequest("Add new team failed.");

                return CreatedAtAction("GetTeam", new { id = crearedTeam.Id }, crearedTeam);
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong. Please try again.");
            }
        }

        /// <summary>
        /// Updates a team data with its players
        /// </summary>
        /// <param name="model">consists of a team object "Team", list of players "Players", team Logo image "TeamImage" and list of players images "PlayersImages"  </param>
        /// <returns>the updated team</returns>
        /// PUT: /api/teams
        [Authorize(Roles ="Admin")]
        [HttpPut]
        public IActionResult UpdateTeam([FromForm] TeamWithPlayers model)
        {
            try
            {
                Team team = JsonConvert.DeserializeObject<Team>(model.Team, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                List<Player> players = JsonConvert.DeserializeObject<List<Player>>(model.Players, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                Team updatedTeam = _teamService.UpdateTeam(team, players, model.TeamImage, model.PlayersImages);
                if (updatedTeam == null) return BadRequest("Updating team data failed.");

                return CreatedAtAction("GetTeam", new { id = updatedTeam.Id }, updatedTeam);
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong. Please try again.");
            }
        }


        /// <summary>
        /// Deletes team with its player by tteam id
        /// </summary>
        /// <param name="id">the id of the team to be deleted</param>
        /// <returns>true if deleting succeeded and false if not</returns>
        /// DELETE: /api/teams/{id}
        [Authorize(Roles ="Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteTeam([FromRoute] int id)
        {
            if (_teamService.DeleteTeam(id))
                return Ok("Team deleted successfully.");

            return BadRequest("Team couldn't be deleted. Please try again.");
        }
    }
}