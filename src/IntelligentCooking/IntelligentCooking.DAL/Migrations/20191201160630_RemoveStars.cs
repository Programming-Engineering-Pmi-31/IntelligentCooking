using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntelligentCooking.DAL.Migrations
{
    public partial class RemoveStars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stars",
                table: "Dishes");

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Calories", "Carbohydrates", "Description", "Fats", "Name", "Proteins", "Recipe", "Servings", "Time" },
                values: new object[] { 10, 380.0, 14.0, "This easy Green Bean Casserole recipe is made from scratch with lightened-up ingredients, it’s nice and fresh and crispy, and it is full of the absolute best flavors.  Always a crowd fave!", 16.0, "Green Bean Casserole", 13.0, "Preheat oven.  Heat oven to 375°F. Trim, cut and briefly boil the green beans. Heat a large stockpot of water over high-heat until boiling. Meanwhile, trim and cut the green beans.  Then add the beans to the boiling water and cook for 3-5 minutes, depending on how crispy you like your green beans. (Keep in mind that the beans will cook more in the oven, so err on the side of undercooking them to your taste during this step.)  Then use a slotted spoon or large strainer to transfer the beans immediately into a large bowl of ice water, and give them a quick stir.  This will prevent them from cooking longer.  Set aside. Prepare your crispy onion topping.  Melt 1/2 tablespoon butter (or olive oil) in a large sauté pan over medium-high heat.  Add the onion and sauté for 2-3 minutes, stirring occasionally, until the onion is partially cooked but still holds its shape.  (You don’t want the onion to get too soft.)  Transfer the onion to a clean bowl.  Add the remaining 1/2 tablespoon butter to the sauté pan, along with the panko, and stir to combine.  Cook for 2-3 minutes, stirring constantly, until the panko is lightly golden.  Remove from heat, and transfer the panko to the bowl with the onions.  Add in the Parmesan, salt and pepper, and toss the onion mixture until evenly combined.  Set aside. Prepare your mushroom alfredo sauce.  Briefly rinse and dry the sauté pan.  Then return it to the stove.  Melt the butter over medium-high heat. Then add the mushrooms and sauté for 5 minutes, stirring occasionally, until lightly browned and soft.  Add the garlic and sauté for 1-2 more minutes, stirring occasionally, until fragrant.  Stir in the flour and sauté for 1 more minute, stirring occasionally.  Then add in the vegetable stock, and stir until the flour is evenly dissolved.  Add the milk and Parmesan, and stir to combine.  Continue cooking the sauce until it reaches a simmer and thickens.  Then remove from heat, and season with salt and pepper to taste. Put it all together!  Combine the green beans and mushroom alfredo sauce in the stockpot, and stir the green bean mixture until evenly combined.  Transfer to a 9 x 13-inch baking dish, and spread the green bean mixture out in an even layer.  Sprinkle evenly with the crispy onion topping mixture. Bake.  Then bake for about 25 minutes, or until the crispy onion topping is golden and crispy.  (Keep an eye on it so that it does not burn.  If it does start to char, simply lay a piece of aluminum foil on top of the casserole.) Serve warm.  Remove from the oven and serve warm, garnished with extra freshly-cracked black pepper (plus maybe some parsley) if you’d like.", 10, new TimeSpan(0, 1, 0, 0, 0) });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Calories", "Carbohydrates", "Description", "Fats", "Name", "Proteins", "Recipe", "Servings", "Time" },
                values: new object[] { 11, 120.0, 10.0, "Homemade mulled wine is incredibly easy to make on the stovetop (or simmer in the slow cooker), it’s easy to customize with your favorite spices and add-ins, and it is SO cozy and delicious.  Perfect for winter and holiday entertaining!", 0.0, "Mulled Wine", 2.0, "Combine all ingredients in a saucepan and heat until the mixture just barely reaches a simmer over medium-high heat.  (Avoid boiling — you don’t want to boil off the alcohol.)  Reduce heat to medium-low, cover, and let the wine simmer for at least 15 minutes or up to 3 hours. Strain, and serve warm with your desired garnishes.", 5, new TimeSpan(0, 0, 20, 0, 0) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.AddColumn<int>(
                name: "Stars",
                table: "Dishes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Stars",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Stars",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Stars",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Stars",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Stars",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 6,
                column: "Stars",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 7,
                column: "Stars",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 8,
                column: "Stars",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 9,
                column: "Stars",
                value: 1);
        }
    }
}
