using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackTask.Models
{
    public class AppRole: IdentityRole
    {
        public virtual List<UserRoleRel> UserRoleRels { get; set; }
    }
}
