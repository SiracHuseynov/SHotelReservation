using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHotel.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Workers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 14, 23, 56, 11, 480, DateTimeKind.Utc).AddTicks(2488),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 14, 17, 58, 16, 875, DateTimeKind.Utc).AddTicks(7249));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 14, 23, 56, 11, 480, DateTimeKind.Utc).AddTicks(575),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 14, 17, 58, 16, 875, DateTimeKind.Utc).AddTicks(5547));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 14, 23, 56, 11, 479, DateTimeKind.Utc).AddTicks(8427),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 14, 17, 58, 16, 875, DateTimeKind.Utc).AddTicks(3410));

            migrationBuilder.AddColumn<double>(
                name: "DiscountPercent",
                table: "Rooms",
                type: "float",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 14, 23, 56, 11, 479, DateTimeKind.Utc).AddTicks(6527),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 14, 17, 58, 16, 875, DateTimeKind.Utc).AddTicks(1586));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Positions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 14, 23, 56, 11, 479, DateTimeKind.Utc).AddTicks(4886),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 14, 17, 58, 16, 875, DateTimeKind.Utc).AddTicks(37));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GuestReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 14, 23, 56, 11, 479, DateTimeKind.Utc).AddTicks(3090),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 14, 17, 58, 16, 874, DateTimeKind.Utc).AddTicks(8240));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Feature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 14, 23, 56, 11, 479, DateTimeKind.Utc).AddTicks(1310),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 14, 17, 58, 16, 874, DateTimeKind.Utc).AddTicks(6570));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Eats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 14, 23, 56, 11, 478, DateTimeKind.Utc).AddTicks(9395),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 14, 17, 58, 16, 874, DateTimeKind.Utc).AddTicks(4654));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EatCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 14, 23, 56, 11, 478, DateTimeKind.Utc).AddTicks(7681),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 14, 17, 58, 16, 874, DateTimeKind.Utc).AddTicks(2971));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Beds",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 14, 23, 56, 11, 478, DateTimeKind.Utc).AddTicks(5595),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 14, 17, 58, 16, 874, DateTimeKind.Utc).AddTicks(1052));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountPercent",
                table: "Rooms");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Workers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 14, 17, 58, 16, 875, DateTimeKind.Utc).AddTicks(7249),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 14, 23, 56, 11, 480, DateTimeKind.Utc).AddTicks(2488));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 14, 17, 58, 16, 875, DateTimeKind.Utc).AddTicks(5547),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 14, 23, 56, 11, 480, DateTimeKind.Utc).AddTicks(575));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 14, 17, 58, 16, 875, DateTimeKind.Utc).AddTicks(3410),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 14, 23, 56, 11, 479, DateTimeKind.Utc).AddTicks(8427));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 14, 17, 58, 16, 875, DateTimeKind.Utc).AddTicks(1586),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 14, 23, 56, 11, 479, DateTimeKind.Utc).AddTicks(6527));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Positions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 14, 17, 58, 16, 875, DateTimeKind.Utc).AddTicks(37),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 14, 23, 56, 11, 479, DateTimeKind.Utc).AddTicks(4886));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GuestReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 14, 17, 58, 16, 874, DateTimeKind.Utc).AddTicks(8240),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 14, 23, 56, 11, 479, DateTimeKind.Utc).AddTicks(3090));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Feature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 14, 17, 58, 16, 874, DateTimeKind.Utc).AddTicks(6570),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 14, 23, 56, 11, 479, DateTimeKind.Utc).AddTicks(1310));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Eats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 14, 17, 58, 16, 874, DateTimeKind.Utc).AddTicks(4654),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 14, 23, 56, 11, 478, DateTimeKind.Utc).AddTicks(9395));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EatCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 14, 17, 58, 16, 874, DateTimeKind.Utc).AddTicks(2971),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 14, 23, 56, 11, 478, DateTimeKind.Utc).AddTicks(7681));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Beds",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 14, 17, 58, 16, 874, DateTimeKind.Utc).AddTicks(1052),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 14, 23, 56, 11, 478, DateTimeKind.Utc).AddTicks(5595));
        }
    }
}
