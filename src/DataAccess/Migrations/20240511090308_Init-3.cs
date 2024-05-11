using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("c39aa1ac-8ded-46be-870c-115b200b09fc"), null, "user", null },
                    { new Guid("c8500b46-b134-4b60-85b7-8e6af1187e0c"), null, "admin", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("2ed6fb47-86a6-46e3-a9dc-ff5b3d986c2f"), 0, "851ad700-3392-4058-9d61-4c3e82dee142", "nvdatdz8b@gmail.com", false, false, null, null, null, null, null, false, null, false, "admin" });

            migrationBuilder.InsertData(
                table: "RoleDetails",
                columns: new[] { "RoleId", "CreatedAt", "CreatedBy", "RemovedAt", "RemovedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("c39aa1ac-8ded-46be-870c-115b200b09fc"), new DateTime(2024, 5, 11, 9, 3, 8, 606, DateTimeKind.Utc).AddTicks(5734), new Guid("2ed6fb47-86a6-46e3-a9dc-ff5b3d986c2f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c8500b46-b134-4b60-85b7-8e6af1187e1c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c8500b46-b134-4b60-85b7-8e6af1187e1c") });

            migrationBuilder.InsertData(
                table: "UserDetails",
                columns: new[] { "UserId", "AvatarUrl", "CreatedAt", "CreatedBy", "FirstName", "LastName", "RemovedAt", "RemovedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("2ed6fb47-86a6-46e3-a9dc-ff5b3d986c2f"), "url.com/img", new DateTime(2024, 5, 11, 9, 3, 8, 606, DateTimeKind.Utc).AddTicks(5878), new Guid("2ed6fb47-86a6-46e3-a9dc-ff5b3d986c2f"), "Nguyen", "Dat", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c8500b46-b134-4b60-85b7-8e6af1187e1c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c8500b46-b134-4b60-85b7-8e6af1187e1c") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleDetails",
                keyColumn: "RoleId",
                keyValue: new Guid("c39aa1ac-8ded-46be-870c-115b200b09fc"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c8500b46-b134-4b60-85b7-8e6af1187e0c"));

            migrationBuilder.DeleteData(
                table: "UserDetails",
                keyColumn: "UserId",
                keyValue: new Guid("2ed6fb47-86a6-46e3-a9dc-ff5b3d986c2f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c39aa1ac-8ded-46be-870c-115b200b09fc"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2ed6fb47-86a6-46e3-a9dc-ff5b3d986c2f"));
        }
    }
}
