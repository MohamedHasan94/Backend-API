using FullStackTask.Core;
using FullStackTask.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackTask.Services
{
    public class TeamService : ITeamService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPlayerService _playerService;

        public TeamService(IUnitOfWork unitOfWork, IPlayerService playerService)
        {
            _unitOfWork = unitOfWork;
            _playerService = playerService;
        }

        public Team AddTeam(Team newTeam, List<Player> players, IFormFile teamImage ,List<IFormFile> playersImages)
        {
            for (int i = 0; i < playersImages.Count; i++)
            {
                players[i].Image = SaveImage(playersImages[i], "Player");
            }
            newTeam.LogoImage = SaveImage(teamImage, "Team");

            if(_unitOfWork.TeamManager.Add(newTeam) != null)
            {
                foreach (var player in players)
                {
                    player.Fk_teamId = newTeam.Id;
                }
                if (_unitOfWork.PlayerManager.AddRange(players) != null)
                    return newTeam;
            }
            return null;            
        }

        public bool DeleteTeam(int id)
        {
            Team team = _unitOfWork.TeamManager.GetById(id);
            if (team == null) return false;

            if (!_playerService.DeletePlayers(team.Players))
                return false;

            DeleteImage(team.LogoImage);
            if (!_unitOfWork.TeamManager.Remove(team))
                return false;

            return true;
        }

        public Team GetTeam(int id)
        {
            return _unitOfWork.TeamManager.GetById(id);
        }

        public List<Team> GetTeams()
        {
            return _unitOfWork.TeamManager.GetAllBind();
        }

        public Team UpdateTeam(Team team, List<Player> players, IFormFile teamImage, List<IFormFile> playersImages)
        {
            Team existingTeam = _unitOfWork.TeamManager.GetAll().AsNoTracking().FirstOrDefault(t => t.Id == team.Id);

            if (_unitOfWork.TeamManager.GetAll().AsNoTracking().FirstOrDefault(t => t.Id == team.Id) == null) return null;
            DeleteImage(existingTeam.LogoImage);
            team.LogoImage = SaveImage(teamImage, "Team");
            if(_unitOfWork.TeamManager.Update(team) != null)
            {
                for (int i = 0; i < playersImages.Count; i++)
                {
                    DeleteImage(players[i].Image);
                    players[i].Image = SaveImage(playersImages[i], "Player");
                }
                if (_unitOfWork.PlayerManager.UpdateRange(players) != null)
                    return team;
            }
            return null;
        }

        private string SaveImage(IFormFile image, string type)
        {
            if (image == null) return "";
            string name = $"{Guid.NewGuid().ToString()}.{Path.GetFileName(image.FileName).Split('.')[1]}";
            string path = $"/images/{type}sImages/{name}";
            using (var stream = System.IO.File.Create(@"./wwwroot" + path))
            {
                image.CopyTo(stream);
            }
            return name;
        }

        private bool DeleteImage(string imagePath)
        {
            try
            {
                string fullPath = $"./wwwroot/images/TeamsImages/{imagePath}";
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}