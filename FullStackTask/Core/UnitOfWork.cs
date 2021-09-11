using FullStackTask.Core.Managers;
using FullStackTask.Data;
using FullStackTask.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackTask.Core
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public UnitOfWork(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager
            , ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public UserManager<AppUser> UserManager { get { return _userManager; } }
        public RoleManager<IdentityRole> RoleManager { get { return _roleManager; } }


        private PlayerManager _playerManager;
        public PlayerManager PlayerManager
        {
            get
            {
                if(_playerManager == null)
                {
                    _playerManager = new PlayerManager(_context);
                }
                return _playerManager;
            }
        }

        private TeamManager _teamManager;
        public TeamManager TeamManager
        {
            get
            {
                if(_teamManager == null)
                {
                    _teamManager = new TeamManager(_context);
                }
                return _teamManager;
            }
        }

        private CountryManager _countryManager;
        public CountryManager CountryManager
        {
            get
            {
                if(_countryManager == null)
                {
                    _countryManager = new CountryManager(_context);
                }
                return _countryManager;
            }
        }
    }
}
