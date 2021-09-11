using FullStackTask.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackTask.Services
{
    public interface IPlayerService
    {
        List<Player> GetPlayers();

        List<Player> GetPlayersByTeamId(int teamId);
        Player GetPlayer(int id);

        Player AddPlayer(Player newPlayer, IFormFile image);

        Player UpdatePlayer(Player player, IFormFile image);

        bool DeletePlayer(int id);

        bool DeletePlayers(List<Player> players);
    }
}
