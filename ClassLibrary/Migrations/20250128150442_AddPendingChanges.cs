using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AddPendingChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CalculationRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CalculationRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 1, 2, 12, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CalculationRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 1, 3, 12, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CalculationRecords",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2023, 1, 3, 14, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "GameRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "GameDate",
                value: new DateTime(2023, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "GameRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "GameDate",
                value: new DateTime(2023, 1, 2, 12, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "GameRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "GameDate",
                value: new DateTime(2023, 1, 3, 12, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ShapeRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "CalculationDate",
                value: new DateTime(2023, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ShapeRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "CalculationDate",
                value: new DateTime(2023, 1, 2, 12, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ShapeRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "CalculationDate",
                value: new DateTime(2023, 1, 3, 12, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ShapeRecords",
                keyColumn: "Id",
                keyValue: 4,
                column: "CalculationDate",
                value: new DateTime(2023, 1, 3, 14, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CalculationRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CalculationRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 1, 2, 12, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CalculationRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 1, 3, 12, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CalculationRecords",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2023, 1, 3, 14, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "GameRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "GameDate",
                value: new DateTime(2023, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "GameRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "GameDate",
                value: new DateTime(2023, 1, 2, 12, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "GameRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "GameDate",
                value: new DateTime(2023, 1, 3, 12, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ShapeRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "CalculationDate",
                value: new DateTime(2023, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ShapeRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "CalculationDate",
                value: new DateTime(2023, 1, 2, 12, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ShapeRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "CalculationDate",
                value: new DateTime(2023, 1, 3, 12, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ShapeRecords",
                keyColumn: "Id",
                keyValue: 4,
                column: "CalculationDate",
                value: new DateTime(2023, 1, 3, 14, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
