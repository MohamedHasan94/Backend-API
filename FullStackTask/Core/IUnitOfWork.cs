using FullStackTask.Core.Managers;
using FullStackTask.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackTask.Core
{
    public interface IUnitOfWork
    {
        UserManager<AppUser> UserManager { get; }
        RoleManager<IdentityRole> RoleManager { get; }

        PlayerManager PlayerManager { get; }

        TeamManager TeamManager { get; }

        CountryManager CountryManager { get; }
    }
}
