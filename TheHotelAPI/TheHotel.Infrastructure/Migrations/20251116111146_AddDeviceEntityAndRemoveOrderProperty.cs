using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheHotel.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDeviceEntityAndRemoveOrderProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomServiceOrders_Bookings_BookingId",
                table: "RoomServiceOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomServiceOrders_Devices_DeviceEntityId",
                table: "RoomServiceOrders");

            migrationBuilder.RenameColumn(
                name: "DeviceEntityId",
                table: "RoomServiceOrders",
                newName: "BookingEntityId");

            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "RoomServiceOrders",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomServiceOrders_DeviceEntityId",
                table: "RoomServiceOrders",
                newName: "IX_RoomServiceOrders_BookingEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomServiceOrders_BookingId",
                table: "RoomServiceOrders",
                newName: "IX_RoomServiceOrders_UserId");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "RoomServiceOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomServiceOrders_Bookings_BookingEntityId",
                table: "RoomServiceOrders",
                column: "BookingEntityId",
                principalTable: "Bookings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomServiceOrders_Users_UserId",
                table: "RoomServiceOrders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomServiceOrders_Bookings_BookingEntityId",
                table: "RoomServiceOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomServiceOrders_Users_UserId",
                table: "RoomServiceOrders");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "RoomServiceOrders");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "RoomServiceOrders",
                newName: "BookingId");

            migrationBuilder.RenameColumn(
                name: "BookingEntityId",
                table: "RoomServiceOrders",
                newName: "DeviceEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomServiceOrders_UserId",
                table: "RoomServiceOrders",
                newName: "IX_RoomServiceOrders_BookingId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomServiceOrders_BookingEntityId",
                table: "RoomServiceOrders",
                newName: "IX_RoomServiceOrders_DeviceEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomServiceOrders_Bookings_BookingId",
                table: "RoomServiceOrders",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomServiceOrders_Devices_DeviceEntityId",
                table: "RoomServiceOrders",
                column: "DeviceEntityId",
                principalTable: "Devices",
                principalColumn: "Id");
        }
    }
}
