using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace petOwnerOneStopShop.Data.Migrations
{
    public partial class addedServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07a8b8b8-37b0-4423-b72e-73526bacc5f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "942196a4-e250-4f15-bb61-a675980ab2bf");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "PetOwner",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Calendar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calendar_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Follow",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsFollowing = table.Column<bool>(nullable: true),
                    PetOwnerId = table.Column<int>(nullable: true),
                    BusinessTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Follow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Follow_BusinessType_BusinessTypeId",
                        column: x => x.BusinessTypeId,
                        principalTable: "BusinessType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Follow_PetOwner_PetOwnerId",
                        column: x => x.PetOwnerId,
                        principalTable: "PetOwner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    UserFromID = table.Column<string>(nullable: true),
                    UserToId = table.Column<string>(nullable: true),
                    MessageContent = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PetProfile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    IsMale = table.Column<bool>(nullable: true),
                    IsAdopted = table.Column<bool>(nullable: true),
                    PetTypeId = table.Column<int>(nullable: true),
                    PetOwnerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PetProfile_PetOwner_PetOwnerId",
                        column: x => x.PetOwnerId,
                        principalTable: "PetOwner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PetProfile_PetType_PetTypeId",
                        column: x => x.PetTypeId,
                        principalTable: "PetType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    EventDate = table.Column<DateTime>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    CalendarId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_Calendar_CalendarId",
                        column: x => x.CalendarId,
                        principalTable: "Calendar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Adoptable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isAdoptable = table.Column<bool>(nullable: true),
                    PetProfileId = table.Column<int>(nullable: true),
                    PetBusinessId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adoptable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adoptable_PetBusiness_PetBusinessId",
                        column: x => x.PetBusinessId,
                        principalTable: "PetBusiness",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Adoptable_PetProfile_PetProfileId",
                        column: x => x.PetProfileId,
                        principalTable: "PetProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invite",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isInvitationAccepted = table.Column<bool>(nullable: true),
                    IdentityUserId = table.Column<string>(nullable: true),
                    EventId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invite_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invite_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f946eefe-8f12-4c0c-b6c9-4b854c78ada7", "fa716548-629d-4fa1-abe6-bfb63bb71606", "Pet Owner", "PET OWNER" },
                    { "8f3012a8-8f3a-4969-960d-e2603365f550", "309da9b6-7ef5-4d75-9cae-b000d87e45ef", "Pet-Friendly Business", "PET-FRIENDLY BUSINESS" }
                });

            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "Id", "ServiceName" },
                values: new object[,]
                {
                    { 14, "Animal/Pet Educational Resources" },
                    { 13, "Pet Transportation" },
                    { 12, "Pet Supplies" },
                    { 11, "Pet Exercise" },
                    { 10, "Pet Socialization" },
                    { 9, "Pet Food" },
                    { 8, "Pet Physical Theraphy" },
                    { 7, "Pet Vaccines" },
                    { 6, "Spay and Neuter" },
                    { 5, "Swimming Pool" },
                    { 4, "Pet Boarding" },
                    { 3, "Pet Training" },
                    { 2, "Pet Grooming" },
                    { 1, "Pet Bathing" },
                    { 15, "Self-Bathing Service" },
                    { 16, "Volunteering" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PetOwner_AddressId",
                table: "PetOwner",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Adoptable_PetBusinessId",
                table: "Adoptable",
                column: "PetBusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Adoptable_PetProfileId",
                table: "Adoptable",
                column: "PetProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendar_IdentityUserId",
                table: "Calendar",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_CalendarId",
                table: "Event",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_Follow_BusinessTypeId",
                table: "Follow",
                column: "BusinessTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Follow_PetOwnerId",
                table: "Follow",
                column: "PetOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Invite_EventId",
                table: "Invite",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Invite_IdentityUserId",
                table: "Invite",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PetProfile_PetOwnerId",
                table: "PetProfile",
                column: "PetOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PetProfile_PetTypeId",
                table: "PetProfile",
                column: "PetTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PetOwner_Address_AddressId",
                table: "PetOwner",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetOwner_Address_AddressId",
                table: "PetOwner");

            migrationBuilder.DropTable(
                name: "Adoptable");

            migrationBuilder.DropTable(
                name: "Follow");

            migrationBuilder.DropTable(
                name: "Invite");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "PetProfile");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Calendar");

            migrationBuilder.DropIndex(
                name: "IX_PetOwner_AddressId",
                table: "PetOwner");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f3012a8-8f3a-4969-960d-e2603365f550");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f946eefe-8f12-4c0c-b6c9-4b854c78ada7");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "PetOwner");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "942196a4-e250-4f15-bb61-a675980ab2bf", "1b5faf5f-c03c-4122-8674-4db76d6768a5", "Pet Owner", "PET OWNER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "07a8b8b8-37b0-4423-b72e-73526bacc5f5", "357cf98d-0042-4713-8b72-5f3fb6a563e3", "Pet-Friendly Business", "PET-FRIENDLY BUSINESS" });
        }
    }
}
