using Microsoft.EntityFrameworkCore.Migrations;

namespace PawentsOneStopShop.Migrations
{
    public partial class updateDatabase1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "7c2bf308-3d4b-4eaa-b86e-2f259231dd3b", "c7c05dd4-5b2a-411a-b851-6c3849c2886b", "Pet Owner", "PET OWNER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0f54ee06-4c45-45f0-8e66-1c858845c7de", "58bf2e49-a009-42d0-8a50-379065f1a7aa", "Pet-Friendly Business", "PET-FRIENDLY BUSINESS" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f54ee06-4c45-45f0-8e66-1c858845c7de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c2bf308-3d4b-4eaa-b86e-2f259231dd3b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "29e04716-2669-4dea-86d7-30cbf9099bc0", "7cad312a-8eee-45a3-8728-ca579d22ec38", "Pet Owner", "PET OWNER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dc329a40-1f56-4083-9fda-5047f8dc6d58", "866994de-75de-4514-bfdd-13e5ccf08ea4", "Pet-Friendly Business", "PET-FRIENDLY BUSINESS" });
        }
    }
}
