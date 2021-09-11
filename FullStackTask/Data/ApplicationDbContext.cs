using FullStackTask.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackTask.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            string adminId = Guid.NewGuid().ToString();
            string userId = Guid.NewGuid().ToString();
            string adminRoleId = Guid.NewGuid().ToString();

            //1- User Roles
            builder.Entity<AppRole>().HasData(new AppRole
            {
                Id = adminRoleId,
                Name = "Admin",
                NormalizedName = "ADMIN"
            });

            //2- Users
            var hasher = new PasswordHasher<AppUser>();
            builder.Entity<AppUser>().HasData(new List<AppUser> {
                new AppUser
                {
                    Id = adminId, // primary key
                    UserName = "admin",
                    FirstName = "admin",
                    LastName = "admin",
                    Email = "admin@domain.com",
                    NormalizedUserName = "ADMIN",
                    PasswordHash = hasher.HashPassword(null, "P@ssw0rd"),
                    SecurityStamp = "SecurityStamp"
                },
                new AppUser
                {
                    Id = userId, // primary key
                    UserName = "user",
                    FirstName = "user",
                    LastName = "user",
                    Email = "user@domain.com",
                    NormalizedUserName = "USER",
                    PasswordHash = hasher.HashPassword(null, "P@ssw0rd"),
                    SecurityStamp = "SecurityStamp"
                }
            }.ToArray());

            //3- Users Role Relation
            builder.Entity<UserRoleRel>().HasData(new UserRoleRel
            {
                RoleId = adminRoleId, // for admin username
                UserId = adminId  // for admin role
            });

            //4- Countries
            builder.Entity<Country>().HasData(new List<Country> {
                new Country
                {
                    Id = 1,
                    Name = "Egypt"
                },
                new Country
                {
                    Id = 2,
                    Name = "England"
                },
                new Country
                {
                    Id = 3,
                    Name = "Germany"
                },
                new Country
                {
                    Id = 4,
                    Name = "Spain"
                },
                new Country
                {
                    Id = 5,
                    Name = "France"
                }
            }.ToArray());

            //5- Teams
            builder.Entity<Team>().HasData(new List<Team> {
                new Team{
                    Id = 1,
                    Name = "Team1",
                    CoachName = "Coach1",
                    FoundationDate = new DateTime(1920, 01, 05),
                    Fk_countryId = 1,
                    LogoImage = "/images/TeamsImages/5132a27e-461b-4eb5-a396-1471a9b60cb5.png"
                },
                new Team{
                    Id = 2,
                    Name = "Team2",
                    CoachName = "Coach2",
                    FoundationDate = new DateTime(1890, 07, 23),
                    Fk_countryId = 3,
                    LogoImage = "/images/TeamsImages/b2fe7f16-4e43-4cfe-a712-c3b99e99c3bd.png"
                },
                new Team{
                    Id = 3,
                    Name = "Team3",
                    CoachName = "Coach3",
                    FoundationDate = new DateTime(1900, 12, 06),
                    Fk_countryId = 4,
                    LogoImage = "/images/TeamsImages/c27c1ac2-1011-4f62-a73b-99723a1631ef.png"
                }
            }.ToArray());

            //6- Players
            builder.Entity<Player>().HasData(new List<Player> {
                new Player{
                    Id = 1,
                    FirstName = "First1",
                    LastName = "Last1",
                    DateOfBirth = new DateTime(24/07/1994),
                    Fk_nationalityId = 1,
                    Fk_teamId = 1,
                    Image = "/images/PlayersImages/0b27c4af-4ade-46a6-a71a-bf63fe178b7f.jpg"
                },
                new Player{
                    Id = 2,
                    FirstName = "First2",
                    LastName = "Last2",
                    DateOfBirth = new DateTime(24/06/2000),
                    Fk_nationalityId = 2,
                    Fk_teamId = 2,
                    Image = "/images/PlayersImages/0d5308f6-4285-4fab-8e34-29fb47d2a4f1.jpg"
                },
                new Player{
                    Id = 3,
                    FirstName = "First3",
                    LastName = "Last3",
                    DateOfBirth = new DateTime(10/01/2002),
                    Fk_nationalityId = 3,
                    Fk_teamId = 3,
                    Image = "/images/PlayersImages/04badcd7-3a21-4217-a2aa-5a882475bcf5.jpg"
                },
                new Player{
                    Id = 4,
                    FirstName = "First4",
                    LastName = "Last4",
                    DateOfBirth = new DateTime(26/08/1998),
                    Fk_nationalityId = 4,
                    Fk_teamId = 3,
                    Image = "/images/PlayersImages/5afa1725-601e-450e-83c4-e2e3dce400f1.jpg"
                },
                new Player{
                    Id = 5,
                    FirstName = "First5",
                    LastName = "Last5",
                    DateOfBirth = new DateTime(26/08/1995),
                    Fk_nationalityId = 5,
                    Fk_teamId = 2,
                    Image = "/images/PlayersImages/6da642d0-2beb-4752-bbd8-2ffde259c4f7.jpg"
                },
                new Player{
                    Id = 6,
                    FirstName = "First6",
                    LastName = "Last6",
                    DateOfBirth = new DateTime(06/10/1997),
                    Fk_nationalityId = 1,
                    Fk_teamId = 1,
                    Image = "/images/PlayersImages/12cf612f-33a5-4260-84d8-108b0f118d49.jpg"
                }
            }.ToArray());
        }


        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Team> Teams { get; set; }

        public AppUser MyProperty { get; set; }
    }
}
