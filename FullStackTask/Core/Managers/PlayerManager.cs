using FullStackTask.Data;
using FullStackTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackTask.Core.Managers
{
    public class PlayerManager : Repository<Player, ApplicationDbContext>
    {
        private readonly ApplicationDbContext _context;
        public PlayerManager(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public override Player GetById(params object[] id)
        {
            return _context.Players.Include(p => p.Team)
                .Include(p => p.Nationality).FirstOrDefault(p => p.Id == (int)id[0]);
        }

        public override PaginatedList<Player> GetPaged(string sortOrder, string currentFilter, string searchString, int pageNumber = 1)
        {
            var players = from item in _context.Players.Include(p => p.Team)
                          .Include(p => p.Nationality)
                          select item;

            if (!String.IsNullOrEmpty(searchString))
            {
                players = players.Where(p => p.LastName.Contains(searchString) || p.FirstName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "FirstDsc":
                    players = players.OrderByDescending(p => p.FirstName);
                    break;

                case "LastAsc":
                    players = players.OrderBy(p => p.LastName);
                    break;

                case "LastDesc":
                    players = players.OrderByDescending(p => p.LastName);
                    break;

                default:
                    players = players.OrderBy(p => p.FirstName);
                    break;
            }
            int pageSize = 12;
            return PaginatedList<Player>.Create(players.AsNoTracking(), pageNumber, pageSize);
        }

        public override bool Remove(params object[] id)
        {
            Player player = _context.Players.Find(id);
            if (player == null) return false;
            _context.Players.Remove(player);
            return _context.SaveChanges() > 0;
        }

        public override bool RemoveRange(List<Player> players)
        {
            foreach (var player in players)
            {
                if (!_context.Players.Contains(player)) return false;
                _context.Players.Remove(player);
            }

            return _context.SaveChanges() > 0;
        }

        public List<Player> GetPlayersByTeamId(int teamId)
        {
            return _context.Players.Where(p => p.Fk_teamId == teamId).ToList();
        }
    }
}
