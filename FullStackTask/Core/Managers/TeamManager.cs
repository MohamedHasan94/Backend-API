using FullStackTask.Data;
using FullStackTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackTask.Core.Managers
{
    public class TeamManager: Repository<Team, ApplicationDbContext>
    {
        private readonly ApplicationDbContext _context;
        public TeamManager(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public override Team GetById(params object[] id)
        {
            return _context.Teams.Include(t => t.Players)
                .FirstOrDefault(p => p.Id == (int)id[0]);
        }

        public override PaginatedList<Team> GetPaged(string sortOrder, string currentFilter, string searchString, int pageNumber = 1)
        {
            var teams = from item in _context.Teams.Include(t => t.Players)
                          select item;

            if (!String.IsNullOrEmpty(searchString))
            {
                teams = teams.Where(t => t.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Dsc":
                    teams = teams.OrderByDescending(t => t.Name);
                    break;

                default:
                    teams = teams.OrderBy(t => t.Name);
                    break;
            }
            int pageSize = 12;
            return PaginatedList<Team>.Create(teams.AsNoTracking(), pageNumber, pageSize);
        }
    }
}
