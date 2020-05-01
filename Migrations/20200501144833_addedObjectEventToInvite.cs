using Microsoft.EntityFrameworkCore.Migrations;

namespace PawentsOneStopShop.Migrations
{
    public partial class addedObjectEventToInvite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e492b7b6-558d-461d-9c79-a003e1da83f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e97e7c0d-fd8b-4d3b-a181-a71b7b6b7d5c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "485fd411-07c6-4dd7-90f4-5f1821c1a18b", "f218c4ed-bc5f-4450-acdd-ff673c9c75f4", "Pet Owner", "PET OWNER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b8464629-25b0-434b-9628-7a9feb96a492", "eb163646-bf5d-490d-9553-65c034e03a57", "Pet-Friendly Business", "PET-FRIENDLY BUSINESS" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "485fd411-07c6-4dd7-90f4-5f1821c1a18b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8464629-25b0-434b-9628-7a9feb96a492");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e97e7c0d-fd8b-4d3b-a181-a71b7b6b7d5c", "dbf17b25-b8f8-4587-bfb2-2d77f7fb0536", "Pet Owner", "PET OWNER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e492b7b6-558d-461d-9c79-a003e1da83f3", "cbfdf11f-40a9-40d6-8cf7-af3b79d77b14", "Pet-Friendly Business", "PET-FRIENDLY BUSINESS" });
        }
    }
}
