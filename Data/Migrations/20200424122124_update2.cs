using Microsoft.EntityFrameworkCore.Migrations;

namespace petOwnerOneStopShop.Data.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d3b355e-cf4d-4597-a19f-5f6640dd0ff9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d57261ce-f75a-44fe-ab25-94d1987a3524");

            migrationBuilder.AddColumn<int>(
                name: "PetOwnerId",
                table: "NewsFeed",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3042abe9-5b0b-447b-8ef2-caac53f87d91", "4c1404e4-f6ae-4a64-946c-2964af98cb0b", "Pet Owner", "PET OWNER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ebeeee21-33c3-4be4-a438-b15005b5415b", "6b99bbae-f8e1-4602-ae8e-a249de50e331", "Pet-Friendly Business", "PET-FRIENDLY BUSINESS" });

            migrationBuilder.CreateIndex(
                name: "IX_NewsFeed_PetOwnerId",
                table: "NewsFeed",
                column: "PetOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsFeed_PetOwner_PetOwnerId",
                table: "NewsFeed",
                column: "PetOwnerId",
                principalTable: "PetOwner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsFeed_PetOwner_PetOwnerId",
                table: "NewsFeed");

            migrationBuilder.DropIndex(
                name: "IX_NewsFeed_PetOwnerId",
                table: "NewsFeed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3042abe9-5b0b-447b-8ef2-caac53f87d91");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebeeee21-33c3-4be4-a438-b15005b5415b");

            migrationBuilder.DropColumn(
                name: "PetOwnerId",
                table: "NewsFeed");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3d3b355e-cf4d-4597-a19f-5f6640dd0ff9", "aa74eb75-756b-4285-bd7f-6b1aaab3d6cc", "Pet Owner", "PET OWNER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d57261ce-f75a-44fe-ab25-94d1987a3524", "78256579-0416-44a2-a7a5-bf35a57e4375", "Pet-Friendly Business", "PET-FRIENDLY BUSINESS" });
        }
    }
}
