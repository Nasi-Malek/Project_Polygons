using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClassLibrary.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalculationRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num1 = table.Column<double>(type: "float", nullable: true),
                    Num2 = table.Column<double>(type: "float", nullable: true),
                    Operation = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Result = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculationRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerMove = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ComputerMove = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Result = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    GameDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserWinRate = table.Column<double>(type: "float", nullable: false),
                    ComputerWinRate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShapeRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShapeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Parameters = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Area = table.Column<double>(type: "float", nullable: false),
                    Perimeter = table.Column<double>(type: "float", nullable: false),
                    CalculationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShapeRecords", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CalculationRecords",
                columns: new[] { "Id", "Date", "IsDeleted", "Num1", "Num2", "Operation", "Result" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), false, 15.0, 5.0, "-", 10.0 },
                    { 2, new DateTime(2023, 1, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), false, 9.0, 3.0, "*", 27.0 },
                    { 3, new DateTime(2023, 1, 3, 12, 0, 0, 0, DateTimeKind.Unspecified), false, 20.0, 4.0, "/", 5.0 },
                    { 4, new DateTime(2023, 1, 3, 14, 0, 0, 0, DateTimeKind.Unspecified), false, 8.0, 2.0, "+", 10.0 }
                });

            migrationBuilder.InsertData(
                table: "GameRecords",
                columns: new[] { "Id", "ComputerMove", "ComputerWinRate", "GameDate", "PlayerMove", "Result", "UserWinRate" },
                values: new object[,]
                {
                    { 1, "Scissors", 0.0, new DateTime(2023, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "Rock", "Win", 100.0 },
                    { 2, "Rock", 25.0, new DateTime(2023, 1, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), "Paper", "Win", 75.0 },
                    { 3, "Rock", 50.0, new DateTime(2023, 1, 3, 12, 0, 0, 0, DateTimeKind.Unspecified), "Scissors", "Loss", 50.0 }
                });

            migrationBuilder.InsertData(
                table: "ShapeRecords",
                columns: new[] { "Id", "Area", "CalculationDate", "IsDeleted", "Parameters", "Perimeter", "ShapeName" },
                values: new object[,]
                {
                    { 1, 72.0, new DateTime(2023, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), false, "Width: 6, Height: 12", 36.0, "Rectangle" },
                    { 2, 40.0, new DateTime(2023, 1, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), false, "Base: 8, Height: 5", 26.0, "Parallelogram" },
                    { 3, 10.5, new DateTime(2023, 1, 3, 12, 0, 0, 0, DateTimeKind.Unspecified), false, "Base: 7, Height: 3", 20.0, "Triangle" },
                    { 4, 24.0, new DateTime(2023, 1, 3, 14, 0, 0, 0, DateTimeKind.Unspecified), false, "Diagonal1: 6, Diagonal2: 8", 28.0, "Rhombus" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculationRecords");

            migrationBuilder.DropTable(
                name: "GameRecords");

            migrationBuilder.DropTable(
                name: "ShapeRecords");
        }
    }
}
