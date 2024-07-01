using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHotel.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserIdAddToReservationModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Workers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 26, 13, 55, 26, 477, DateTimeKind.Utc).AddTicks(4825),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 25, 20, 50, 18, 801, DateTimeKind.Utc).AddTicks(2470));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 26, 13, 55, 26, 477, DateTimeKind.Utc).AddTicks(3156),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 25, 20, 50, 18, 801, DateTimeKind.Utc).AddTicks(611));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Settings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 26, 13, 55, 26, 477, DateTimeKind.Utc).AddTicks(1490),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 25, 20, 50, 18, 800, DateTimeKind.Utc).AddTicks(8943));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 26, 13, 55, 26, 476, DateTimeKind.Utc).AddTicks(8938),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 25, 20, 50, 18, 800, DateTimeKind.Utc).AddTicks(6973));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 26, 13, 55, 26, 476, DateTimeKind.Utc).AddTicks(7171),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 25, 20, 50, 18, 800, DateTimeKind.Utc).AddTicks(4681));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Positions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 26, 13, 55, 26, 476, DateTimeKind.Utc).AddTicks(5654),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 25, 20, 50, 18, 800, DateTimeKind.Utc).AddTicks(3015));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GuestReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 26, 13, 55, 26, 476, DateTimeKind.Utc).AddTicks(3995),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 25, 20, 50, 18, 800, DateTimeKind.Utc).AddTicks(1213));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Feature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 26, 13, 55, 26, 476, DateTimeKind.Utc).AddTicks(2423),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 25, 20, 50, 18, 799, DateTimeKind.Utc).AddTicks(9556));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Eats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 26, 13, 55, 26, 476, DateTimeKind.Utc).AddTicks(619),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 25, 20, 50, 18, 799, DateTimeKind.Utc).AddTicks(7656));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EatCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 26, 13, 55, 26, 475, DateTimeKind.Utc).AddTicks(8720),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 25, 20, 50, 18, 799, DateTimeKind.Utc).AddTicks(6007));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Beds",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 26, 13, 55, 26, 475, DateTimeKind.Utc).AddTicks(7077),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 25, 20, 50, 18, 799, DateTimeKind.Utc).AddTicks(4256));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Adventures",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 26, 13, 55, 26, 475, DateTimeKind.Utc).AddTicks(5291),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 25, 20, 50, 18, 799, DateTimeKind.Utc).AddTicks(2337));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AdventureCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 26, 13, 55, 26, 475, DateTimeKind.Utc).AddTicks(3171),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 25, 20, 50, 18, 799, DateTimeKind.Utc).AddTicks(24));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Workers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 25, 20, 50, 18, 801, DateTimeKind.Utc).AddTicks(2470),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 26, 13, 55, 26, 477, DateTimeKind.Utc).AddTicks(4825));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 25, 20, 50, 18, 801, DateTimeKind.Utc).AddTicks(611),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 26, 13, 55, 26, 477, DateTimeKind.Utc).AddTicks(3156));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Settings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 25, 20, 50, 18, 800, DateTimeKind.Utc).AddTicks(8943),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 26, 13, 55, 26, 477, DateTimeKind.Utc).AddTicks(1490));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 25, 20, 50, 18, 800, DateTimeKind.Utc).AddTicks(6973),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 26, 13, 55, 26, 476, DateTimeKind.Utc).AddTicks(8938));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 25, 20, 50, 18, 800, DateTimeKind.Utc).AddTicks(4681),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 26, 13, 55, 26, 476, DateTimeKind.Utc).AddTicks(7171));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Positions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 25, 20, 50, 18, 800, DateTimeKind.Utc).AddTicks(3015),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 26, 13, 55, 26, 476, DateTimeKind.Utc).AddTicks(5654));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GuestReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 25, 20, 50, 18, 800, DateTimeKind.Utc).AddTicks(1213),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 26, 13, 55, 26, 476, DateTimeKind.Utc).AddTicks(3995));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Feature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 25, 20, 50, 18, 799, DateTimeKind.Utc).AddTicks(9556),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 26, 13, 55, 26, 476, DateTimeKind.Utc).AddTicks(2423));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Eats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 25, 20, 50, 18, 799, DateTimeKind.Utc).AddTicks(7656),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 26, 13, 55, 26, 476, DateTimeKind.Utc).AddTicks(619));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EatCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 25, 20, 50, 18, 799, DateTimeKind.Utc).AddTicks(6007),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 26, 13, 55, 26, 475, DateTimeKind.Utc).AddTicks(8720));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Beds",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 25, 20, 50, 18, 799, DateTimeKind.Utc).AddTicks(4256),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 26, 13, 55, 26, 475, DateTimeKind.Utc).AddTicks(7077));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Adventures",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 25, 20, 50, 18, 799, DateTimeKind.Utc).AddTicks(2337),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 26, 13, 55, 26, 475, DateTimeKind.Utc).AddTicks(5291));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AdventureCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 25, 20, 50, 18, 799, DateTimeKind.Utc).AddTicks(24),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 26, 13, 55, 26, 475, DateTimeKind.Utc).AddTicks(3171));
        }
    }
}
