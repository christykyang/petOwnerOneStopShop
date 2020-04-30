using Microsoft.EntityFrameworkCore.Migrations;

namespace PawentsOneStopShop.Migrations
{
    public partial class updateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0bb50f20-ddc2-4895-9d3c-068a65586175");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3347838-04b4-4d30-8de5-84ceff6ec964");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "29e04716-2669-4dea-86d7-30cbf9099bc0", "7cad312a-8eee-45a3-8728-ca579d22ec38", "Pet Owner", "PET OWNER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dc329a40-1f56-4083-9fda-5047f8dc6d58", "866994de-75de-4514-bfdd-13e5ccf08ea4", "Pet-Friendly Business", "PET-FRIENDLY BUSINESS" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29e04716-2669-4dea-86d7-30cbf9099bc0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc329a40-1f56-4083-9fda-5047f8dc6d58");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d3347838-04b4-4d30-8de5-84ceff6ec964", "2b6e46cd-114c-4ded-899e-1101cf17d032", "Pet Owner", "PET OWNER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0bb50f20-ddc2-4895-9d3c-068a65586175", "1cc9143a-9f50-450e-a84f-5ad325ebefc2", "Pet-Friendly Business", "PET-FRIENDLY BUSINESS" });
        }
    }
}
