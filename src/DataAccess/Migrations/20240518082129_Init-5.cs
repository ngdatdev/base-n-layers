using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Init5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RoleDetails",
                keyColumn: "RoleId",
                keyValue: new Guid("c39aa1ac-8ded-46be-870c-115b200b09fc"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 18, 8, 21, 28, 629, DateTimeKind.Utc).AddTicks(1926));

            migrationBuilder.UpdateData(
                table: "RoleDetails",
                keyColumn: "RoleId",
                keyValue: new Guid("c8500b46-b134-4b60-85b7-8e6af1187e0c"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 18, 8, 21, 28, 629, DateTimeKind.Utc).AddTicks(1932));

            migrationBuilder.UpdateData(
                table: "UserDetails",
                keyColumn: "UserId",
                keyValue: new Guid("2ed6fb47-86a6-46e3-a9dc-ff5b3d986c2f"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 18, 8, 21, 28, 629, DateTimeKind.Utc).AddTicks(2183));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2ed6fb47-86a6-46e3-a9dc-ff5b3d986c2f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f4e9b07d-4fe2-427d-82a5-ec70aed88734", "AQAAAAIAAYagAAAAEKEcpcHYWFbuaZZzGTt8mTdHyS0ZUFzughY365XZ6Viy7gxmEaB8q7qvchRthHMotA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RoleDetails",
                keyColumn: "RoleId",
                keyValue: new Guid("c39aa1ac-8ded-46be-870c-115b200b09fc"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 11, 9, 7, 53, 407, DateTimeKind.Utc).AddTicks(337));

            migrationBuilder.UpdateData(
                table: "RoleDetails",
                keyColumn: "RoleId",
                keyValue: new Guid("c8500b46-b134-4b60-85b7-8e6af1187e0c"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 11, 9, 7, 53, 407, DateTimeKind.Utc).AddTicks(342));

            migrationBuilder.UpdateData(
                table: "UserDetails",
                keyColumn: "UserId",
                keyValue: new Guid("2ed6fb47-86a6-46e3-a9dc-ff5b3d986c2f"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 11, 9, 7, 53, 407, DateTimeKind.Utc).AddTicks(494));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2ed6fb47-86a6-46e3-a9dc-ff5b3d986c2f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ddc028ae-5e84-4e04-9b2c-55a68b2926d3", null });
        }
    }
}
