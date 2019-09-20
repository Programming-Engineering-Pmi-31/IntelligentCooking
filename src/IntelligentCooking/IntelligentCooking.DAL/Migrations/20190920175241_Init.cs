using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntelligentCooking.DAL.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    DishId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    ImageUrl = table.Column<string>(nullable: false),
                    Recipe = table.Column<string>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    Servings = table.Column<int>(nullable: false),
                    Stars = table.Column<int>(nullable: false),
                    Proteins = table.Column<double>(nullable: true),
                    Fats = table.Column<double>(nullable: true),
                    Carbohydrates = table.Column<double>(nullable: true),
                    Calories = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.DishId);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IngnredientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngnredientId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Login = table.Column<string>(maxLength: 30, nullable: false),
                    Email = table.Column<string>(maxLength: 30, nullable: false),
                    Password = table.Column<string>(maxLength: 30, nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "DishCategories",
                columns: table => new
                {
                    DishId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishCategories", x => new { x.CategoryId, x.DishId });
                    table.ForeignKey(
                        name: "FK_DishCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DishCategories_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "DishId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DishIngredients",
                columns: table => new
                {
                    DishId = table.Column<int>(nullable: false),
                    IngredientId = table.Column<int>(nullable: false),
                    Amount = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishIngredients", x => new { x.DishId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_DishIngredients_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "DishId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DishIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngnredientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Favourites",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    DishId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favourites", x => new { x.UserId, x.DishId });
                    table.ForeignKey(
                        name: "FK_Favourites_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "DishId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Favourites_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    DishId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => new { x.UserId, x.DishId });
                    table.ForeignKey(
                        name: "FK_Likes_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "DishId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Likes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "sweets" },
                    { 2, "soup" },
                    { 3, "Italian" },
                    { 4, "Thai" },
                    { 5, "breakfast" }
                });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "DishId", "Calories", "Carbohydrates", "Description", "Fats", "ImageUrl", "Name", "Proteins", "Recipe", "Servings", "Stars", "Time" },
                values: new object[,]
                {
                    { 1, null, null, "This classic buttermilk pancakes recipe is easy to make and yields the most delicious, fluffy, homemade pancakes.  See notes above for possible ingredient add-ins.", null, "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Perfect-Buttermilk-Pancakes-Recipe-1-1100x1650.jpg", "Buttermilk pancakes", null, "Whisk together the dry ingredients.  Flour, sugar, baking powder, baking soda, and salt.Whisk together the wet ingredients.In a separate medium bowl — buttermilk, melted butter, eggs and vanilla.Combine.Pour the wet ingredients over the dry and whisk until just combined.  (Don’t overmix, it’s ok for the batter to be a bit lumpy!) Let the batter sit at room temperature for 10 minutes to thicken up.Prepare the skillet or griddle.Preheat a griddle pan or large non - stick skillet over medium - high heat, or an electric griddle to 350°F.Cook the pancakes.Grease the griddle or skillet with a generous pat of butter.* Pour the batter in 1 / 2 * -cup dollops on the hot griddle — as many as will comfortably fit with room to flip the pancakes.Cook the pancakes until bubbles begin to pop on the top and the edges are set, about 3 minutes.Use a spatula to flip and cook for another 2 to 3 minutes, until golden brown.Transfer the pancakes to a plate and continue making pancakes until the batter is gone.Serve warm.  Serve the pancakes stacked high with plenty of maple syrup and extra butter, if desired.", 7, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2100) },
                    { 2, null, null, "This Thai Chicken Wild Rice recipe is full of the best fresh and creamy curry flavors, and it’s easy to make in the Instant Pot, Crock-Pot or on the stovetop.", null, "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Thai-Chicken-Wild-Rice-Soup-Recipe-1.jpg", "Thai Chicken Wild Rice", null, "Cook the base of the soup. Whichever cooking method you choose, we will simmer the base soup ingredients (chicken, rice, broth, veggies and seasonings) until the rice is cooked and tender. Shred the chicken.Once the rice and chicken are tender,remove the cooked chicken and shred with two forks into bite - sized pieces, then add it back into the soup.  (Or alternately, you’re welcome to just cut the chicken into bite - sized pieces beforehand.) Season.Stir in the coconut milk.Then taste the soup and season with salt, pepper and / or extra Thai red curry paste as needed. Serve warm. Garnished with a squeeze of lime juice and fresh cilantro, plus an extra toppings that sound good.", 7, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(3600) },
                    { 3, null, null, "This hearty Broccoli Chicken Casserole recipe is made with your choice of pasta, tender chicken and broccoli, and the most delicious creamy cheddar mushroom sauce.  See notes above for possible ingredient variations too.", null, "https://www.gimmesomeoven.com/wp-content/uploads/2019/08/Healthy-Broccoli-Chicken-Casserole-Recipe-7.jpg", "Broccoli Chicken Casserole", null, "Cook the pasta and broccoli.  Cook the pasta in a large pot of boiling water (don’t forget to generously salt the water!) until it is al dente.  But — plot twist! — toss the broccoli florets into the water about 1 minute before the pasta is done cooking to give it a quick cook too.  Drain both. Make the mushroom sauce. Meanwhile, we’ll work on the sauce.  Sauté the onion, followed by the mushrooms and garlic in butter (or oil) until softened.  Stir in some flour and let it cook for 1 minute (this will help to thicken the sauce).  Then add in the stock, milk, Dijon, salt and pepper, and cook until the sauce reaches a simmer.  Stir in half of the shredded cheese, taste, and adjust any seasonings as needed. Put everything together.  In a large 9 x 13-inch baking dish, give everything a good toss — the cooked pasta, broccoli, mushroom sauce and chicken — until combined.Bake.  Bake uncovered for 15 minutes.  Then remove pan from the oven, sprinkle the remaining cheddar cheese evenly on top of the casserole, and bake for 10 more minutes or until the cheese is nice and melty. Enjoy! Serve nice and warm, garnished with extra black pepper and/or fresh herbs, if desired.", 7, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(3600) },
                    { 4, null, null, "My all-time favorite Butternut Squash Soup recipe!  It’s super-easy to make, naturally gluten-free and vegan, and SO incredibly cozy and delicious.  Stovetop, Crock-Pot and Instant Pot instructions included below.", null, "https://www.gimmesomeoven.com/wp-content/uploads/2015/02/The-Best-Butternut-Squash-Soup-Recipe-1.jpg", "Butternut squash soup", null, "Combine your ingredients (minus the coconut milk) in a slow cooker*.  Roughly diced — don’t spend time perfectly chopping all of your ingredients.  Feel free to use a large (6-quart) slow cooker or a small (3.5- to 4-quart) slow cooker. Cook until tender.  Generally about 6-8 hours on low, or 3-4 hours on high.  Then remove and discard the sage and add in the coconut milk. Blend.  Either use an immersion blender to puree the soup until smooth.  Or you can transfer the soup in two batches to a traditional blender and puree it there.  (Just be extremely careful blending hot liquids; you do not want the blender to be too full.) Taste and season.  Add extra salt, pepper and/or cayenne if needed, to taste. Serve and enjoy!  Garnished with any of your favorite toppings.", 7, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(3000) },
                    { 5, null, null, "These healthy pumpkin muffins are naturally gluten-free, sweetened with maple syrup, quick and easy to make, and so perfecty pumpkin-y.", null, "https://www.gimmesomeoven.com/wp-content/uploads/2018/09/Healthy-Pumpkin-Muffins-Recipe-Gluten-Free-Vegan-2.jpg", "Pumpkin muffins", null, "Make your oat “flour”: Add your oats to a blender or food processor and pulse until they reach a flour-like consistency. Combine your dry ingredients: Add the pumpkin pie spice, salt and baking soda, and pulse until evenly combined. Whisk together your wet ingredients: In a separate mixing bowl, whisk together the pumpkin, eggs, maple syrup, almond milk and vanilla until evenly combined. Combine the two.  Fold the dry ingredients in with the wet, and use a spatula to stir together until just combined.  (Try not to over-stir.) Fill your muffin cups.  Portion the batter evenly between 12 muffin cups.  (I always like to do this with a large cookie scoop.  You’ll need a heaping scoop of batter for this specific recipe — about 1/3 cup per muffin.)  Then sprinkle with a pinch of turbinado sugar, if you’d like. Bake.  Until a toothpick inserted in the center of a muffin comes out clean, about 15 minutes. Enjoy!  I love these muffins best fresh outta the oven.  But once they have cooled to room temperature, feel free to store them in a sealed container for up to 3 days, or freeze (wrapped tightly in plastic wrap) for up to 3 months.", 12, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1800) }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "IngnredientId", "Description", "Name" },
                values: new object[,]
                {
                    { 10, "for serving", "maple syrup" },
                    { 9, "", "vanilla extract" },
                    { 8, "slightly beaten, at room temperature", "eggs" },
                    { 7, "melted and cooled to room temperature, plus more for cooking", "unsalted butter" },
                    { 6, "at room temperature", "buttermilk" },
                    { 2, "", "sugar" },
                    { 4, "", "baking soda" },
                    { 3, "", "baking powder" },
                    { 1, "all-purpose", "flour" },
                    { 5, "", "sea salt" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "IsAdmin", "Login", "Password" },
                values: new object[,]
                {
                    { 2, "ann@gmail.com", false, "Ann", "ann456" },
                    { 1, "tom@gmail.com", true, "Tom", "tom123" },
                    { 3, "rob@gmail.com", false, "Rob", "rob789" }
                });

            migrationBuilder.InsertData(
                table: "DishCategories",
                columns: new[] { "CategoryId", "DishId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 5, 1 }
                });

            migrationBuilder.InsertData(
                table: "DishIngredients",
                columns: new[] { "DishId", "IngredientId", "Amount" },
                values: new object[,]
                {
                    { 1, 10, "as mush as you want" },
                    { 1, 8, "2 large" },
                    { 1, 7, "4 tablespoons" },
                    { 1, 6, "3 cups" },
                    { 1, 9, "1 teaspoon" },
                    { 1, 4, "1 teaspoon" },
                    { 1, 3, "4 teaspoons" },
                    { 1, 2, "2 tablespoons" },
                    { 1, 1, "2 1/2 cups" },
                    { 1, 5, "3/4 teaspoon" }
                });

            migrationBuilder.InsertData(
                table: "Favourites",
                columns: new[] { "UserId", "DishId" },
                values: new object[,]
                {
                    { 3, 5 },
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "UserId", "DishId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 3, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DishCategories_DishId",
                table: "DishCategories",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_Name",
                table: "Dishes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DishIngredients_IngredientId",
                table: "DishIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Favourites_DishId",
                table: "Favourites",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_Name",
                table: "Ingredients",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Likes_DishId",
                table: "Likes",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Login",
                table: "Users",
                column: "Login",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DishCategories");

            migrationBuilder.DropTable(
                name: "DishIngredients");

            migrationBuilder.DropTable(
                name: "Favourites");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
