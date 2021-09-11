using Microsoft.EntityFrameworkCore.Migrations;

namespace FullStackTask.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
