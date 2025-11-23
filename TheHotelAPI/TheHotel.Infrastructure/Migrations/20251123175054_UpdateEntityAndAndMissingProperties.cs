using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheHotel.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntityAndAndMissingProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Staff",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "RoomServiceOrders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "RoomServiceOrderItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "image",
                table: "RoomServiceMenu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "RoomServiceMenu",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Rooms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Devices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Bookings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "RoomServiceOrders");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "RoomServiceOrderItems");

            migrationBuilder.DropColumn(
                name: "image",
                table: "RoomServiceMenu");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "RoomServiceMenu");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Bookings");
        }
    }
}
