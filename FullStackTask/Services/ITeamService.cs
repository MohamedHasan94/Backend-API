using FullStackTask.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackTask.Services
{
    public interface ITeamService
    {
        List<Team> GetTeams();

        Team GetTeam(int id);

        Team AddTeam(Team newTeam, List<Player> players, IFormFile teamImage, List<IFormFile> playersImages);

        Team UpdateTeam(Team newTeam, List<Player> players, IFormFile teamImage, List<IFormFile> playersImages);

        bool DeleteTeam(int id);
    }
}