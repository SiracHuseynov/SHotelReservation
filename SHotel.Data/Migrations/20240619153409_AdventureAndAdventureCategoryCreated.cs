using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHotel.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdventureAndAdventureCategoryCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Workers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 19, 34, 9, 61, DateTimeKind.Utc).AddTicks(5440),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 4, 4, 59, 26, DateTimeKind.Utc).AddTicks(4637));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 19, 34, 9, 61, DateTimeKind.Utc).AddTicks(3765),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 4, 4, 59, 26, DateTimeKind.Utc).AddTicks(2927));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Settings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 19, 34, 9, 61, DateTimeKind.Utc).AddTicks(2065),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 4, 4, 59, 26, DateTimeKind.Utc).AddTicks(1189));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 19, 34, 9, 61, DateTimeKind.Utc).AddTicks(85),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 4, 4, 59, 25, DateTimeKind.Utc).AddTicks(9127));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 19, 34, 9, 60, DateTimeKind.Utc).AddTicks(8177),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 4, 4, 59, 25, DateTimeKind.Utc).AddTicks(7125));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Positions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 19, 34, 9, 60, DateTimeKind.Utc).AddTicks(6592),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 4, 4, 59, 25, DateTimeKind.Utc).AddTicks(5597));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GuestReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 19, 34, 9, 60, DateTimeKind.Utc).AddTicks(4853),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 4, 4, 59, 25, DateTimeKind.Utc).AddTicks(3821));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Feature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 19, 34, 9, 60, DateTimeKind.Utc).AddTicks(3073),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 4, 4, 59, 25, DateTimeKind.Utc).AddTicks(2146));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Eats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 19, 34, 9, 60, DateTimeKind.Utc).AddTicks(1153),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 4, 4, 59, 25, DateTimeKind.Utc).AddTicks(228));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EatCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 19, 34, 9, 59, DateTimeKind.Utc).AddTicks(9550),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 4, 4, 59, 24, DateTimeKind.Utc).AddTicks(8551));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Beds",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 19, 34, 9, 59, DateTimeKind.Utc).AddTicks(7932),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 4, 4, 59, 24, DateTimeKind.Utc).AddTicks(6486));

            migrationBuilder.CreateTable(
                name: "AdventureCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 6, 19, 19, 34, 9, 59, DateTimeKind.Utc).AddTicks(3852)),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdventureCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnsweredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnswerByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPosts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Adventures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdventureCategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 6, 19, 19, 34, 9, 59, DateTimeKind.Utc).AddTicks(6229)),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adventures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adventures_AdventureCategories_AdventureCategoryId",
                        column: x => x.AdventureCategoryId,
                        principalTable: "AdventureCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adventures_AdventureCategoryId",
                table: "Adventures",
                column: "AdventureCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adventures");

            migrationBuilder.DropTable(
                name: "ContactPosts");

            migrationBuilder.DropTable(
                name: "AdventureCategories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Workers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 4, 4, 59, 26, DateTimeKind.Utc).AddTicks(4637),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 19, 34, 9, 61, DateTimeKind.Utc).AddTicks(5440));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 4, 4, 59, 26, DateTimeKind.Utc).AddTicks(2927),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 19, 34, 9, 61, DateTimeKind.Utc).AddTicks(3765));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Settings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 4, 4, 59, 26, DateTimeKind.Utc).AddTicks(1189),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 19, 34, 9, 61, DateTimeKind.Utc).AddTicks(2065));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 4, 4, 59, 25, DateTimeKind.Utc).AddTicks(9127),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 19, 34, 9, 61, DateTimeKind.Utc).AddTicks(85));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 4, 4, 59, 25, DateTimeKind.Utc).AddTicks(7125),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 19, 34, 9, 60, DateTimeKind.Utc).AddTicks(8177));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Positions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 4, 4, 59, 25, DateTimeKind.Utc).AddTicks(5597),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 19, 34, 9, 60, DateTimeKind.Utc).AddTicks(6592));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GuestReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 4, 4, 59, 25, DateTimeKind.Utc).AddTicks(3821),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 19, 34, 9, 60, DateTimeKind.Utc).AddTicks(4853));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Feature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 4, 4, 59, 25, DateTimeKind.Utc).AddTicks(2146),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 19, 34, 9, 60, DateTimeKind.Utc).AddTicks(3073));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Eats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 4, 4, 59, 25, DateTimeKind.Utc).AddTicks(228),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 19, 34, 9, 60, DateTimeKind.Utc).AddTicks(1153));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EatCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 4, 4, 59, 24, DateTimeKind.Utc).AddTicks(8551),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 19, 34, 9, 59, DateTimeKind.Utc).AddTicks(9550));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Beds",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 4, 4, 59, 24, DateTimeKind.Utc).AddTicks(6486),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 19, 19, 34, 9, 59, DateTimeKind.Utc).AddTicks(7932));
        }
    }
}
