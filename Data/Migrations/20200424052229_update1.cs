using Microsoft.EntityFrameworkCore.Migrations;

namespace petOwnerOneStopShop.Data.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOffered_PetBusiness_PetBusinessId",
                table: "ServiceOffered");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOffered_Service_ServiceId",
                table: "ServiceOffered");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "336ee341-42a7-463a-ae6c-ceeb990a1586");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5565baa9-dea0-4ccf-8691-9b82b39a6a96");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "FeedUpdate");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "ServiceOffered",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PetBusinessId",
                table: "ServiceOffered",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3d3b355e-cf4d-4597-a19f-5f6640dd0ff9", "aa74eb75-756b-4285-bd7f-6b1aaab3d6cc", "Pet Owner", "PET OWNER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d57261ce-f75a-44fe-ab25-94d1987a3524", "78256579-0416-44a2-a7a5-bf35a57e4375", "Pet-Friendly Business", "PET-FRIENDLY BUSINESS" });

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOffered_PetBusiness_PetBusinessId",
                table: "ServiceOffered",
                column: "PetBusinessId",
                principalTable: "PetBusiness",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOffered_Service_ServiceId",
                table: "ServiceOffered",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOffered_PetBusiness_PetBusinessId",
                table: "ServiceOffered");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOffered_Service_ServiceId",
                table: "ServiceOffered");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d3b355e-cf4d-4597-a19f-5f6640dd0ff9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d57261ce-f75a-44fe-ab25-94d1987a3524");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "ServiceOffered",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PetBusinessId",
                table: "ServiceOffered",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "FeedUpdate",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "336ee341-42a7-463a-ae6c-ceeb990a1586", "41226bb4-d2c1-416a-9759-45c1b10698a0", "Pet Owner", "PET OWNER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5565baa9-dea0-4ccf-8691-9b82b39a6a96", "31fb1b9f-9f8c-4cd6-9715-4e6a00d45c7f", "Pet-Friendly Business", "PET-FRIENDLY BUSINESS" });

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOffered_PetBusiness_PetBusinessId",
                table: "ServiceOffered",
                column: "PetBusinessId",
                principalTable: "PetBusiness",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOffered_Service_ServiceId",
                table: "ServiceOffered",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
