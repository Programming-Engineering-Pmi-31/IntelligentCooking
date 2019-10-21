using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntelligentCooking.DAL.Migrations
{
    public partial class CalsRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Proteins",
                table: "Dishes",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Fats",
                table: "Dishes",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Carbohydrates",
                table: "Dishes",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Calories",
                table: "Dishes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Calories", "Time" },
                values: new object[] { 400.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Calories", "Time" },
                values: new object[] { 255.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Calories", "Time" },
                values: new object[] { 199.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Calories", "Time" },
                values: new object[] { 234.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Calories", "Time" },
                values: new object[] { 378.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Calories", "Time" },
                values: new object[] { 268.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Calories", "Time" },
                values: new object[] { 345.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Calories", "Time" },
                values: new object[] { 390.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Calories", "Time" },
                values: new object[] { 390.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Proteins",
                table: "Dishes",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "Fats",
                table: "Dishes",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "Carbohydrates",
                table: "Dishes",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "Calories",
                table: "Dishes",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Calories", "Time" },
                values: new object[] { 400, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Calories", "Time" },
                values: new object[] { 255, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Calories", "Time" },
                values: new object[] { 199, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Calories", "Time" },
                values: new object[] { 234, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Calories", "Time" },
                values: new object[] { 378, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Calories", "Time" },
                values: new object[] { 268, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Calories", "Time" },
                values: new object[] { 345, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Calories", "Time" },
                values: new object[] { 390, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Calories", "Time" },
                values: new object[] { 390, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
