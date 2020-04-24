using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace petOwnerOneStopShop.Data.Migrations
{
    public partial class testingAddImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Follow_BusinessType_BusinessTypeId",
                table: "Follow");

            migrationBuilder.DropForeignKey(
                name: "FK_Invite_Event_EventId",
                table: "Invite");

            migrationBuilder.DropIndex(
                name: "IX_Invite_EventId",
                table: "Invite");

            migrationBuilder.DropIndex(
                name: "IX_Follow_BusinessTypeId",
                table: "Follow");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f3012a8-8f3a-4969-960d-e2603365f550");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f946eefe-8f12-4c0c-b6c9-4b854c78ada7");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Invite");

            migrationBuilder.DropColumn(
                name: "BusinessTypeId",
                table: "Follow");

            migrationBuilder.DropColumn(
                name: "EventDate",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Event");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "PetProfile",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CalendarEventId",
                table: "Invite",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PetBusinessId",
                table: "Follow",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Event",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Event",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Delete",
                table: "Event",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "Event",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Event",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Event",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(nullable: false),
                    Position = table.Column<string>(nullable: false),
                    Office = table.Column<string>(nullable: false),
                    Salary = table.Column<int>(nullable: false),
                    ProfilePicture = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsFeed",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PetBusinessId = table.Column<int>(nullable: false),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsFeed", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsFeed_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NewsFeed_PetBusiness_PetBusinessId",
                        column: x => x.PetBusinessId,
                        principalTable: "PetBusiness",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceOffered",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<string>(nullable: true),
                    PetBusinessId = table.Column<int>(nullable: true),
                    ServiceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceOffered", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceOffered_PetBusiness_PetBusinessId",
                        column: x => x.PetBusinessId,
                        principalTable: "PetBusiness",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceOffered_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FeedUpdate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PubDate = table.Column<string>(nullable: true),
                    NewsFeedId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedUpdate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeedUpdate_NewsFeed_NewsFeedId",
                        column: x => x.NewsFeedId,
                        principalTable: "NewsFeed",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "336ee341-42a7-463a-ae6c-ceeb990a1586", "41226bb4-d2c1-416a-9759-45c1b10698a0", "Pet Owner", "PET OWNER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5565baa9-dea0-4ccf-8691-9b82b39a6a96", "31fb1b9f-9f8c-4cd6-9715-4e6a00d45c7f", "Pet-Friendly Business", "PET-FRIENDLY BUSINESS" });

            migrationBuilder.CreateIndex(
                name: "IX_Invite_CalendarEventId",
                table: "Invite",
                column: "CalendarEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Follow_PetBusinessId",
                table: "Follow",
                column: "PetBusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedUpdate_NewsFeedId",
                table: "FeedUpdate",
                column: "NewsFeedId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsFeed_IdentityUserId",
                table: "NewsFeed",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsFeed_PetBusinessId",
                table: "NewsFeed",
                column: "PetBusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOffered_PetBusinessId",
                table: "ServiceOffered",
                column: "PetBusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOffered_ServiceId",
                table: "ServiceOffered",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Follow_PetBusiness_PetBusinessId",
                table: "Follow",
                column: "PetBusinessId",
                principalTable: "PetBusiness",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invite_Event_CalendarEventId",
                table: "Invite",
                column: "CalendarEventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Follow_PetBusiness_PetBusinessId",
                table: "Follow");

            migrationBuilder.DropForeignKey(
                name: "FK_Invite_Event_CalendarEventId",
                table: "Invite");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "FeedUpdate");

            migrationBuilder.DropTable(
                name: "ServiceOffered");

            migrationBuilder.DropTable(
                name: "NewsFeed");

            migrationBuilder.DropIndex(
                name: "IX_Invite_CalendarEventId",
                table: "Invite");

            migrationBuilder.DropIndex(
                name: "IX_Follow_PetBusinessId",
                table: "Follow");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "336ee341-42a7-463a-ae6c-ceeb990a1586");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5565baa9-dea0-4ccf-8691-9b82b39a6a96");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "PetProfile");

            migrationBuilder.DropColumn(
                name: "CalendarEventId",
                table: "Invite");

            migrationBuilder.DropColumn(
                name: "PetBusinessId",
                table: "Follow");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Delete",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Details",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Event");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Invite",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BusinessTypeId",
                table: "Follow",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EventDate",
                table: "Event",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Event",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f946eefe-8f12-4c0c-b6c9-4b854c78ada7", "fa716548-629d-4fa1-abe6-bfb63bb71606", "Pet Owner", "PET OWNER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8f3012a8-8f3a-4969-960d-e2603365f550", "309da9b6-7ef5-4d75-9cae-b000d87e45ef", "Pet-Friendly Business", "PET-FRIENDLY BUSINESS" });

            migrationBuilder.CreateIndex(
                name: "IX_Invite_EventId",
                table: "Invite",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Follow_BusinessTypeId",
                table: "Follow",
                column: "BusinessTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Follow_BusinessType_BusinessTypeId",
                table: "Follow",
                column: "BusinessTypeId",
                principalTable: "BusinessType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invite_Event_EventId",
                table: "Invite",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
