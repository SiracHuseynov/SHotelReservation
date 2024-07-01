using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHotel.Data.Migrations
{
    /// <inheritdoc />
    public partial class CommentCreatedAndRelationAdventureAndAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Workers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 371, DateTimeKind.Utc).AddTicks(2573),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 0, 10, 16, 277, DateTimeKind.Utc).AddTicks(6613));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 371, DateTimeKind.Utc).AddTicks(791),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 0, 10, 16, 277, DateTimeKind.Utc).AddTicks(4863));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Settings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 370, DateTimeKind.Utc).AddTicks(9161),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 0, 10, 16, 277, DateTimeKind.Utc).AddTicks(3154));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 370, DateTimeKind.Utc).AddTicks(6946),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 0, 10, 16, 277, DateTimeKind.Utc).AddTicks(1159));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 370, DateTimeKind.Utc).AddTicks(5060),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 0, 10, 16, 276, DateTimeKind.Utc).AddTicks(9095));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Positions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 370, DateTimeKind.Utc).AddTicks(3496),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 0, 10, 16, 276, DateTimeKind.Utc).AddTicks(7431));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GuestReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 370, DateTimeKind.Utc).AddTicks(1716),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 0, 10, 16, 276, DateTimeKind.Utc).AddTicks(5619));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Feature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 369, DateTimeKind.Utc).AddTicks(9982),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 0, 10, 16, 276, DateTimeKind.Utc).AddTicks(3788));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Eats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 369, DateTimeKind.Utc).AddTicks(7872),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 0, 10, 16, 276, DateTimeKind.Utc).AddTicks(1824));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EatCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 369, DateTimeKind.Utc).AddTicks(5961),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 0, 10, 16, 275, DateTimeKind.Utc).AddTicks(9898));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Beds",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 369, DateTimeKind.Utc).AddTicks(4197),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 0, 10, 16, 275, DateTimeKind.Utc).AddTicks(8138));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Adventures",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 369, DateTimeKind.Utc).AddTicks(2434),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 0, 10, 16, 275, DateTimeKind.Utc).AddTicks(6271));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AdventureCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 368, DateTimeKind.Utc).AddTicks(9959),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 0, 10, 16, 275, DateTimeKind.Utc).AddTicks(3735));

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdventureId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Adventures_AdventureId",
                        column: x => x.AdventureId,
                        principalTable: "Adventures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AdventureId",
                table: "Comments",
                column: "AdventureId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Workers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 0, 10, 16, 277, DateTimeKind.Utc).AddTicks(6613),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 371, DateTimeKind.Utc).AddTicks(2573));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 0, 10, 16, 277, DateTimeKind.Utc).AddTicks(4863),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 371, DateTimeKind.Utc).AddTicks(791));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Settings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 0, 10, 16, 277, DateTimeKind.Utc).AddTicks(3154),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 370, DateTimeKind.Utc).AddTicks(9161));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 0, 10, 16, 277, DateTimeKind.Utc).AddTicks(1159),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 370, DateTimeKind.Utc).AddTicks(6946));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 0, 10, 16, 276, DateTimeKind.Utc).AddTicks(9095),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 370, DateTimeKind.Utc).AddTicks(5060));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Positions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 0, 10, 16, 276, DateTimeKind.Utc).AddTicks(7431),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 370, DateTimeKind.Utc).AddTicks(3496));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GuestReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 0, 10, 16, 276, DateTimeKind.Utc).AddTicks(5619),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 370, DateTimeKind.Utc).AddTicks(1716));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Feature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 0, 10, 16, 276, DateTimeKind.Utc).AddTicks(3788),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 369, DateTimeKind.Utc).AddTicks(9982));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Eats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 0, 10, 16, 276, DateTimeKind.Utc).AddTicks(1824),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 369, DateTimeKind.Utc).AddTicks(7872));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EatCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 0, 10, 16, 275, DateTimeKind.Utc).AddTicks(9898),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 369, DateTimeKind.Utc).AddTicks(5961));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Beds",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 0, 10, 16, 275, DateTimeKind.Utc).AddTicks(8138),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 369, DateTimeKind.Utc).AddTicks(4197));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Adventures",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 0, 10, 16, 275, DateTimeKind.Utc).AddTicks(6271),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 369, DateTimeKind.Utc).AddTicks(2434));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AdventureCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 0, 10, 16, 275, DateTimeKind.Utc).AddTicks(3735),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 44, 43, 368, DateTimeKind.Utc).AddTicks(9959));
        }
    }
}
