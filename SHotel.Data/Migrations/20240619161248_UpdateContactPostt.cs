using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHotel.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateContactPostt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Workers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 20, 12, 47, 828, DateTimeKind.Utc).AddTicks(7153),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 19, 49, 24, 659, DateTimeKind.Utc).AddTicks(6330));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 20, 12, 47, 828, DateTimeKind.Utc).AddTicks(5384),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 19, 49, 24, 659, DateTimeKind.Utc).AddTicks(4592));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Settings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 20, 12, 47, 828, DateTimeKind.Utc).AddTicks(3697),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 19, 49, 24, 659, DateTimeKind.Utc).AddTicks(2868));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 20, 12, 47, 828, DateTimeKind.Utc).AddTicks(1707),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 19, 49, 24, 659, DateTimeKind.Utc).AddTicks(978));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 20, 12, 47, 827, DateTimeKind.Utc).AddTicks(9833),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 19, 49, 24, 658, DateTimeKind.Utc).AddTicks(9062));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Positions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 20, 12, 47, 827, DateTimeKind.Utc).AddTicks(8230),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 19, 49, 24, 658, DateTimeKind.Utc).AddTicks(7331));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GuestReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 20, 12, 47, 827, DateTimeKind.Utc).AddTicks(6420),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 19, 49, 24, 658, DateTimeKind.Utc).AddTicks(5479));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Feature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 20, 12, 47, 827, DateTimeKind.Utc).AddTicks(4694),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 19, 49, 24, 658, DateTimeKind.Utc).AddTicks(3558));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Eats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 20, 12, 47, 827, DateTimeKind.Utc).AddTicks(2821),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 19, 49, 24, 658, DateTimeKind.Utc).AddTicks(1649));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EatCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 20, 12, 47, 827, DateTimeKind.Utc).AddTicks(1200),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 19, 49, 24, 658, DateTimeKind.Utc).AddTicks(18));

            migrationBuilder.AlterColumn<string>(
                name: "Answer",
                table: "ContactPosts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Beds",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 20, 12, 47, 826, DateTimeKind.Utc).AddTicks(9537),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 19, 49, 24, 657, DateTimeKind.Utc).AddTicks(8350));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Adventures",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 20, 12, 47, 826, DateTimeKind.Utc).AddTicks(7740),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 19, 49, 24, 657, DateTimeKind.Utc).AddTicks(6496));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AdventureCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 20, 12, 47, 826, DateTimeKind.Utc).AddTicks(5330),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 19, 49, 24, 657, DateTimeKind.Utc).AddTicks(4010));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Workers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 19, 49, 24, 659, DateTimeKind.Utc).AddTicks(6330),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 20, 12, 47, 828, DateTimeKind.Utc).AddTicks(7153));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 19, 49, 24, 659, DateTimeKind.Utc).AddTicks(4592),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 20, 12, 47, 828, DateTimeKind.Utc).AddTicks(5384));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Settings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 19, 49, 24, 659, DateTimeKind.Utc).AddTicks(2868),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 20, 12, 47, 828, DateTimeKind.Utc).AddTicks(3697));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 19, 49, 24, 659, DateTimeKind.Utc).AddTicks(978),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 20, 12, 47, 828, DateTimeKind.Utc).AddTicks(1707));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 19, 49, 24, 658, DateTimeKind.Utc).AddTicks(9062),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 20, 12, 47, 827, DateTimeKind.Utc).AddTicks(9833));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Positions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 19, 49, 24, 658, DateTimeKind.Utc).AddTicks(7331),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 20, 12, 47, 827, DateTimeKind.Utc).AddTicks(8230));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GuestReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 19, 49, 24, 658, DateTimeKind.Utc).AddTicks(5479),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 20, 12, 47, 827, DateTimeKind.Utc).AddTicks(6420));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Feature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 19, 49, 24, 658, DateTimeKind.Utc).AddTicks(3558),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 20, 12, 47, 827, DateTimeKind.Utc).AddTicks(4694));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Eats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 19, 49, 24, 658, DateTimeKind.Utc).AddTicks(1649),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 20, 12, 47, 827, DateTimeKind.Utc).AddTicks(2821));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EatCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 19, 49, 24, 658, DateTimeKind.Utc).AddTicks(18),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 20, 12, 47, 827, DateTimeKind.Utc).AddTicks(1200));

            migrationBuilder.AlterColumn<string>(
                name: "Answer",
                table: "ContactPosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Beds",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 19, 49, 24, 657, DateTimeKind.Utc).AddTicks(8350),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 20, 12, 47, 826, DateTimeKind.Utc).AddTicks(9537));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Adventures",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 19, 49, 24, 657, DateTimeKind.Utc).AddTicks(6496),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 20, 12, 47, 826, DateTimeKind.Utc).AddTicks(7740));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AdventureCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 19, 49, 24, 657, DateTimeKind.Utc).AddTicks(4010),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 20, 12, 47, 826, DateTimeKind.Utc).AddTicks(5330));
        }
    }
}
