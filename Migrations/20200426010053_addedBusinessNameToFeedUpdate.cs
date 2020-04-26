using Microsoft.EntityFrameworkCore.Migrations;

namespace PawentsOneStopShop.Migrations
{
    public partial class addedBusinessNameToFeedUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04b8f30d-ed0d-42e8-8dc4-23d71f920115");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc3cdf70-0ee5-4496-b5d3-a0b3beec8484");

            migrationBuilder.AddColumn<string>(
                name: "BusinessName",
                table: "FeedUpdate",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1763d718-662f-45fa-b3ea-7c6c5dbc9da9", "34dc7f90-6cbd-4257-a662-85b95d02c5c9", "Pet Owner", "PET OWNER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8f5c3110-4eb4-4d3d-b83f-52becda764d8", "498488c0-5512-4b71-8da5-5fb5d70a8f40", "Pet-Friendly Business", "PET-FRIENDLY BUSINESS" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1763d718-662f-45fa-b3ea-7c6c5dbc9da9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f5c3110-4eb4-4d3d-b83f-52becda764d8");

            migrationBuilder.DropColumn(
                name: "BusinessName",
                table: "FeedUpdate");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "04b8f30d-ed0d-42e8-8dc4-23d71f920115", "172a258d-5d2e-4f04-8eae-5f528693aa09", "Pet Owner", "PET OWNER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fc3cdf70-0ee5-4496-b5d3-a0b3beec8484", "4057a3ea-0c78-4074-aa2f-4cfe672cfa85", "Pet-Friendly Business", "PET-FRIENDLY BUSINESS" });
        }
    }
}
