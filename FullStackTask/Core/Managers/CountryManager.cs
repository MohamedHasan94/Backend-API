using FullStackTask.Data;
using FullStackTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackTask.Core.Managers
{
    public class CountryManager: Repository<Country, ApplicationDbContext>
    {
        private readonly ApplicationDbContext _context;

        public CountryManager(ApplicationDbContext context): base(context)
        {
            _context = context;
        }

        public override Country GetById(params object[] id)
        {
            return _context.Countries.Include(c => c.Players)
                .FirstOrDefault(c => c.Id == (int)id[0]);
        }

        public override PaginatedList<Country> GetPaged(string sortOrder, string currentFilter, string searchString, int pageNumber = 1)
        {
            var countries = from item in _context.Countries.Include(c => c.Players)
                        select item;

            if (!String.IsNullOrEmpty(searchString))
            {
                countries = countries.Where(c => c.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "NameDsc":
                    countries = countries.OrderByDescending(c => c.Name);
                    break;

                case "PlayersAsc":
                    countries = countries.OrderBy(c => c.Players.Count);
                    break;

                case "PlayersDesc":
                    countries = countries.OrderByDescending(c => c.Players.Count);
                    break;

                default:
                    countries = countries.OrderBy(c => c.Name);
                    break;
            }
            int pageSize = 12;
            return PaginatedList<Country>.Create(countries.AsNoTracking(), pageNumber, pageSize);
        }
    }
}