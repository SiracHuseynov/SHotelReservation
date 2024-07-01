using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHotel.Data.Migrations
{
    /// <inheritdoc />
    public partial class EatAndEatCategoryCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Workers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 12, 18, 9, 47, 630, DateTimeKind.Utc).AddTicks(103),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 12, 14, 7, 32, 13, DateTimeKind.Utc).AddTicks(1964));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 12, 18, 9, 47, 629, DateTimeKind.Utc).AddTicks(8542),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 12, 14, 7, 32, 13, DateTimeKind.Utc).AddTicks(287));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Positions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 12, 18, 9, 47, 629, DateTimeKind.Utc).AddTicks(6858),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 12, 14, 7, 32, 12, DateTimeKind.Utc).AddTicks(8692));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GuestReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 12, 18, 9, 47, 629, DateTimeKind.Utc).AddTicks(481),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 12, 14, 7, 32, 12, DateTimeKind.Utc).AddTicks(6862));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Feature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 12, 18, 9, 47, 628, DateTimeKind.Utc).AddTicks(8989),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 12, 14, 7, 32, 12, DateTimeKind.Utc).AddTicks(4642));

            migrationBuilder.CreateTable(
                name: "EatCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 6, 12, 18, 9, 47, 628, DateTimeKind.Utc).AddTicks(5563)),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EatCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Eats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EatCategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 6, 12, 18, 9, 47, 628, DateTimeKind.Utc).AddTicks(7251)),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eats_EatCategories_EatCategoryId",
                        column: x => x.EatCategoryId,
                        principalTable: "EatCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Eats_EatCategoryId",
                table: "Eats",
                column: "EatCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eats");

            migrationBuilder.DropTable(
                name: "EatCategories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Workers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 12, 14, 7, 32, 13, DateTimeKind.Utc).AddTicks(1964),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 12, 18, 9, 47, 630, DateTimeKind.Utc).AddTicks(103));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 12, 14, 7, 32, 13, DateTimeKind.Utc).AddTicks(287),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 12, 18, 9, 47, 629, DateTimeKind.Utc).AddTicks(8542));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Positions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 12, 14, 7, 32, 12, DateTimeKind.Utc).AddTicks(8692),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 12, 18, 9, 47, 629, DateTimeKind.Utc).AddTicks(6858));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GuestReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 12, 14, 7, 32, 12, DateTimeKind.Utc).AddTicks(6862),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 12, 18, 9, 47, 629, DateTimeKind.Utc).AddTicks(481));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Feature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 12, 14, 7, 32, 12, DateTimeKind.Utc).AddTicks(4642),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 12, 18, 9, 47, 628, DateTimeKind.Utc).AddTicks(8989));
        }
    }
}
