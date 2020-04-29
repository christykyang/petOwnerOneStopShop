using Microsoft.EntityFrameworkCore.Migrations;

namespace PawentsOneStopShop.Migrations
{
    public partial class addedServiceNameToServiceOffered : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1763d718-662f-45fa-b3ea-7c6c5dbc9da9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f5c3110-4eb4-4d3d-b83f-52becda764d8");

            migrationBuilder.AddColumn<string>(
                name: "ServiceName",
                table: "ServiceOffered",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9a571bd2-e5cd-4288-b89c-c0fd5da3ce20", "39d2657b-38e2-4a2d-af47-4f91af285abf", "Pet Owner", "PET OWNER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2b2cce34-12ad-4891-8110-d1993cd0b3cd", "a864fe74-99c6-4192-8f8b-7565109dd655", "Pet-Friendly Business", "PET-FRIENDLY BUSINESS" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b2cce34-12ad-4891-8110-d1993cd0b3cd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a571bd2-e5cd-4288-b89c-c0fd5da3ce20");

            migrationBuilder.DropColumn(
                name: "ServiceName",
                table: "ServiceOffered");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1763d718-662f-45fa-b3ea-7c6c5dbc9da9", "34dc7f90-6cbd-4257-a662-85b95d02c5c9", "Pet Owner", "PET OWNER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8f5c3110-4eb4-4d3d-b83f-52becda764d8", "498488c0-5512-4b71-8da5-5fb5d70a8f40", "Pet-Friendly Business", "PET-FRIENDLY BUSINESS" });
        }
    }
}
