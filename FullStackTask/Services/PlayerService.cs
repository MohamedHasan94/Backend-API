using FullStackTask.Core;
using FullStackTask.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace FullStackTask.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlayerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public List<Player> GetPlayers() =>
            _unitOfWork.PlayerManager.GetAllBind();


        public Player GetPlayer(int id) => _unitOfWork.PlayerManager.GetById(id);

        public List<Player> GetPlayersByTeamId(int teamId)
        {
            return _unitOfWork.PlayerManager.GetPlayersByTeamId(teamId);
        }

        public Player AddPlayer(Player newPlayer, IFormFile image)
        {
            string imagePath = SaveImage(image);
            newPlayer.Image = imagePath;
            return _unitOfWork.PlayerManager.Add(newPlayer);

        }

        public string SaveImage(IFormFile image)
        {
            string name = $"{Guid.NewGuid().ToString()}.{Path.GetFileName(image.FileName).Split('.')[1]}";
            string path = $"/images/PlayersImages/{name}";
            using (var stream = System.IO.File.Create(@"./wwwroot" + path))
            {
                image.CopyTo(stream);
            }
            return name;
        }


        public Player UpdatePlayer(Player player, IFormFile image)
        {
            //Player player1 = _unitOfWork.PlayerManager.GetById(player.Id);
            Player player1 = _unitOfWork.PlayerManager.GetAll().AsNoTracking().FirstOrDefault(p => p.Id == player.Id);
            if (player1 == null) return null;

            DeleteImage(player1.Image);
            player.Image = SaveImage(image);
            return _unitOfWork.PlayerManager.Update(player);
        }

        private bool DeleteImage(string imagePath)
        {
            try
            {
                string fullPath = $"./wwwroot/images/PlayersImages/{imagePath}";
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


        public bool DeletePlayer(int id)
        {
            Player player = _unitOfWork.PlayerManager.GetById(id);
            if (player == null) return false;
            DeleteImage(player.Image);
            return _unitOfWork.PlayerManager.Remove(player);
        }

        public bool DeletePlayers(List<Player> players)
        {
            List<string> imagesPaths = new List<string>();
            foreach (var player in players)
            {
                imagesPaths.Add(player.Image);
            }
            if (!_unitOfWork.PlayerManager.RemoveRange(players))
                return false;
            foreach (var path in imagesPaths)
            {
                DeleteImage(path);
            }
            return true;
        }
    }
}
