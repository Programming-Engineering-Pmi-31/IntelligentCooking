using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntelligentCooking.DAL.Migrations
{
    public partial class Recreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    ImageUrl = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Recipe = table.Column<string>(unicode: false, nullable: false),
                    Time = table.Column<TimeSpan>(nullable: false),
                    Servings = table.Column<int>(nullable: false),
                    Proteins = table.Column<double>(nullable: false),
                    Fats = table.Column<double>(nullable: false),
                    Carbohydrates = table.Column<double>(nullable: false),
                    Calories = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Token = table.Column<string>(nullable: false),
                    JwtId = table.Column<string>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    IsUsed = table.Column<bool>(nullable: false),
                    IsInvalidated = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Token);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DishCategories_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favourites_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    DishId = table.Column<int>(nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => new { x.DishId, x.Priority });
                    table.ForeignKey(
                        name: "FK_Images_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    DishId = table.Column<int>(nullable: false),
                    Rate = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => new { x.UserId, x.DishId });
                    table.ForeignKey(
                        name: "FK_Ratings_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "https://ukrhealth.net/wp-content/uploads/2018/01/shutterstock_361496144-696x464.jpg", "Sweets" },
                    { 2, "https://www.gimmesomeoven.com/wp-content/uploads/2015/02/The-Best-Butternut-Squash-Soup-Recipe-1.jpg", "Soup" },
                    { 3, "https://www.englishclub.com/images/vocabulary/food/italian/italian-food-640.jpg", "Italian" },
                    { 4, "https://www.untoldmorsels.com/wp-content/uploads/2018/08/thai-food-culture.jpg", "Thai" },
                    { 5, "https://olo-images-live.imgix.net/3a/3afe98ddcf4643a0b20c068b2c59f2ce.jpg?auto=format%2Ccompress&q=60&cs=tinysrgb&w=500&h=333&fit=fill&fm=png32&bg=transparent&s=862b0bcde81b3d6190fb8465f031a5cf", "Breakfast" },
                    { 6, "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Healthy-Veggie-Quesadillas-Recipe-6-2.jpg", "Quick and Easy" },
                    { 7, "https://static.standard.co.uk/s3fs-public/thumbnails/image/2019/05/14/15/vegetarian-meal-14-05-19-0.jpg?w968", "Vegetarian" },
                    { 8, "https://img.thedailybeast.com/image/upload/c_crop,d_placeholder_euli9k,h_1440,w_2560,x_0,y_0/dpr_1.5/c_limit,w_1044/fl_lossy,q_auto/v1517521303/180131-wondrich-bad-cocktail-tease_wghhv8", "Drinks" }
                });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Calories", "Carbohydrates", "Description", "Fats", "Name", "Proteins", "Recipe", "Servings", "Time" },
                values: new object[,]
                {
                    { 17, 300.0, 15.0, "This Instant Pot Mac and Cheese recipe is super-easy to make with just a few simple ingredients and tastes perfectly creamy and cheesy!", 10.0, "Instant Pot Mac and Cheese", 8.0, "Prep the pasta. Add the pasta, water, butter, mustard, garlic powder and 1 teaspoon salt to the bowl of an Instant Pot, and briefly stir to combine. Pressure cook. Cover and cook on high pressure for 4 minutes, followed by a quick release. Stir in the cheese. Stir in the milk and cheeses until they have melted into a creamy sauce.  The sauce will continue to thicken as it sits, so if it seems too thin, just let it rest for an extra minute or two.  Season with S&P. Serve warm.  Then serve while the mac and cheese is still nice and warm.  Enjoy!", 7, new TimeSpan(0, 0, 25, 0, 0) },
                    { 16, 340.0, 9.0, "100% obsessed with this creamy buttermilk ranch mashed potatoes recipe!  They’re easy to make, perfectly fluffy and creamy, and made with the tastiest fresh herb ranch seasoning.", 10.0, "Ranch Mashed Potatoes", 11.0, "Cut the potatoes.  For even cooking, be sure to have them cut into evenly-sized chunks (about 1-inch wide). Boil the potatoes.  The usual method — place the potatoes in a large pot, cover with cold water, bring to a boil, simmer until tender, then drain. Prepare your melted butter mixture.  While the potatoes are cooking, heat the butter, buttermilk, salt and pepper together in the microwave (or a small saucepan) until the butter is just melted.  (You want to avoid boiling the buttermilk.) Pan-dry the potatoes.  Once the potatoes have been drained, immediately return them to the hot stockpot, place it back on the hot burner, and turn the heat down to low.  Using two oven mitts, carefully hold the handles on the stockpot and shake it gently on the burner for about 1 minute.  This step will help cook off some of the remaining steam within the potatoes. Mash the potatoes.  Using your preferred kind of potato masher (I recommend this one in general, or this one for extra-smooth), mash the potatoes to your desired consistency.  Then stir the herbs into the melted butter mixture until combined, then gradually fold the butter mixture and cream cheese into the mashed potatoes.  As always, try not to overmix the potatoes to prevent them from turning gummy. Taste and season.  One final time, taste the potatoes and season with extra salt and pepper as needed.  (I still usually add in quite a bit at this point.) Serve.  Serve warm, garnished with extra chopped herbs if you would like, and dig in!", 11, new TimeSpan(0, 0, 45, 0, 0) },
                    { 15, 290.0, 10.0, "This tahini granola recipe is easy to make, perfectly crispy and clustery, and full of the best sweet and savory flavors.", 10.0, "Tahini Granola", 18.0, "Mix the ingredients. In one bowl, combine the base ingredients (oats and nuts).  In a second bowl, combine the tahini sauce (tahini, honey, coconut oil, vanilla, salt, cardamom, cinnamon and sesame seeds), and heat the mixture slightly until warm but not bubbly.  Pour the tahini sauce over the base ingredients, and stir to combine. Bake. Spread the granola out evenly on a large parchment-covered baking sheet.  Bake for 25 minutes, stirring once halfway through.  Then sprinkle the coconut evenly over the top of the granola (if using), bake for 5-10 more minutes until toasted, and transfer the baking sheet to a wire rack and let it cool completely to room temperature without stirring. Break it up.  At this point, you can break the granola up into your desired size of clumps.  (I love mine extra clumpy!) Serve.  Then serve it immediately or store in an airtight container at room temp for up to 1 month.", 4, new TimeSpan(0, 0, 40, 0, 0) },
                    { 14, 375.0, 18.0, "This homemade pecan pie recipe is naturally sweetened (no corn syrup!), easy to make, and so comforting and delicious!", 20.0, "Pecan Pie", 10.0, "Blind bake the pie crust. Use parchment paper to line the inside of a chilled unbaked pie crust, then fill the bottom of the crust with pie weights or dried beans.  Bake for 15 minutes. Then remove the pie pan from the oven, carefully lift out the parchment and weights, and set them aside. Prepare the maple sauce: Whisk together three of the eggs, maple syrup, coconut sugar (or brown sugar), bourbon, cornstarch, vanilla, sea salt and ground cinnamon — followed by the melted butter — together in a large bowl until combined. Make the egg wash.  In a separate small bowl, whisk together the remaining one egg and an extra tablespoon or milk (or water) until combined.  Brush the egg wash lightly over the edges of the pie crust, which will help it to bake up nice and golden. Assemble the pie. Arrange the pecans in an even layer in the blind-baked pie crust, then pour the maple sauce evenly over the top of the pecans. Bake.  Bake the pie for 40-50 minutes, or until the top is lightly browned. After the first 20 to 25 minutes of bake time, you are welcome to loosely tent a piece of aluminum foil over the top of the whole pie if the crust or pecans seem to be browning too quickly.  The pie will be ready to go once the top is puffed up into a dome (which will sink to become flat again, once the pie has set and cooled).  Transfer the pie to a wire rack and let it rest until it reaches room temperature. Serve. Slice and serve pie at room temperature (or you can refrigerate and chill the pie, if you prefer).  Cover and store leftover pie at room temperature for 1-2 days or in the refrigerator for 4-5 days.", 12, new TimeSpan(0, 1, 25, 0, 0) },
                    { 13, 450.0, 18.0, "This savory sweet potato casserole recipe is made with a creamy garlicky mashed filling, and sprinkled with the most irresistible maple rosemary walnut topping.  It’s also naturally gluten-free and can be made vegan, if you’d like.", 15.0, "Savory Sweet Potato Casserole", 17.0, "Boil the sweet potatoes.  Cut the sweet potatoes into evenly-sized chunks (about 1 inch thick) and boil them in a large stockpot until tender. Prepare the melted butter mixture.  Meanwhile, as the sweet potatoes are boiling, heat the butter, milk, smoked paprika, and sea salt together in a small saucepan or in the microwave until the butter is just melted.  (You want to avoid boiling the milk.) Mash the potatoes.  Drain and briefly pan-dry the sweet potatoes, to remove any excess moisture.  Then, using your preferred kind of potato masher (I recommend this one in general, or this one for extra-smooth), mash the sweet potatoes to your desired consistency.  Pour the melted butter mixture over the potatoes, and fold it in with a wooden spoon or spatula until potatoes have soaked up the liquid.  Taste and season with extra salt, pepper, and/or smoked paprika as needed, to taste. Prepare the walnut topping.  In a separate small bowl, stir together the maple rosemary walnut topping ingredients until evenly combined. Assemble and bake.  Spread the mashed sweet potatoes out in an even layer in a 9×13-inch baking dish, and top evenly with the walnut topping.  Bake for about 20-25 minutes, or until the walnuts are toasted and fragrant (but not burnt). Serve warm.  Then serve warm, garnished with fresh chives, extra black pepper, or any extra toppings that sound good!", 12, new TimeSpan(0, 0, 35, 0, 0) },
                    { 11, 120.0, 10.0, "Homemade mulled wine is incredibly easy to make on the stovetop (or simmer in the slow cooker), it’s easy to customize with your favorite spices and add-ins, and it is SO cozy and delicious.  Perfect for winter and holiday entertaining!", 0.0, "Mulled Wine", 2.0, "Combine all ingredients in a saucepan and heat until the mixture just barely reaches a simmer over medium-high heat.  (Avoid boiling — you don’t want to boil off the alcohol.)  Reduce heat to medium-low, cover, and let the wine simmer for at least 15 minutes or up to 3 hours. Strain, and serve warm with your desired garnishes.", 5, new TimeSpan(0, 0, 20, 0, 0) },
                    { 10, 380.0, 14.0, "This easy Green Bean Casserole recipe is made from scratch with lightened-up ingredients, it’s nice and fresh and crispy, and it is full of the absolute best flavors.  Always a crowd fave!", 16.0, "Green Bean Casserole", 13.0, "Preheat oven.  Heat oven to 375°F. Trim, cut and briefly boil the green beans. Heat a large stockpot of water over high-heat until boiling. Meanwhile, trim and cut the green beans.  Then add the beans to the boiling water and cook for 3-5 minutes, depending on how crispy you like your green beans. (Keep in mind that the beans will cook more in the oven, so err on the side of undercooking them to your taste during this step.)  Then use a slotted spoon or large strainer to transfer the beans immediately into a large bowl of ice water, and give them a quick stir.  This will prevent them from cooking longer.  Set aside. Prepare your crispy onion topping.  Melt 1/2 tablespoon butter (or olive oil) in a large sauté pan over medium-high heat.  Add the onion and sauté for 2-3 minutes, stirring occasionally, until the onion is partially cooked but still holds its shape.  (You don’t want the onion to get too soft.)  Transfer the onion to a clean bowl.  Add the remaining 1/2 tablespoon butter to the sauté pan, along with the panko, and stir to combine.  Cook for 2-3 minutes, stirring constantly, until the panko is lightly golden.  Remove from heat, and transfer the panko to the bowl with the onions.  Add in the Parmesan, salt and pepper, and toss the onion mixture until evenly combined.  Set aside. Prepare your mushroom alfredo sauce.  Briefly rinse and dry the sauté pan.  Then return it to the stove.  Melt the butter over medium-high heat. Then add the mushrooms and sauté for 5 minutes, stirring occasionally, until lightly browned and soft.  Add the garlic and sauté for 1-2 more minutes, stirring occasionally, until fragrant.  Stir in the flour and sauté for 1 more minute, stirring occasionally.  Then add in the vegetable stock, and stir until the flour is evenly dissolved.  Add the milk and Parmesan, and stir to combine.  Continue cooking the sauce until it reaches a simmer and thickens.  Then remove from heat, and season with salt and pepper to taste. Put it all together!  Combine the green beans and mushroom alfredo sauce in the stockpot, and stir the green bean mixture until evenly combined.  Transfer to a 9 x 13-inch baking dish, and spread the green bean mixture out in an even layer.  Sprinkle evenly with the crispy onion topping mixture. Bake.  Then bake for about 25 minutes, or until the crispy onion topping is golden and crispy.  (Keep an eye on it so that it does not burn.  If it does start to char, simply lay a piece of aluminum foil on top of the casserole.) Serve warm.  Remove from the oven and serve warm, garnished with extra freshly-cracked black pepper (plus maybe some parsley) if you’d like.", 10, new TimeSpan(0, 1, 0, 0, 0) },
                    { 9, 390.0, 18.0, "This Thai Basil Beef Noodle Stir-Fry recipe is easy to make and tossed with the best savory Thai basil sauce.  Feel free to sub in chicken, pork, shrimp or crispy tofu in place of the beef if you would like!", 15.0, "Thai Basil Beef Noodle Stir-Fry", 17.0, "Prep the sauce. Whisk the sauce ingredients together in a small bowl or measuring cup until combined. Prep the noodles.  Cook the noodles according to package instructions until they are al dente.  Then drain and set aside until ready to use. Sear the beef.  Heat some cooking oil in a large sauté pan or wok over medium-high heat.  Cook the beef briefly until it is browned on both sides.  Then transfer it to a separate (clean) plate, and return the pan to the heat. Cook the veggies.  Give the veggies a quick sauté until they are cooked through. Combine everything together.  Then add the cooked noodles, sauce, beef, and Thai basil to the pan, and toss until everything is coated evenly with the sauce. Serve warm.  Serve immediately while the stir-fry is nice and hot, garnished with any of your desired toppings.", 12, new TimeSpan(0, 1, 0, 0, 0) },
                    { 12, 345.0, 10.0, "This Brussels Sprouts, Cranberry and Quinoa Salad is super-easy to make with shredded fresh Brussels sprouts and a zippy orange vinaigrette.  It’s also naturally gluten-free and vegan, so that everyone at the table can enjoy it.", 8.0, "Brussels Sprouts, Cranberry and Quinoa Salad", 15.0, "Make the vinaigrette. In a small bowl, whisk all of the vinaigrette ingredients together until combined.  (Or my preference — combine them in a mason jar, cover, and shake until combined.) Make the salad. Combine the shredded Brussels, cooked quinoa, dried cranberries, chopped pecans and shallot in a large bowl.  Drizzle evenly with the vinaigrette, then tossed until completely combined. Season.  Taste and season the salad with extra salt and pepper, as needed. Serve. Serve immediately, or refrigerate in a sealed container for up to 3 days.", 5, new TimeSpan(0, 0, 15, 0, 0) },
                    { 7, 345.0, 15.0, "The beauty of this salad is that it keeps really well in the fridge, so feel free to prep it in advance if you’d like! ", 13.0, "Roasted Broccoli and Farro Bowls", 18.0, "Roast the broccoli.  I detailed how to do this in yesterday’s post.  Basically, toss in oil, season with S&P and roast over high heat! Cook the farro.  On the stovetop, in veggie stock (instead of water) for extra flavor. Make the dressing.  Whisk all of the ingredients together in a small bowl (or shake together in a mason jar) until combined. Toss everything together.  Then in a large bowl, combine the broccoli, farro, arugula, chickpeas, almonds and dressing.  Toss to combine. Serve or refrigerate for later.  Then serve it up immediately, or transfer the salad to a sealed container and refrigerate for up to 3 days.", 12, new TimeSpan(0, 0, 45, 0, 0) },
                    { 6, 268.0, 16.0, "These Easy Veggie Quesadillas are 100% customizable with whatever veggies you have on hand or happen to love most.  See notes above for possible ingredient variations!", 13.0, "Veggie quesadillas", 18.0, "Heat 1 tablespoon olive oil over medium-high heat in a large non-stick sauté pan.  Add sweet potato and sauté for 5-6 minutes, stirring occasionally, until cooked through.  Transfer to a separate plate and set aside. Add the remaining 1 tablespoon oil to the pan.  Add the veggies and jalapeño, and sauté for 4-5 minutes.  Stir in the cooked sweet potato, black beans, cumin, chili powder, a generous pinch of salt and black pepper, and sauté for 2 more minutes.  Taste and add more salt, pepper and/or cumin if needed.  Transfer the mixture to a large bowl and set aside.  Rinse (or just wipe off) the sauté pan until it is clean. Return the sauté pan to the stove, and reduce heat to medium.  Place a tortilla* in the center of the pan and immediately sprinkle your desired amount of cheese evenly over the surface of the tortilla.  Add a few large spoonfuls (about 1 cup) of the veggie mixture on one half of the tortilla, then sprinkle on some cilantro.  Fold the other side of the tortilla over to create a half moon.  Continue cooking for another 30 seconds or so, or until the bottom of the tortilla is crisp and golden.  (Just lift it up and take a peek to see when it’s ready to go.)  Then carefully flip the tortilla over and cook it for an additional 30-60 seconds on the second side. Transfer to a serving plate*, slice into triangles, then repeat with the remaining ingredients. Serve warm, along with your favorite salsa, guacamole and/or sour cream for dipping.", 7, new TimeSpan(0, 0, 40, 0, 0) },
                    { 5, 378.0, 15.0, "These healthy pumpkin muffins are naturally gluten-free, sweetened with maple syrup, quick and easy to make, and so perfecty pumpkin-y.", 10.0, "Pumpkin muffins", 12.0, "Make your oat “flour”: Add your oats to a blender or food processor and pulse until they reach a flour-like consistency. Combine your dry ingredients: Add the pumpkin pie spice, salt and baking soda, and pulse until evenly combined. Whisk together your wet ingredients: In a separate mixing bowl, whisk together the pumpkin, eggs, maple syrup, almond milk and vanilla until evenly combined. Combine the two.  Fold the dry ingredients in with the wet, and use a spatula to stir together until just combined.  (Try not to over-stir.) Fill your muffin cups.  Portion the batter evenly between 12 muffin cups.  (I always like to do this with a large cookie scoop.  You’ll need a heaping scoop of batter for this specific recipe — about 1/3 cup per muffin.)  Then sprinkle with a pinch of turbinado sugar, if you’d like. Bake.  Until a toothpick inserted in the center of a muffin comes out clean, about 15 minutes. Enjoy!  I love these muffins best fresh outta the oven.  But once they have cooled to room temperature, feel free to store them in a sealed container for up to 3 days, or freeze (wrapped tightly in plastic wrap) for up to 3 months.", 12, new TimeSpan(0, 0, 30, 0, 0) },
                    { 4, 234.0, 13.0, "My all-time favorite Butternut Squash Soup recipe!  It’s super-easy to make, naturally gluten-free and vegan, and SO incredibly cozy and delicious.  Stovetop, Crock-Pot and Instant Pot instructions included below.", 12.0, "Butternut squash soup", 20.0, "Combine your ingredients (minus the coconut milk) in a slow cooker*.  Roughly diced — don’t spend time perfectly chopping all of your ingredients.  Feel free to use a large (6-quart) slow cooker or a small (3.5- to 4-quart) slow cooker. Cook until tender.  Generally about 6-8 hours on low, or 3-4 hours on high.  Then remove and discard the sage and add in the coconut milk. Blend.  Either use an immersion blender to puree the soup until smooth.  Or you can transfer the soup in two batches to a traditional blender and puree it there.  (Just be extremely careful blending hot liquids; you do not want the blender to be too full.) Taste and season.  Add extra salt, pepper and/or cayenne if needed, to taste. Serve and enjoy!  Garnished with any of your favorite toppings.", 7, new TimeSpan(0, 0, 50, 0, 0) },
                    { 3, 199.0, 10.0, "This hearty Broccoli Chicken Casserole recipe is made with your choice of pasta, tender chicken and broccoli, and the most delicious creamy cheddar mushroom sauce.  See notes above for possible ingredient variations too.", 7.0, "Broccoli Chicken Casserole", 9.0, "Cook the pasta and broccoli.  Cook the pasta in a large pot of boiling water (don’t forget to generously salt the water!) until it is al dente.  But — plot twist! — toss the broccoli florets into the water about 1 minute before the pasta is done cooking to give it a quick cook too.  Drain both. Make the mushroom sauce. Meanwhile, we’ll work on the sauce.  Sauté the onion, followed by the mushrooms and garlic in butter (or oil) until softened.  Stir in some flour and let it cook for 1 minute (this will help to thicken the sauce).  Then add in the stock, milk, Dijon, salt and pepper, and cook until the sauce reaches a simmer.  Stir in half of the shredded cheese, taste, and adjust any seasonings as needed. Put everything together.  In a large 9 x 13-inch baking dish, give everything a good toss — the cooked pasta, broccoli, mushroom sauce and chicken — until combined.Bake.  Bake uncovered for 15 minutes.  Then remove pan from the oven, sprinkle the remaining cheddar cheese evenly on top of the casserole, and bake for 10 more minutes or until the cheese is nice and melty. Enjoy! Serve nice and warm, garnished with extra black pepper and/or fresh herbs, if desired.", 7, new TimeSpan(0, 1, 0, 0, 0) },
                    { 2, 255.0, 15.0, "This Thai Chicken Wild Rice recipe is full of the best fresh and creamy curry flavors, and it’s easy to make in the Instant Pot, Crock-Pot or on the stovetop.", 10.0, "Thai Chicken Wild Rice Soup", 8.0, "Cook the base of the soup. Whichever cooking method you choose, we will simmer the base soup ingredients (chicken, rice, broth, veggies and seasonings) until the rice is cooked and tender. Shred the chicken.Once the rice and chicken are tender,remove the cooked chicken and shred with two forks into bite - sized pieces, then add it back into the soup.  (Or alternately, you’re welcome to just cut the chicken into bite - sized pieces beforehand.) Season.Stir in the coconut milk.Then taste the soup and season with salt, pepper and / or extra Thai red curry paste as needed. Serve warm. Garnished with a squeeze of lime juice and fresh cilantro, plus an extra toppings that sound good.", 7, new TimeSpan(0, 0, 35, 0, 0) },
                    { 1, 400.0, 32.0, "This classic buttermilk pancakes recipe is easy to make and yields the most delicious, fluffy, homemade pancakes.  See notes above for possible ingredient add-ins.", 1.0, "Buttermilk pancakes", 32.0, "Whisk together the dry ingredients.  Flour, sugar, baking powder, baking soda, and salt.Whisk together the wet ingredients.In a separate medium bowl — buttermilk, melted butter, eggs and vanilla.Combine.Pour the wet ingredients over the dry and whisk until just combined.  (Don’t overmix, it’s ok for the batter to be a bit lumpy!) Let the batter sit at room temperature for 10 minutes to thicken up.Prepare the skillet or griddle.Preheat a griddle pan or large non - stick skillet over medium - high heat, or an electric griddle to 350°F.Cook the pancakes.Grease the griddle or skillet with a generous pat of butter.* Pour the batter in 1 / 2 * -cup dollops on the hot griddle — as many as will comfortably fit with room to flip the pancakes.Cook the pancakes until bubbles begin to pop on the top and the edges are set, about 3 minutes.Use a spatula to flip and cook for another 2 to 3 minutes, until golden brown.Transfer the pancakes to a plate and continue making pancakes until the batter is gone.Serve warm.  Serve the pancakes stacked high with plenty of maple syrup and extra butter, if desired.", 7, new TimeSpan(0, 0, 35, 0, 0) },
                    { 8, 390.0, 15.0, "This easy apple crisp (apple crumble) recipe is made with a warm cinnamon apple filling and an irresistible buttery crunchy crumble topping.  Plus this no-fuss version takes less than 20 minutes to prep — no apple peeling required!", 14.0, "Apple Crisp", 19.0, "Make the filling. Toss together the apples, lemon juice, brown sugar, flour and cinnamon until combined.  Then spread everything out in an even layer in a 9 x 13-inch baking dish. Make the topping.  Stir together the oats, flour, brown sugar, pecans, cinnamon and salt until combined.  Then drizzle with the melted butter and toss together until the dry ingredients are moistened, yet still nice and clumpy (not over-mixed). Bake. Sprinkle the topping over the apples, then pop the pan in the oven and bake for about 40-50 minutes, or until the filling is bubbly and the topping is nice and crisp. Serve.  Dish it up while the apple crisp is nice and warm, topped with a generous scoop of vanilla ice cream", 12, new TimeSpan(0, 0, 20, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 48, "", "chickpeas" },
                    { 47, "", "baby arugula" },
                    { 46, "", "farro" },
                    { 45, "", "Mexican-blend cheese" },
                    { 44, "", "flour tortillas" },
                    { 43, "", "black beans" },
                    { 39, "", "pumpkin puree" },
                    { 41, "", "sweet potato" },
                    { 40, "", "coconut oil" },
                    { 38, "", "special pumpkin pie spice" },
                    { 37, "", "other oats" },
                    { 36, "", "pumpkin pie spice" },
                    { 49, "", "almonds" },
                    { 42, "", "jalapeño" },
                    { 50, "", "lemon juice" },
                    { 62, "", "bourbon" },
                    { 52, "", "rice noodles" },
                    { 53, "", "flank steak" },
                    { 54, "", "green beans" },
                    { 55, "", "red wine" },
                    { 56, "", "orange" },
                    { 57, "", "cranberries" },
                    { 58, "", "pecans" },
                    { 59, "", "shallot" },
                    { 60, "", "smoked paprika" },
                    { 61, "", "pie crust" },
                    { 35, "", "oats" },
                    { 63, "", "pecan halves" },
                    { 64, "", "raw pepitas" },
                    { 65, "", "potato" },
                    { 51, "", "cinnamon" },
                    { 34, "", "cayenne" },
                    { 21, "", "pasta" },
                    { 32, "", "sage" },
                    { 1, "all-purpose", "flour" },
                    { 2, "", "sugar" },
                    { 3, "", "baking powder" },
                    { 4, "", "baking soda" },
                    { 5, "", "sea salt" },
                    { 6, "", "buttermilk" },
                    { 7, "", "butter" },
                    { 8, "", "egg" },
                    { 9, "", "vanilla extract" },
                    { 10, "", "maple syrup" },
                    { 11, "", "chicken" },
                    { 12, "", "wild rice" },
                    { 13, "", "checken stock" },
                    { 14, "", "baby bella mushroom" },
                    { 15, "", "garlic" },
                    { 16, "", "bell pepper" },
                    { 17, "", "carrot" },
                    { 31, "", "butternut squash" },
                    { 30, "", "Granny Smith apple" },
                    { 29, "", "vegetable stock" },
                    { 28, "", "black papper" },
                    { 27, "", "cheddar cheese" },
                    { 26, "", "Dijon mustard" },
                    { 33, "", "salt" },
                    { 25, "", "milk" },
                    { 23, "", "butter oil" },
                    { 22, "", "broccoli" },
                    { 66, "", "water" },
                    { 20, "", "coconut milk" },
                    { 19, "f", "ginger" },
                    { 18, "", "onion" },
                    { 24, "", "olive oil" },
                    { 67, "", "Parmesan cheese" }
                });

            migrationBuilder.InsertData(
                table: "DishCategories",
                columns: new[] { "CategoryId", "DishId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 6, 17 },
                    { 7, 16 },
                    { 5, 15 },
                    { 1, 14 },
                    { 7, 13 },
                    { 7, 12 },
                    { 7, 10 },
                    { 5, 9 },
                    { 4, 9 },
                    { 5, 8 },
                    { 7, 7 },
                    { 7, 6 },
                    { 8, 11 },
                    { 6, 6 },
                    { 4, 2 },
                    { 1, 5 },
                    { 5, 1 },
                    { 2, 4 },
                    { 7, 3 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "DishIngredients",
                columns: new[] { "DishId", "IngredientId", "Amount" },
                values: new object[,]
                {
                    { 7, 22, "1 medium head" },
                    { 4, 28, "1/4 teaspoon" },
                    { 3, 29, "2 cups" },
                    { 7, 29, "3 cups" },
                    { 8, 30, "8 medium" },
                    { 4, 31, "1 medium" },
                    { 4, 32, "1 sprig" },
                    { 4, 33, "1/2 teaspoon" },
                    { 4, 34, "1/8 teaspoon" },
                    { 5, 35, "3 cups" },
                    { 15, 35, "2 teaspoons" },
                    { 4, 30, "1" },
                    { 3, 28, "1/4 teaspoon" },
                    { 17, 26, " 1/2 teaspoons" },
                    { 3, 27, "2 cups (8 ounces)" },
                    { 3, 26, "1 teaspoon" },
                    { 4, 20, "1/2 cup" },
                    { 13, 25, "2 tablespoons" },
                    { 5, 25, "1 cup" },
                    { 8, 37, "1 cup" },
                    { 3, 25, "1 1/2 cups" },
                    { 3, 21, "8 ounces" },
                    { 7, 24, "2 tablespoons" },
                    { 17, 21, "1 pound" },
                    { 6, 24, "2 tablespoons" },
                    { 3, 24, "2 tablespoons" },
                    { 3, 22, "1 large head" },
                    { 2, 20, "1 (15 ounce) can" },
                    { 5, 38, "1 tablespoon" },
                    { 7, 47, "2 large handfuls" },
                    { 5, 40, "3 tablespoons" },
                    { 16, 65, "5 pounds" },
                    { 15, 64, "1/2 cup" },
                    { 14, 63, "2 teaspoons" },
                    { 14, 62, "2 tablespoons" },
                    { 14, 61, "1 (9-inch)" },
                    { 13, 60, "2 teaspoons" },
                    { 12, 59, "1 medium" },
                    { 12, 58, "2/3 cup" },
                    { 12, 57, "1 cup" },
                    { 11, 56, "1" },
                    { 11, 55, "1 (750 ml) bottle" },
                    { 10, 54, "2 pounds" },
                    { 9, 53, "1 1/4 pounds" },
                    { 9, 52, "8 ounces" },
                    { 8, 51, "1 tablespoon + 1 tablespoon" },
                    { 15, 50, "1/2 cup" },
                    { 8, 50, "1/4 cup" },
                    { 7, 49, "1/3 cup" },
                    { 7, 48, "1 (15-ounce) can" },
                    { 2, 19, "2 tablespoons" },
                    { 7, 46, "1 cup" },
                    { 6, 45, "3–4 cups" },
                    { 6, 44, "4–6 large" },
                    { 6, 43, "1 (15-ounce) can" },
                    { 6, 42, "1 small" },
                    { 13, 41, "4 pounds" },
                    { 6, 41, "1 small" },
                    { 5, 39, "1 cup" },
                    { 7, 18, "half of a medium" },
                    { 9, 14, "8 ounces" },
                    { 3, 18, "1 small" },
                    { 17, 7, "2 tablespoons" },
                    { 16, 7, "6 tablespoons" },
                    { 8, 7, "1/2 cup" },
                    { 1, 7, "4 tablespoons" },
                    { 16, 6, "1 1/2 cups" },
                    { 1, 6, "3 cups" },
                    { 4, 18, "1" },
                    { 5, 5, "3/4 teaspoon" },
                    { 3, 5, "1/2 teaspoon" },
                    { 1, 5, "3/4 teaspoon" },
                    { 5, 4, "1 1/2 teaspoons" },
                    { 1, 4, "1 teaspoon" },
                    { 1, 3, "4 teaspoons" },
                    { 11, 2, "2–4 tablespoons" },
                    { 8, 2, "1/4 cup + 2/3 cup" },
                    { 1, 2, "2 tablespoons" },
                    { 8, 1, "1 tablespoon + 1 cup" },
                    { 3, 1, "3 tablespoons" },
                    { 1, 1, "2 1/2 cups" },
                    { 1, 8, "2 large" },
                    { 5, 8, "2" },
                    { 8, 5, "3/4 teaspoon" },
                    { 1, 9, "1 teaspoon" },
                    { 14, 8, "4 large" },
                    { 4, 17, "1" },
                    { 2, 17, "2 medium" },
                    { 2, 16, "2 small" },
                    { 13, 15, "4 cloves" },
                    { 4, 15, "4 cloves" },
                    { 3, 15, "4 cloves" },
                    { 2, 15, "4 cloves" },
                    { 17, 66, "4 cups" },
                    { 2, 18, "1 small" },
                    { 2, 14, "8 ounces" },
                    { 3, 14, "8 ounces" },
                    { 5, 9, "1 teaspoon" },
                    { 1, 10, "as mush as you want" },
                    { 5, 10, "1/2 cup" },
                    { 17, 67, "1/2 cup" },
                    { 3, 11, "2 cups" },
                    { 2, 12, "1 cup" },
                    { 2, 13, "2 cups" },
                    { 3, 13, "1 cup" },
                    { 2, 11, "1 pound boneless skinless chicken breasts" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "DishId", "Priority", "Url" },
                values: new object[,]
                {
                    { 1, 1, "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Perfect-Buttermilk-Pancakes-Recipe-1-1100x1650.jpg" },
                    { 2, 1, "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Thai-Chicken-Wild-Rice-Soup-Recipe-1.jpg" },
                    { 3, 1, "https://www.gimmesomeoven.com/wp-content/uploads/2019/08/Healthy-Broccoli-Chicken-Casserole-Recipe-6-1.jpg" },
                    { 4, 1, "https://www.gimmesomeoven.com/wp-content/uploads/2015/02/The-Best-Butternut-Squash-Soup-Recipe-1.jpg" },
                    { 5, 1, "https://www.gimmesomeoven.com/wp-content/uploads/2018/09/Healthy-Pumpkin-Muffins-Recipe-Gluten-Free-Vegan-2.jpg" },
                    { 6, 1, "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Healthy-Veggie-Quesadillas-Recipe-6-2.jpg" },
                    { 7, 1, "https://www.gimmesomeoven.com/wp-content/uploads/2019/07/Roasted-Broccoli-Chickpea-and-Farro-Bowls-Recipe-2-2.jpg" },
                    { 10, 1, "https://www.gimmesomeoven.com/wp-content/uploads/2018/11/Healthy-Green-Bean-Casserole-Recipe-1-2.jpg" },
                    { 9, 1, "https://www.gimmesomeoven.com/wp-content/uploads/2019/06/Thai-Basil-Beef-Noodle-Stir-Fry-Recipe-2.jpg" },
                    { 11, 1, "https://www.gimmesomeoven.com/wp-content/uploads/2013/10/Mulled-Wine-Recipe-1-2.jpg" },
                    { 12, 1, "https://www.gimmesomeoven.com/wp-content/uploads/2014/11/Brussels-Sprouts-Cranberry-and-Quinoa-Salad-Recipe-7.jpg" },
                    { 14, 1, "https://www.gimmesomeoven.com/wp-content/uploads/2019/11/Pecan-Pie-Recipe-4-4.jpg" },
                    { 15, 1, "https://www.gimmesomeoven.com/wp-content/uploads/2019/11/Tahini-Granola-Recipe-5-1.jpg" },
                    { 16, 1, "https://www.gimmesomeoven.com/wp-content/uploads/2019/11/Ranch-Buttermilk-Mashed-Potatoes-Recipe-1-4.jpg" },
                    { 17, 1, "https://www.gimmesomeoven.com/wp-content/uploads/2019/11/Instant-Pot-Mac-and-Cheese-Recipe-6.jpg" },
                    { 8, 1, "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Easy-Apple-Crisp-Recipe-1-3.jpg" },
                    { 13, 1, "https://www.gimmesomeoven.com/wp-content/uploads/2019/11/Savory-Sweet-Potato-Casserole-Recipe-2a-2.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "IX_Ratings_DishId",
                table: "Ratings",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DishCategories");

            migrationBuilder.DropTable(
                name: "DishIngredients");

            migrationBuilder.DropTable(
                name: "Favourites");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
