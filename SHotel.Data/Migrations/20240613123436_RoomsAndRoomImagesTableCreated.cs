using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHotel.Data.Migrations
{
    /// <inheritdoc />
    public partial class RoomsAndRoomImagesTableCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Workers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 13, 16, 34, 35, 837, DateTimeKind.Utc).AddTicks(1665),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 13, 12, 36, 32, 29, DateTimeKind.Utc).AddTicks(9875));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 13, 16, 34, 35, 837, DateTimeKind.Utc).AddTicks(12),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 13, 12, 36, 32, 29, DateTimeKind.Utc).AddTicks(8231));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Positions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 13, 16, 34, 35, 836, DateTimeKind.Utc).AddTicks(6568),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 13, 12, 36, 32, 29, DateTimeKind.Utc).AddTicks(6816));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GuestReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 13, 16, 34, 35, 836, DateTimeKind.Utc).AddTicks(4962),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 13, 12, 36, 32, 29, DateTimeKind.Utc).AddTicks(5020));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Feature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 13, 16, 34, 35, 836, DateTimeKind.Utc).AddTicks(3395),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 13, 12, 36, 32, 29, DateTimeKind.Utc).AddTicks(3419));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Eats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 13, 16, 34, 35, 836, DateTimeKind.Utc).AddTicks(1609),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 13, 12, 36, 32, 29, DateTimeKind.Utc).AddTicks(1554));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EatCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 13, 16, 34, 35, 836, DateTimeKind.Utc).AddTicks(62),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 13, 12, 36, 32, 28, DateTimeKind.Utc).AddTicks(9942));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Beds",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 13, 16, 34, 35, 835, DateTimeKind.Utc).AddTicks(8312),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 13, 12, 36, 32, 28, DateTimeKind.Utc).AddTicks(8103));

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BedId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PersonCount = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    View = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 6, 13, 16, 34, 35, 836, DateTimeKind.Utc).AddTicks(8102)),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Beds_BedId",
                        column: x => x.BedId,
                        principalTable: "Beds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPoster = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomImages_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomImages_RoomId",
                table: "RoomImages",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_BedId",
                table: "Rooms",
                column: "BedId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomImages");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Workers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 13, 12, 36, 32, 29, DateTimeKind.Utc).AddTicks(9875),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 13, 16, 34, 35, 837, DateTimeKind.Utc).AddTicks(1665));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 13, 12, 36, 32, 29, DateTimeKind.Utc).AddTicks(8231),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 13, 16, 34, 35, 837, DateTimeKind.Utc).AddTicks(12));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Positions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 13, 12, 36, 32, 29, DateTimeKind.Utc).AddTicks(6816),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 13, 16, 34, 35, 836, DateTimeKind.Utc).AddTicks(6568));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GuestReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 13, 12, 36, 32, 29, DateTimeKind.Utc).AddTicks(5020),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 13, 16, 34, 35, 836, DateTimeKind.Utc).AddTicks(4962));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Feature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 13, 12, 36, 32, 29, DateTimeKind.Utc).AddTicks(3419),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 13, 16, 34, 35, 836, DateTimeKind.Utc).AddTicks(3395));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Eats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 13, 12, 36, 32, 29, DateTimeKind.Utc).AddTicks(1554),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 13, 16, 34, 35, 836, DateTimeKind.Utc).AddTicks(1609));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EatCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 13, 12, 36, 32, 28, DateTimeKind.Utc).AddTicks(9942),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 13, 16, 34, 35, 836, DateTimeKind.Utc).AddTicks(62));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Beds",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 13, 12, 36, 32, 28, DateTimeKind.Utc).AddTicks(8103),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 13, 16, 34, 35, 835, DateTimeKind.Utc).AddTicks(8312));
        }
    }
}
