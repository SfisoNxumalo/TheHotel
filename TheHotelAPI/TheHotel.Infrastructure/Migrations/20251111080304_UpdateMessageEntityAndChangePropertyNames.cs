using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheHotel.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMessageEntityAndChangePropertyNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Bookings_BookingEntityId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Staff_SenderStaffId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_SenderUserId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_BookingEntityId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_SenderStaffId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "BookingEntityId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "SenderStaffId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "SenderUserId",
                table: "Messages",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_SenderUserId",
                table: "Messages",
                newName: "IX_Messages_UserId");

            migrationBuilder.AddColumn<Guid>(
                name: "StaffId",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Messages_StaffId",
                table: "Messages",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Staff_StaffId",
                table: "Messages",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_UserId",
                table: "Messages",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Staff_StaffId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_UserId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_StaffId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Messages",
                newName: "SenderUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                newName: "IX_Messages_SenderUserId");

            migrationBuilder.AddColumn<Guid>(
                name: "BookingEntityId",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SenderStaffId",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_BookingEntityId",
                table: "Messages",
                column: "BookingEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderStaffId",
                table: "Messages",
                column: "SenderStaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Bookings_BookingEntityId",
                table: "Messages",
                column: "BookingEntityId",
                principalTable: "Bookings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Staff_SenderStaffId",
                table: "Messages",
                column: "SenderStaffId",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_SenderUserId",
                table: "Messages",
                column: "SenderUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
