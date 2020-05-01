using Microsoft.EntityFrameworkCore.Migrations;

namespace PawentsOneStopShop.Migrations
{
    public partial class updatedobjectInvitemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d91c4ae-591a-49e8-a3a1-399fb4bc4648");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c6ce202-4b18-4d27-8d11-fb3397062d42");

            migrationBuilder.AddColumn<string>(
                name: "ObjectEventName",
                table: "ObjectInvite",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ce7b6c3d-4b35-477e-9b98-711fcb15fab3", "c1c937c8-1932-46d9-8e88-d457c6bcbc7b", "Pet Owner", "PET OWNER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6447ff6c-5b52-4ee7-abdc-a38766cc5370", "016e5de0-1f9b-45a2-ae22-1f587a5d1f90", "Pet-Friendly Business", "PET-FRIENDLY BUSINESS" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6447ff6c-5b52-4ee7-abdc-a38766cc5370");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce7b6c3d-4b35-477e-9b98-711fcb15fab3");

            migrationBuilder.DropColumn(
                name: "ObjectEventName",
                table: "ObjectInvite");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5d91c4ae-591a-49e8-a3a1-399fb4bc4648", "195d0fa3-66b5-434a-9168-6c93f1fb8027", "Pet Owner", "PET OWNER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6c6ce202-4b18-4d27-8d11-fb3397062d42", "2f58d95f-060e-44bd-b4d9-6a40f49c5a6a", "Pet-Friendly Business", "PET-FRIENDLY BUSINESS" });
        }
    }
}
