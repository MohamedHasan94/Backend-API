﻿// <auto-generated />
using System;
using FullStackTask.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FullStackTask.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FullStackTask.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "d190655d-d688-47d2-a7cd-fd1cce564362",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a1cc9506-3d90-4860-92d0-7cc8ebb670fb",
                            Email = "admin@domain.com",
                            EmailConfirmed = false,
                            FirstName = "admin",
                            LastName = "admin",
                            LockoutEnabled = false,
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEPJXPt8g45SFt38v/QfcPiJNYF47BPXyqKr81Yv9+yrnVP6KBeX4HBr1FYZbfu98rQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "SecurityStamp",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = "8c857bc6-14ad-440c-9ee2-e92bcb6b76e7",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b9f58c46-bbc9-4ad7-bac8-c933eee17f52",
                            Email = "user@domain.com",
                            EmailConfirmed = false,
                            FirstName = "user",
                            LastName = "user",
                            LockoutEnabled = false,
                            NormalizedUserName = "USER",
                            PasswordHash = "AQAAAAEAACcQAAAAEEpMwIQjAW84aUSAijTtEU2+yvsiMZeEHlI5viOUL8nuGPFhaw3oiIEU1WKe2wiR5A==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "SecurityStamp",
                            TwoFactorEnabled = false,
                            UserName = "user"
                        });
                });

            modelBuilder.Entity("FullStackTask.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Egypt"
                        },
                        new
                        {
                            Id = 2,
                            Name = "England"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Germany"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Spain"
                        },
                        new
                        {
                            Id = 5,
                            Name = "France"
                        });
                });

            modelBuilder.Entity("FullStackTask.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Fk_nationalityId")
                        .HasColumnType("int");

                    b.Property<int>("Fk_teamId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Fk_nationalityId");

                    b.HasIndex("Fk_teamId");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "First1",
                            Fk_nationalityId = 1,
                            Fk_teamId = 1,
                            Image = "/images/PlayersImages/0b27c4af-4ade-46a6-a71a-bf63fe178b7f.jpg",
                            LastName = "Last1"
                        },
                        new
                        {
                            Id = 2,
                            DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "First2",
                            Fk_nationalityId = 2,
                            Fk_teamId = 2,
                            Image = "/images/PlayersImages/0d5308f6-4285-4fab-8e34-29fb47d2a4f1.jpg",
                            LastName = "Last2"
                        },
                        new
                        {
                            Id = 3,
                            DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "First3",
                            Fk_nationalityId = 3,
                            Fk_teamId = 3,
                            Image = "/images/PlayersImages/04badcd7-3a21-4217-a2aa-5a882475bcf5.jpg",
                            LastName = "Last3"
                        },
                        new
                        {
                            Id = 4,
                            DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "First4",
                            Fk_nationalityId = 4,
                            Fk_teamId = 3,
                            Image = "/images/PlayersImages/5afa1725-601e-450e-83c4-e2e3dce400f1.jpg",
                            LastName = "Last4"
                        },
                        new
                        {
                            Id = 5,
                            DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "First5",
                            Fk_nationalityId = 5,
                            Fk_teamId = 2,
                            Image = "/images/PlayersImages/6da642d0-2beb-4752-bbd8-2ffde259c4f7.jpg",
                            LastName = "Last5"
                        },
                        new
                        {
                            Id = 6,
                            DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "First6",
                            Fk_nationalityId = 1,
                            Fk_teamId = 1,
                            Image = "/images/PlayersImages/12cf612f-33a5-4260-84d8-108b0f118d49.jpg",
                            LastName = "Last6"
                        });
                });

            modelBuilder.Entity("FullStackTask.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CoachName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Fk_countryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FoundationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LogoImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Fk_countryId");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CoachName = "Coach1",
                            Fk_countryId = 1,
                            FoundationDate = new DateTime(1920, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LogoImage = "/images/TeamsImages/5132a27e-461b-4eb5-a396-1471a9b60cb5.png",
                            Name = "Team1"
                        },
                        new
                        {
                            Id = 2,
                            CoachName = "Coach2",
                            Fk_countryId = 3,
                            FoundationDate = new DateTime(1890, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LogoImage = "/images/TeamsImages/b2fe7f16-4e43-4cfe-a712-c3b99e99c3bd.png",
                            Name = "Team2"
                        },
                        new
                        {
                            Id = 3,
                            CoachName = "Coach3",
                            Fk_countryId = 4,
                            FoundationDate = new DateTime(1900, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LogoImage = "/images/TeamsImages/c27c1ac2-1011-4f62-a73b-99723a1631ef.png",
                            Name = "Team3"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserRole<string>");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("FullStackTask.Models.AppRole", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityRole");

                    b.HasDiscriminator().HasValue("AppRole");

                    b.HasData(
                        new
                        {
                            Id = "ebe69b58-b9fb-4921-9d90-a046a2ffd4fd",
                            ConcurrencyStamp = "e29139e9-ed97-41cc-8d2d-c8f1d7a0b7a1",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("FullStackTask.Models.UserRoleRel", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUserRole<string>");

                    b.Property<string>("RoleId1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId1")
                        .HasColumnType("nvarchar(450)");

                    b.HasIndex("RoleId1");

                    b.HasIndex("UserId1");

                    b.HasDiscriminator().HasValue("UserRoleRel");

                    b.HasData(
                        new
                        {
                            UserId = "d190655d-d688-47d2-a7cd-fd1cce564362",
                            RoleId = "ebe69b58-b9fb-4921-9d90-a046a2ffd4fd"
                        });
                });

            modelBuilder.Entity("FullStackTask.Models.Player", b =>
                {
                    b.HasOne("FullStackTask.Models.Country", "Nationality")
                        .WithMany("Players")
                        .HasForeignKey("Fk_nationalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FullStackTask.Models.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("Fk_teamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FullStackTask.Models.Team", b =>
                {
                    b.HasOne("FullStackTask.Models.Country", "Country")
                        .WithMany("Teams")
                        .HasForeignKey("Fk_countryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("FullStackTask.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FullStackTask.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FullStackTask.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FullStackTask.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FullStackTask.Models.UserRoleRel", b =>
                {
                    b.HasOne("FullStackTask.Models.AppRole", "Role")
                        .WithMany("UserRoleRels")
                        .HasForeignKey("RoleId1");

                    b.HasOne("FullStackTask.Models.AppUser", "User")
                        .WithMany("UserRoleRels")
                        .HasForeignKey("UserId1");
                });
#pragma warning restore 612, 618
        }
    }
}
