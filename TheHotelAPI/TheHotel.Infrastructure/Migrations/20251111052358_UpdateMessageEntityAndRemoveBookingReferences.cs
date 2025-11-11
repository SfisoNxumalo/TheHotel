using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheHotel.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMessageEntityAndRemoveBookingReferences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Bookings_BookingId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomServiceOrders_Devices_DeviceId",
                table: "RoomServiceOrders");

            migrationBuilder.DropIndex(
                name: "IX_Messages_BookingId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "SenderType",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "DeviceId",
                table: "RoomServiceOrders",
                newName: "DeviceEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomServiceOrders_DeviceId",
                table: "RoomServiceOrders",
                newName: "IX_RoomServiceOrders_DeviceEntityId");

            migrationBuilder.AddColumn<Guid>(
                name: "BookingEntityId",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeviceId",
                table: "Bookings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_BookingEntityId",
                table: "Messages",
                column: "BookingEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_DeviceId",
                table: "Bookings",
                column: "DeviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Devices_DeviceId",
                table: "Bookings",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Bookings_BookingEntityId",
                table: "Messages",
                column: "BookingEntityId",
                principalTable: "Bookings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomServiceOrders_Devices_DeviceEntityId",
                table: "RoomServiceOrders",
                column: "DeviceEntityId",
                principalTable: "Devices",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Devices_DeviceId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Bookings_BookingEntityId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomServiceOrders_Devices_DeviceEntityId",
                table: "RoomServiceOrders");

            migrationBuilder.DropIndex(
                name: "IX_Messages_BookingEntityId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_DeviceId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "BookingEntityId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "DeviceId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "DeviceEntityId",
                table: "RoomServiceOrders",
                newName: "DeviceId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomServiceOrders_DeviceEntityId",
                table: "RoomServiceOrders",
                newName: "IX_RoomServiceOrders_DeviceId");

            migrationBuilder.AddColumn<Guid>(
                name: "BookingId",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "SenderType",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_BookingId",
                table: "Messages",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Bookings_BookingId",
                table: "Messages",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomServiceOrders_Devices_DeviceId",
                table: "RoomServiceOrders",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id");
        }
    }
}
