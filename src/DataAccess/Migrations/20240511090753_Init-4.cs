using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RoleDetails",
                keyColumn: "RoleId",
                keyValue: new Guid("c39aa1ac-8ded-46be-870c-115b200b09fc"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 11, 9, 7, 53, 407, DateTimeKind.Utc).AddTicks(337));

            migrationBuilder.InsertData(
                table: "RoleDetails",
                columns: new[] { "RoleId", "CreatedAt", "CreatedBy", "RemovedAt", "RemovedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("c8500b46-b134-4b60-85b7-8e6af1187e0c"), new DateTime(2024, 5, 11, 9, 7, 53, 407, DateTimeKind.Utc).AddTicks(342), new Guid("2ed6fb47-86a6-46e3-a9dc-ff5b3d986c2f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c8500b46-b134-4b60-85b7-8e6af1187e1c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c8500b46-b134-4b60-85b7-8e6af1187e1c") });

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
                column: "ConcurrencyStamp",
                value: "ddc028ae-5e84-4e04-9b2c-55a68b2926d3");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleDetails",
                keyColumn: "RoleId",
                keyValue: new Guid("c8500b46-b134-4b60-85b7-8e6af1187e0c"));

            migrationBuilder.UpdateData(
                table: "RoleDetails",
                keyColumn: "RoleId",
                keyValue: new Guid("c39aa1ac-8ded-46be-870c-115b200b09fc"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 11, 9, 3, 8, 606, DateTimeKind.Utc).AddTicks(5734));

            migrationBuilder.UpdateData(
                table: "UserDetails",
                keyColumn: "UserId",
                keyValue: new Guid("2ed6fb47-86a6-46e3-a9dc-ff5b3d986c2f"),
                column: "CreatedAt",
                value: new DateTime(2024, 5, 11, 9, 3, 8, 606, DateTimeKind.Utc).AddTicks(5878));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2ed6fb47-86a6-46e3-a9dc-ff5b3d986c2f"),
                column: "ConcurrencyStamp",
                value: "851ad700-3392-4058-9d61-4c3e82dee142");
        }
    }
}
