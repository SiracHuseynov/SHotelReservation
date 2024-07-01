using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHotel.Data.Migrations
{
    /// <inheritdoc />
    public partial class SettingsTableCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Workers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 13, 0, 26, 45, 680, DateTimeKind.Utc).AddTicks(1838),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 12, 18, 9, 47, 630, DateTimeKind.Utc).AddTicks(103));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 13, 0, 26, 45, 680, DateTimeKind.Utc).AddTicks(144),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 12, 18, 9, 47, 629, DateTimeKind.Utc).AddTicks(8542));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Positions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 13, 0, 26, 45, 679, DateTimeKind.Utc).AddTicks(8620),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 12, 18, 9, 47, 629, DateTimeKind.Utc).AddTicks(6858));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GuestReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 13, 0, 26, 45, 679, DateTimeKind.Utc).AddTicks(6943),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 12, 18, 9, 47, 629, DateTimeKind.Utc).AddTicks(481));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Feature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 13, 0, 26, 45, 679, DateTimeKind.Utc).AddTicks(5410),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 12, 18, 9, 47, 628, DateTimeKind.Utc).AddTicks(8989));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Eats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 13, 0, 26, 45, 679, DateTimeKind.Utc).AddTicks(3554),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 12, 18, 9, 47, 628, DateTimeKind.Utc).AddTicks(7251));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EatCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 13, 0, 26, 45, 679, DateTimeKind.Utc).AddTicks(1707),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 12, 18, 9, 47, 628, DateTimeKind.Utc).AddTicks(5563));

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Workers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 12, 18, 9, 47, 630, DateTimeKind.Utc).AddTicks(103),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 13, 0, 26, 45, 680, DateTimeKind.Utc).AddTicks(1838));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 12, 18, 9, 47, 629, DateTimeKind.Utc).AddTicks(8542),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 13, 0, 26, 45, 680, DateTimeKind.Utc).AddTicks(144));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Positions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 12, 18, 9, 47, 629, DateTimeKind.Utc).AddTicks(6858),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 13, 0, 26, 45, 679, DateTimeKind.Utc).AddTicks(8620));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GuestReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 12, 18, 9, 47, 629, DateTimeKind.Utc).AddTicks(481),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 13, 0, 26, 45, 679, DateTimeKind.Utc).AddTicks(6943));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Feature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 12, 18, 9, 47, 628, DateTimeKind.Utc).AddTicks(8989),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 13, 0, 26, 45, 679, DateTimeKind.Utc).AddTicks(5410));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Eats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 12, 18, 9, 47, 628, DateTimeKind.Utc).AddTicks(7251),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 13, 0, 26, 45, 679, DateTimeKind.Utc).AddTicks(3554));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EatCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 12, 18, 9, 47, 628, DateTimeKind.Utc).AddTicks(5563),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 13, 0, 26, 45, 679, DateTimeKind.Utc).AddTicks(1707));
        }
    }
}
