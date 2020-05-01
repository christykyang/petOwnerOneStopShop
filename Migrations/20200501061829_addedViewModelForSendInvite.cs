using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PawentsOneStopShop.Migrations
{
    public partial class addedViewModelForSendInvite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ObjectEvent_ObjectCalendar_ObjectCalendarId",
                table: "ObjectEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_ObjectInvite_AspNetUsers_IdentityUserId",
                table: "ObjectInvite");

            migrationBuilder.DropIndex(
                name: "IX_ObjectInvite_IdentityUserId",
                table: "ObjectInvite");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f54ee06-4c45-45f0-8e66-1c858845c7de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c2bf308-3d4b-4eaa-b86e-2f259231dd3b");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "ObjectInvite");

            migrationBuilder.DropColumn(
                name: "ObjectCalendarEventId",
                table: "ObjectInvite");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "ObjectEvent");

            migrationBuilder.DropColumn(
                name: "Delete",
                table: "ObjectEvent");

            migrationBuilder.AddColumn<int>(
                name: "OwnerInvitedId",
                table: "ObjectInvite",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OwnerSendingId",
                table: "ObjectInvite",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "ObjectEvent",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "ObjectCalendarId",
                table: "ObjectEvent",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "ObjectEvent",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "ObjectEvent",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "IsFollowing",
                table: "Follow",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3abebcdd-f398-45bc-81ce-cf783548c537", "4e8ebe5c-0b6d-4e98-b95c-f417c691d378", "Pet Owner", "PET OWNER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c3b96a69-5014-4ae6-9d81-5408f2872e95", "2ed0eba0-8c0e-4fcb-afc5-482765bc9ab3", "Pet-Friendly Business", "PET-FRIENDLY BUSINESS" });

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectEvent_ObjectCalendar_ObjectCalendarId",
                table: "ObjectEvent",
                column: "ObjectCalendarId",
                principalTable: "ObjectCalendar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ObjectEvent_ObjectCalendar_ObjectCalendarId",
                table: "ObjectEvent");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3abebcdd-f398-45bc-81ce-cf783548c537");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3b96a69-5014-4ae6-9d81-5408f2872e95");

            migrationBuilder.DropColumn(
                name: "OwnerInvitedId",
                table: "ObjectInvite");

            migrationBuilder.DropColumn(
                name: "OwnerSendingId",
                table: "ObjectInvite");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "ObjectInvite",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ObjectCalendarEventId",
                table: "ObjectInvite",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "ObjectEvent",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ObjectCalendarId",
                table: "ObjectEvent",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "ObjectEvent",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "ObjectEvent",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "ObjectEvent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Delete",
                table: "ObjectEvent",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsFollowing",
                table: "Follow",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7c2bf308-3d4b-4eaa-b86e-2f259231dd3b", "c7c05dd4-5b2a-411a-b851-6c3849c2886b", "Pet Owner", "PET OWNER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0f54ee06-4c45-45f0-8e66-1c858845c7de", "58bf2e49-a009-42d0-8a50-379065f1a7aa", "Pet-Friendly Business", "PET-FRIENDLY BUSINESS" });

            migrationBuilder.CreateIndex(
                name: "IX_ObjectInvite_IdentityUserId",
                table: "ObjectInvite",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectEvent_ObjectCalendar_ObjectCalendarId",
                table: "ObjectEvent",
                column: "ObjectCalendarId",
                principalTable: "ObjectCalendar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectInvite_AspNetUsers_IdentityUserId",
                table: "ObjectInvite",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
