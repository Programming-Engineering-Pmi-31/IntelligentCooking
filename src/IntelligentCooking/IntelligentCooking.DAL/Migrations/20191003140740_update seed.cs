using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntelligentCooking.DAL.Migrations
{
    public partial class updateseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Sweets");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Soup");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Breakfast");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 6, "Quick and Easy" },
                    { 7, "Vegetarian" }
                });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Calories", "Carbohydrates", "Fats", "Proteins", "Stars" },
                values: new object[] { 400, 32.0, 1.0, 32.0, 4 });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Calories", "Carbohydrates", "Fats", "Proteins" },
                values: new object[] { 255, 15.0, 10.0, 8.0 });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Calories", "Carbohydrates", "Fats", "Proteins" },
                values: new object[] { 199, 10.0, 7.0, 9.0 });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Calories", "Carbohydrates", "Fats", "Proteins" },
                values: new object[] { 234, 13.0, 12.0, 20.0 });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Calories", "Carbohydrates", "Fats", "Proteins" },
                values: new object[] { 378, 15.0, 10.0, 12.0 });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Calories", "Carbohydrates", "Description", "Fats", "ImageUrl", "Name", "Proteins", "Recipe", "Servings", "Stars", "Time" },
                values: new object[,]
                {
                    { 6, 268, 16.0, "These Easy Veggie Quesadillas are 100% customizable with whatever veggies you have on hand or happen to love most.  See notes above for possible ingredient variations!", 13.0, "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Healthy-Veggie-Quesadillas-Recipe-6-2.jpg", "Veggie quesadillas", 18.0, "Heat 1 tablespoon olive oil over medium-high heat in a large non-stick sauté pan.  Add sweet potato and sauté for 5-6 minutes, stirring occasionally, until cooked through.  Transfer to a separate plate and set aside. Add the remaining 1 tablespoon oil to the pan.  Add the veggies and jalapeño, and sauté for 4-5 minutes.  Stir in the cooked sweet potato, black beans, cumin, chili powder, a generous pinch of salt and black pepper, and sauté for 2 more minutes.  Taste and add more salt, pepper and/or cumin if needed.  Transfer the mixture to a large bowl and set aside.  Rinse (or just wipe off) the sauté pan until it is clean. Return the sauté pan to the stove, and reduce heat to medium.  Place a tortilla* in the center of the pan and immediately sprinkle your desired amount of cheese evenly over the surface of the tortilla.  Add a few large spoonfuls (about 1 cup) of the veggie mixture on one half of the tortilla, then sprinkle on some cilantro.  Fold the other side of the tortilla over to create a half moon.  Continue cooking for another 30 seconds or so, or until the bottom of the tortilla is crisp and golden.  (Just lift it up and take a peek to see when it’s ready to go.)  Then carefully flip the tortilla over and cook it for an additional 30-60 seconds on the second side. Transfer to a serving plate*, slice into triangles, then repeat with the remaining ingredients. Serve warm, along with your favorite salsa, guacamole and/or sour cream for dipping.", 7, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 345, 15.0, "The beauty of this salad is that it keeps really well in the fridge, so feel free to prep it in advance if you’d like! ", 13.0, "https://www.gimmesomeoven.com/wp-content/uploads/2019/07/Roasted-Broccoli-Chickpea-and-Farro-Bowls-Recipe-2-2.jpg", "Roasted Broccoli and Farro Bowls", 18.0, "Roast the broccoli.  I detailed how to do this in yesterday’s post.  Basically, toss in oil, season with S&P and roast over high heat! Cook the farro.  On the stovetop, in veggie stock (instead of water) for extra flavor. Make the dressing.  Whisk all of the ingredients together in a small bowl (or shake together in a mason jar) until combined. Toss everything together.  Then in a large bowl, combine the broccoli, farro, arugula, chickpeas, almonds and dressing.  Toss to combine. Serve or refrigerate for later.  Then serve it up immediately, or transfer the salad to a sealed container and refrigerate for up to 3 days.", 12, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 390, 15.0, "This easy apple crisp (apple crumble) recipe is made with a warm cinnamon apple filling and an irresistible buttery crunchy crumble topping.  Plus this no-fuss version takes less than 20 minutes to prep — no apple peeling required!", 14.0, "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Easy-Apple-Crisp-Recipe-1-3.jpg", "Apple Crisp", 19.0, "Make the filling. Toss together the apples, lemon juice, brown sugar, flour and cinnamon until combined.  Then spread everything out in an even layer in a 9 x 13-inch baking dish. Make the topping.  Stir together the oats, flour, brown sugar, pecans, cinnamon and salt until combined.  Then drizzle with the melted butter and toss together until the dry ingredients are moistened, yet still nice and clumpy (not over-mixed). Bake. Sprinkle the topping over the apples, then pop the pan in the oven and bake for about 40-50 minutes, or until the filling is bubbly and the topping is nice and crisp. Serve.  Dish it up while the apple crisp is nice and warm, topped with a generous scoop of vanilla ice cream", 12, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 390, 18.0, "This Thai Basil Beef Noodle Stir-Fry recipe is easy to make and tossed with the best savory Thai basil sauce.  Feel free to sub in chicken, pork, shrimp or crispy tofu in place of the beef if you would like!", 15.0, "https://www.gimmesomeoven.com/wp-content/uploads/2019/06/Thai-Basil-Beef-Noodle-Stir-Fry-Recipe-2.jpg", "Thai Basil Beef Noodle Stir-Fry", 17.0, "Prep the sauce. Whisk the sauce ingredients together in a small bowl or measuring cup until combined. Prep the noodles.  Cook the noodles according to package instructions until they are al dente.  Then drain and set aside until ready to use. Sear the beef.  Heat some cooking oil in a large sauté pan or wok over medium-high heat.  Cook the beef briefly until it is browned on both sides.  Then transfer it to a separate (clean) plate, and return the pan to the heat. Cook the veggies.  Give the veggies a quick sauté until they are cooked through. Combine everything together.  Then add the cooked noodles, sauce, beef, and Thai basil to the pan, and toss until everything is coated evenly with the sauce. Serve warm.  Serve immediately while the stir-fry is nice and hot, garnished with any of your desired toppings.", 12, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "sweets");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "soup");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "breakfast");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Calories", "Carbohydrates", "Fats", "Proteins", "Stars" },
                values: new object[] { null, null, null, null, 1 });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Calories", "Carbohydrates", "Fats", "Proteins" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Calories", "Carbohydrates", "Fats", "Proteins" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Calories", "Carbohydrates", "Fats", "Proteins" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Calories", "Carbohydrates", "Fats", "Proteins" },
                values: new object[] { null, null, null, null });
        }
    }
}
