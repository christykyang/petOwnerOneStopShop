using Microsoft.EntityFrameworkCore.Migrations;

namespace petOwnerOneStopShop.Data.Migrations
{
    public partial class saysToAddMigrationAgain1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3042abe9-5b0b-447b-8ef2-caac53f87d91");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebeeee21-33c3-4be4-a438-b15005b5415b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "020ffbe6-1666-4da9-b7df-834745b3ab7d", "4f7ada7e-9055-4223-97c3-332b5a82e561", "Pet Owner", "PET OWNER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8a458493-6842-48dc-be21-7e0ae2189193", "525e2854-41fb-411c-9dae-ef771ee189fe", "Pet-Friendly Business", "PET-FRIENDLY BUSINESS" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "020ffbe6-1666-4da9-b7df-834745b3ab7d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a458493-6842-48dc-be21-7e0ae2189193");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3042abe9-5b0b-447b-8ef2-caac53f87d91", "4c1404e4-f6ae-4a64-946c-2964af98cb0b", "Pet Owner", "PET OWNER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ebeeee21-33c3-4be4-a438-b15005b5415b", "6b99bbae-f8e1-4602-ae8e-a249de50e331", "Pet-Friendly Business", "PET-FRIENDLY BUSINESS" });
        }
    }
}
