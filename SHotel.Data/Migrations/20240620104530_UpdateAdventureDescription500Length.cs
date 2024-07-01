using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHotel.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAdventureDescription500Length : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Workers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 14, 45, 29, 515, DateTimeKind.Utc).AddTicks(4166),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 371, DateTimeKind.Utc).AddTicks(2573));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 14, 45, 29, 515, DateTimeKind.Utc).AddTicks(2332),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 371, DateTimeKind.Utc).AddTicks(791));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Settings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 14, 45, 29, 515, DateTimeKind.Utc).AddTicks(677),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 370, DateTimeKind.Utc).AddTicks(9161));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 14, 45, 29, 514, DateTimeKind.Utc).AddTicks(8744),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 370, DateTimeKind.Utc).AddTicks(6946));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 14, 45, 29, 514, DateTimeKind.Utc).AddTicks(6756),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 370, DateTimeKind.Utc).AddTicks(5060));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Positions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 14, 45, 29, 514, DateTimeKind.Utc).AddTicks(5152),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 370, DateTimeKind.Utc).AddTicks(3496));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GuestReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 14, 45, 29, 514, DateTimeKind.Utc).AddTicks(3267),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 370, DateTimeKind.Utc).AddTicks(1716));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Feature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 14, 45, 29, 514, DateTimeKind.Utc).AddTicks(1549),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 369, DateTimeKind.Utc).AddTicks(9982));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Eats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 14, 45, 29, 513, DateTimeKind.Utc).AddTicks(9515),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 369, DateTimeKind.Utc).AddTicks(7872));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EatCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 14, 45, 29, 513, DateTimeKind.Utc).AddTicks(7663),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 369, DateTimeKind.Utc).AddTicks(5961));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Beds",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 14, 45, 29, 513, DateTimeKind.Utc).AddTicks(5944),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 369, DateTimeKind.Utc).AddTicks(4197));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Adventures",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Adventures",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 14, 45, 29, 513, DateTimeKind.Utc).AddTicks(3951),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 369, DateTimeKind.Utc).AddTicks(2434));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AdventureCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 14, 45, 29, 513, DateTimeKind.Utc).AddTicks(1514),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 368, DateTimeKind.Utc).AddTicks(9959));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Workers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 371, DateTimeKind.Utc).AddTicks(2573),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 14, 45, 29, 515, DateTimeKind.Utc).AddTicks(4166));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 371, DateTimeKind.Utc).AddTicks(791),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 14, 45, 29, 515, DateTimeKind.Utc).AddTicks(2332));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Settings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 370, DateTimeKind.Utc).AddTicks(9161),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 14, 45, 29, 515, DateTimeKind.Utc).AddTicks(677));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 370, DateTimeKind.Utc).AddTicks(6946),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 14, 45, 29, 514, DateTimeKind.Utc).AddTicks(8744));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 370, DateTimeKind.Utc).AddTicks(5060),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 14, 45, 29, 514, DateTimeKind.Utc).AddTicks(6756));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Positions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 370, DateTimeKind.Utc).AddTicks(3496),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 14, 45, 29, 514, DateTimeKind.Utc).AddTicks(5152));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GuestReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 370, DateTimeKind.Utc).AddTicks(1716),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 14, 45, 29, 514, DateTimeKind.Utc).AddTicks(3267));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Feature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 369, DateTimeKind.Utc).AddTicks(9982),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 14, 45, 29, 514, DateTimeKind.Utc).AddTicks(1549));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Eats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 369, DateTimeKind.Utc).AddTicks(7872),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 14, 45, 29, 513, DateTimeKind.Utc).AddTicks(9515));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EatCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 369, DateTimeKind.Utc).AddTicks(5961),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 14, 45, 29, 513, DateTimeKind.Utc).AddTicks(7663));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Beds",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 369, DateTimeKind.Utc).AddTicks(4197),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 14, 45, 29, 513, DateTimeKind.Utc).AddTicks(5944));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Adventures",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Adventures",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 369, DateTimeKind.Utc).AddTicks(2434),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 14, 45, 29, 513, DateTimeKind.Utc).AddTicks(3951));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AdventureCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 368, DateTimeKind.Utc).AddTicks(9959),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 14, 45, 29, 513, DateTimeKind.Utc).AddTicks(1514));
        }
    }
}
