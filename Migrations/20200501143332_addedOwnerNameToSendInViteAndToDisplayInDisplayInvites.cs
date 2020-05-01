using Microsoft.EntityFrameworkCore.Migrations;

namespace PawentsOneStopShop.Migrations
{
    public partial class addedOwnerNameToSendInViteAndToDisplayInDisplayInvites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ObjectInvite_ObjectEvent_ObjectEventId",
                table: "ObjectInvite");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5281b029-6a78-4010-9e35-0db58c6d70cd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95b490d0-cc36-4b79-af68-272a28d4512f");

            migrationBuilder.AlterColumn<int>(
                name: "ObjectEventId",
                table: "ObjectInvite",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerInvitedName",
                table: "ObjectInvite",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerSendingName",
                table: "ObjectInvite",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e97e7c0d-fd8b-4d3b-a181-a71b7b6b7d5c", "dbf17b25-b8f8-4587-bfb2-2d77f7fb0536", "Pet Owner", "PET OWNER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e492b7b6-558d-461d-9c79-a003e1da83f3", "cbfdf11f-40a9-40d6-8cf7-af3b79d77b14", "Pet-Friendly Business", "PET-FRIENDLY BUSINESS" });

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectInvite_ObjectEvent_ObjectEventId",
                table: "ObjectInvite",
                column: "ObjectEventId",
                principalTable: "ObjectEvent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ObjectInvite_ObjectEvent_ObjectEventId",
                table: "ObjectInvite");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e492b7b6-558d-461d-9c79-a003e1da83f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e97e7c0d-fd8b-4d3b-a181-a71b7b6b7d5c");

            migrationBuilder.DropColumn(
                name: "OwnerInvitedName",
                table: "ObjectInvite");

            migrationBuilder.DropColumn(
                name: "OwnerSendingName",
                table: "ObjectInvite");

            migrationBuilder.AlterColumn<int>(
                name: "ObjectEventId",
                table: "ObjectInvite",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "95b490d0-cc36-4b79-af68-272a28d4512f", "4074f8fc-a7da-4dbc-8d4d-7a0627616ed9", "Pet Owner", "PET OWNER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5281b029-6a78-4010-9e35-0db58c6d70cd", "14bd9646-4673-42eb-9bf7-ff3a1bb1f926", "Pet-Friendly Business", "PET-FRIENDLY BUSINESS" });

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectInvite_ObjectEvent_ObjectEventId",
                table: "ObjectInvite",
                column: "ObjectEventId",
                principalTable: "ObjectEvent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
