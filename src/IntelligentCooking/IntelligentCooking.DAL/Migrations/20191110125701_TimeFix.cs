using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntelligentCooking.DAL.Migrations
{
    public partial class TimeFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Time",
                table: "Dishes",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://ukrhealth.net/wp-content/uploads/2018/01/shutterstock_361496144-696x464.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://www.gimmesomeoven.com/wp-content/uploads/2015/02/The-Best-Butternut-Squash-Soup-Recipe-1.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://www.englishclub.com/images/vocabulary/food/italian/italian-food-640.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://www.untoldmorsels.com/wp-content/uploads/2018/08/thai-food-culture.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://olo-images-live.imgix.net/3a/3afe98ddcf4643a0b20c068b2c59f2ce.jpg?auto=format%2Ccompress&q=60&cs=tinysrgb&w=500&h=333&fit=fill&fm=png32&bg=transparent&s=862b0bcde81b3d6190fb8465f031a5cf");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Healthy-Veggie-Quesadillas-Recipe-6-2.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://static.standard.co.uk/s3fs-public/thumbnails/image/2019/05/14/15/vegetarian-meal-14-05-19-0.jpg?w968");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new TimeSpan(0, 0, 35, 0, 0));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Time" },
                values: new object[] { "Thai Chicken Wild Rice Soup", new TimeSpan(0, 0, 35, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: new TimeSpan(0, 1, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Time",
                value: new TimeSpan(0, 0, 50, 0, 0));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Time",
                value: new TimeSpan(0, 0, 30, 0, 0));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 6,
                column: "Time",
                value: new TimeSpan(0, 0, 40, 0, 0));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 7,
                column: "Time",
                value: new TimeSpan(0, 0, 45, 0, 0));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 8,
                column: "Time",
                value: new TimeSpan(0, 0, 20, 0, 0));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 9,
                column: "Time",
                value: new TimeSpan(0, 1, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumns: new[] { "DishId", "Priority" },
                keyValues: new object[] { 2, 1 },
                column: "Url",
                value: "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Thai-Chicken-Wild-Rice-Soup-Recipe-1.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumns: new[] { "DishId", "Priority" },
                keyValues: new object[] { 3, 1 },
                column: "Url",
                value: "https://www.gimmesomeoven.com/wp-content/uploads/2019/08/Healthy-Broccoli-Chicken-Casserole-Recipe-6-1.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumns: new[] { "DishId", "Priority" },
                keyValues: new object[] { 4, 1 },
                column: "Url",
                value: "https://www.gimmesomeoven.com/wp-content/uploads/2015/02/The-Best-Butternut-Squash-Soup-Recipe-1.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumns: new[] { "DishId", "Priority" },
                keyValues: new object[] { 5, 1 },
                column: "Url",
                value: "https://www.gimmesomeoven.com/wp-content/uploads/2018/09/Healthy-Pumpkin-Muffins-Recipe-Gluten-Free-Vegan-2.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumns: new[] { "DishId", "Priority" },
                keyValues: new object[] { 6, 1 },
                column: "Url",
                value: "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Healthy-Veggie-Quesadillas-Recipe-6-2.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumns: new[] { "DishId", "Priority" },
                keyValues: new object[] { 7, 1 },
                column: "Url",
                value: "https://www.gimmesomeoven.com/wp-content/uploads/2019/07/Roasted-Broccoli-Chickpea-and-Farro-Bowls-Recipe-2-2.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumns: new[] { "DishId", "Priority" },
                keyValues: new object[] { 8, 1 },
                column: "Url",
                value: "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Easy-Apple-Crisp-Recipe-1-3.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumns: new[] { "DishId", "Priority" },
                keyValues: new object[] { 9, 1 },
                column: "Url",
                value: "https://www.gimmesomeoven.com/wp-content/uploads/2019/06/Thai-Basil-Beef-Noodle-Stir-Fry-Recipe-2.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "Dishes",
                nullable: false,
                oldClrType: typeof(TimeSpan));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Perfect-Buttermilk-Pancakes-Recipe-1-1100x1650.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Perfect-Buttermilk-Pancakes-Recipe-1-1100x1650.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Perfect-Buttermilk-Pancakes-Recipe-1-1100x1650.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Perfect-Buttermilk-Pancakes-Recipe-1-1100x1650.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Perfect-Buttermilk-Pancakes-Recipe-1-1100x1650.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Perfect-Buttermilk-Pancakes-Recipe-1-1100x1650.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Perfect-Buttermilk-Pancakes-Recipe-1-1100x1650.jpg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Time" },
                values: new object[] { "Thai Chicken Wild Rice", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Time",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Time",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 6,
                column: "Time",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 7,
                column: "Time",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 8,
                column: "Time",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 9,
                column: "Time",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumns: new[] { "DishId", "Priority" },
                keyValues: new object[] { 2, 1 },
                column: "Url",
                value: "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Perfect-Buttermilk-Pancakes-Recipe-1-1100x1650.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumns: new[] { "DishId", "Priority" },
                keyValues: new object[] { 3, 1 },
                column: "Url",
                value: "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Perfect-Buttermilk-Pancakes-Recipe-1-1100x1650.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumns: new[] { "DishId", "Priority" },
                keyValues: new object[] { 4, 1 },
                column: "Url",
                value: "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Perfect-Buttermilk-Pancakes-Recipe-1-1100x1650.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumns: new[] { "DishId", "Priority" },
                keyValues: new object[] { 5, 1 },
                column: "Url",
                value: "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Perfect-Buttermilk-Pancakes-Recipe-1-1100x1650.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumns: new[] { "DishId", "Priority" },
                keyValues: new object[] { 6, 1 },
                column: "Url",
                value: "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Perfect-Buttermilk-Pancakes-Recipe-1-1100x1650.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumns: new[] { "DishId", "Priority" },
                keyValues: new object[] { 7, 1 },
                column: "Url",
                value: "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Perfect-Buttermilk-Pancakes-Recipe-1-1100x1650.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumns: new[] { "DishId", "Priority" },
                keyValues: new object[] { 8, 1 },
                column: "Url",
                value: "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Perfect-Buttermilk-Pancakes-Recipe-1-1100x1650.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumns: new[] { "DishId", "Priority" },
                keyValues: new object[] { 9, 1 },
                column: "Url",
                value: "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Perfect-Buttermilk-Pancakes-Recipe-1-1100x1650.jpg");
        }
    }
}
