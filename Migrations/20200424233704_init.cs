using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace petOwnerOneStopShop.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetAddress = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    ZipCode = table.Column<string>(nullable: false),
                    Lat = table.Column<double>(nullable: false),
                    Lng = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfBusiness = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessType", x => x.Id);
                });

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
                name: "PetType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetType", x => x.Id);
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "PetOwner",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    IdentityUserId = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetOwner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PetOwner_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PetOwner_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PetBusiness",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: true),
                    IdentityUserId = table.Column<string>(nullable: true),
                    BusinessTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetBusiness", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PetBusiness_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PetBusiness_BusinessType_BusinessTypeId",
                        column: x => x.BusinessTypeId,
                        principalTable: "BusinessType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PetBusiness_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    ColorId = table.Column<int>(nullable: false),
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
                    PetOwnerId = table.Column<int>(nullable: true),
                    ProfilePicture = table.Column<string>(nullable: true)
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
                name: "Follow",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsFollowing = table.Column<bool>(nullable: true),
                    PetOwnerId = table.Column<int>(nullable: true),
                    PetBusinessId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Follow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Follow_PetBusiness_PetBusinessId",
                        column: x => x.PetBusinessId,
                        principalTable: "PetBusiness",
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
                name: "NewsFeed",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PetBusinessId = table.Column<int>(nullable: false),
                    PetOwnerId = table.Column<int>(nullable: false),
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
                    table.ForeignKey(
                        name: "FK_NewsFeed_PetOwner_PetOwnerId",
                        column: x => x.PetOwnerId,
                        principalTable: "PetOwner",
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
                    PetBusinessId = table.Column<int>(nullable: false),
                    ServiceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceOffered", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceOffered_PetBusiness_PetBusinessId",
                        column: x => x.PetBusinessId,
                        principalTable: "PetBusiness",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceOffered_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invite",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isInvitationAccepted = table.Column<bool>(nullable: true),
                    IdentityUserId = table.Column<string>(nullable: true),
                    CalendarEventId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invite_Event_CalendarEventId",
                        column: x => x.CalendarEventId,
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
                name: "FeedUpdate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                values: new object[,]
                {
                    { "42e97c1d-8c65-437f-8043-88340f347ad6", "fd0639af-89b5-4ca4-b06c-8ba953084fb0", "Pet Owner", "PET OWNER" },
                    { "7d789b3b-c4fe-4e4e-b09a-9f8a5307330e", "235cd85a-f885-4efb-99d0-5bf231529bb8", "Pet-Friendly Business", "PET-FRIENDLY BUSINESS" }
                });

            migrationBuilder.InsertData(
                table: "BusinessType",
                columns: new[] { "Id", "TypeOfBusiness" },
                values: new object[,]
                {
                    { 1, "Pet Sitting" },
                    { 2, "Pet Training" },
                    { 3, "Pet Boarding" },
                    { 4, "Veterinarian" },
                    { 5, "Grooming" },
                    { 6, "Pet Transportation" },
                    { 7, "Pet Supply" },
                    { 8, "Miscellaneous" }
                });

            migrationBuilder.InsertData(
                table: "PetType",
                columns: new[] { "Id", "TypeName" },
                values: new object[,]
                {
                    { 8, "Farm Animal" },
                    { 6, "Reptile" },
                    { 5, "Small Pet" },
                    { 7, "Amphibian" },
                    { 3, "Fish" },
                    { 2, "Cat" },
                    { 1, "Dog" },
                    { 4, "Bird" }
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
                    { 6, "Spay and Neuter" },
                    { 5, "Swimming Pool" },
                    { 4, "Pet Boarding" },
                    { 3, "Pet Training" },
                    { 2, "Pet Grooming" },
                    { 1, "Pet Bathing" },
                    { 15, "Self-Bathing Service" },
                    { 7, "Pet Vaccines" },
                    { 16, "Volunteering" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adoptable_PetBusinessId",
                table: "Adoptable",
                column: "PetBusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Adoptable_PetProfileId",
                table: "Adoptable",
                column: "PetProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Calendar_IdentityUserId",
                table: "Calendar",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_CalendarId",
                table: "Event",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedUpdate_NewsFeedId",
                table: "FeedUpdate",
                column: "NewsFeedId");

            migrationBuilder.CreateIndex(
                name: "IX_Follow_PetBusinessId",
                table: "Follow",
                column: "PetBusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Follow_PetOwnerId",
                table: "Follow",
                column: "PetOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Invite_CalendarEventId",
                table: "Invite",
                column: "CalendarEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Invite_IdentityUserId",
                table: "Invite",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsFeed_IdentityUserId",
                table: "NewsFeed",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsFeed_PetBusinessId",
                table: "NewsFeed",
                column: "PetBusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsFeed_PetOwnerId",
                table: "NewsFeed",
                column: "PetOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PetBusiness_AddressId",
                table: "PetBusiness",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_PetBusiness_BusinessTypeId",
                table: "PetBusiness",
                column: "BusinessTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PetBusiness_IdentityUserId",
                table: "PetBusiness",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PetOwner_AddressId",
                table: "PetOwner",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_PetOwner_IdentityUserId",
                table: "PetOwner",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PetProfile_PetOwnerId",
                table: "PetProfile",
                column: "PetOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PetProfile_PetTypeId",
                table: "PetProfile",
                column: "PetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOffered_PetBusinessId",
                table: "ServiceOffered",
                column: "PetBusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOffered_ServiceId",
                table: "ServiceOffered",
                column: "ServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adoptable");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "FeedUpdate");

            migrationBuilder.DropTable(
                name: "Follow");

            migrationBuilder.DropTable(
                name: "Invite");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "ServiceOffered");

            migrationBuilder.DropTable(
                name: "PetProfile");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "NewsFeed");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "PetType");

            migrationBuilder.DropTable(
                name: "PetBusiness");

            migrationBuilder.DropTable(
                name: "PetOwner");

            migrationBuilder.DropTable(
                name: "Calendar");

            migrationBuilder.DropTable(
                name: "BusinessType");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
