using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FullStackTask.Migrations
{
    public partial class seedData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "d41c0843-ab0e-47c2-bcdc-d41b1e81c8f4", "16e273bb-db22-413c-955c-334a2caba05a" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9f92f133-4317-42ac-b145-0f9c807a000e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16e273bb-db22-413c-955c-334a2caba05a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d41c0843-ab0e-47c2-bcdc-d41b1e81c8f4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "ebe69b58-b9fb-4921-9d90-a046a2ffd4fd", "e29139e9-ed97-41cc-8d2d-c8f1d7a0b7a1", "AppRole", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "d190655d-d688-47d2-a7cd-fd1cce564362", 0, "a1cc9506-3d90-4860-92d0-7cc8ebb670fb", "admin@domain.com", false, "admin", "admin", false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEPJXPt8g45SFt38v/QfcPiJNYF47BPXyqKr81Yv9+yrnVP6KBeX4HBr1FYZbfu98rQ==", null, false, "SecurityStamp", false, "admin" },
                    { "8c857bc6-14ad-440c-9ee2-e92bcb6b76e7", 0, "b9f58c46-bbc9-4ad7-bac8-c933eee17f52", "user@domain.com", false, "user", "user", false, null, null, "USER", "AQAAAAEAACcQAAAAEEpMwIQjAW84aUSAijTtEU2+yvsiMZeEHlI5viOUL8nuGPFhaw3oiIEU1WKe2wiR5A==", null, false, "SecurityStamp", false, "user" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Egypt" },
                    { 2, "England" },
                    { 3, "Germany" },
                    { 4, "Spain" },
                    { 5, "France" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId", "Discriminator", "RoleId1", "UserId1" },
                values: new object[] { "d190655d-d688-47d2-a7cd-fd1cce564362", "ebe69b58-b9fb-4921-9d90-a046a2ffd4fd", "UserRoleRel", null, null });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CoachName", "Fk_countryId", "FoundationDate", "LogoImage", "Name" },
                values: new object[,]
                {
                    { 1, "Coach1", 1, new DateTime(1920, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/TeamsImages/5132a27e-461b-4eb5-a396-1471a9b60cb5.png", "Team1" },
                    { 2, "Coach2", 3, new DateTime(1890, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/TeamsImages/b2fe7f16-4e43-4cfe-a712-c3b99e99c3bd.png", "Team2" },
                    { 3, "Coach3", 4, new DateTime(1900, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/TeamsImages/c27c1ac2-1011-4f62-a73b-99723a1631ef.png", "Team3" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "Fk_nationalityId", "Fk_teamId", "Image", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "First1", 1, 1, "/images/PlayersImages/0b27c4af-4ade-46a6-a71a-bf63fe178b7f.jpg", "Last1" },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "First6", 1, 1, "/images/PlayersImages/12cf612f-33a5-4260-84d8-108b0f118d49.jpg", "Last6" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "First2", 2, 2, "/images/PlayersImages/0d5308f6-4285-4fab-8e34-29fb47d2a4f1.jpg", "Last2" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "First5", 5, 2, "/images/PlayersImages/6da642d0-2beb-4752-bbd8-2ffde259c4f7.jpg", "Last5" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "First3", 3, 3, "/images/PlayersImages/04badcd7-3a21-4217-a2aa-5a882475bcf5.jpg", "Last3" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "First4", 4, 3, "/images/PlayersImages/5afa1725-601e-450e-83c4-e2e3dce400f1.jpg", "Last4" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "d190655d-d688-47d2-a7cd-fd1cce564362", "ebe69b58-b9fb-4921-9d90-a046a2ffd4fd" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8c857bc6-14ad-440c-9ee2-e92bcb6b76e7");

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebe69b58-b9fb-4921-9d90-a046a2ffd4fd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d190655d-d688-47d2-a7cd-fd1cce564362");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "16e273bb-db22-413c-955c-334a2caba05a", "39444236-34fd-4c09-b32f-9bc8f687f49a", "AppRole", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d41c0843-ab0e-47c2-bcdc-d41b1e81c8f4", 0, "b0a690cf-15dd-4fdc-993b-f15366d08f46", "admin@domain.com", false, "admin", "admin", false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEBVk9oW56XimHNz+bLyai8KOtuL80kszlk3XK7xrr5ck0SaZ6jHDteGFzVZt+5ZkwQ==", null, false, "SecurityStamp", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9f92f133-4317-42ac-b145-0f9c807a000e", 0, "53616318-396c-4dbf-adcb-5e4b92081e02", "user@domain.com", false, "user", "user", false, null, null, "USER", "AQAAAAEAACcQAAAAEEwwpRybLsRs4tf1m/QoH/amZpNFOiYSOKYQiU1fTW8iftsHjykGT+rbmuTGJoeHvA==", null, false, "SecurityStamp", false, "user" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId", "Discriminator", "RoleId1", "UserId1" },
                values: new object[] { "d41c0843-ab0e-47c2-bcdc-d41b1e81c8f4", "16e273bb-db22-413c-955c-334a2caba05a", "UserRoleRel", null, null });
        }
    }
}
