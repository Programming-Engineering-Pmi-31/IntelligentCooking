﻿// <auto-generated />
using System;
using IntelligentCooking.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IntelligentCooking.DAL.Migrations
{
    [DbContext(typeof(IntelligentCookingContext))]
    partial class IntelligentCookingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IntelligentCooking.Core.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Categories");

                    b.HasData(
                        new { Id = 1, Name = "Sweets" },
                        new { Id = 2, Name = "Soup" },
                        new { Id = 3, Name = "Italian" },
                        new { Id = 4, Name = "Thai" },
                        new { Id = 5, Name = "Breakfast" },
                        new { Id = 6, Name = "Quick and Easy" },
                        new { Id = 7, Name = "Vegetarian" }
                    );
                });

            modelBuilder.Entity("IntelligentCooking.Core.Entities.Dish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Calories");

                    b.Property<double?>("Carbohydrates");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<double?>("Fats");

                    b.Property<string>("ImageUrl")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<double?>("Proteins");

                    b.Property<string>("Recipe")
                        .IsRequired();

                    b.Property<int>("Servings");

                    b.Property<int>("Stars");

                    b.Property<DateTime>("Time");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Dishes");

                    b.HasData(
                        new { Id = 1, Calories = 400, Carbohydrates = 32.0, Description = "This classic buttermilk pancakes recipe is easy to make and yields the most delicious, fluffy, homemade pancakes.  See notes above for possible ingredient add-ins.", Fats = 1.0, ImageUrl = "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Perfect-Buttermilk-Pancakes-Recipe-1-1100x1650.jpg", Name = "Buttermilk pancakes", Proteins = 32.0, Recipe = "Whisk together the dry ingredients.  Flour, sugar, baking powder, baking soda, and salt.Whisk together the wet ingredients.In a separate medium bowl — buttermilk, melted butter, eggs and vanilla.Combine.Pour the wet ingredients over the dry and whisk until just combined.  (Don’t overmix, it’s ok for the batter to be a bit lumpy!) Let the batter sit at room temperature for 10 minutes to thicken up.Prepare the skillet or griddle.Preheat a griddle pan or large non - stick skillet over medium - high heat, or an electric griddle to 350°F.Cook the pancakes.Grease the griddle or skillet with a generous pat of butter.* Pour the batter in 1 / 2 * -cup dollops on the hot griddle — as many as will comfortably fit with room to flip the pancakes.Cook the pancakes until bubbles begin to pop on the top and the edges are set, about 3 minutes.Use a spatula to flip and cook for another 2 to 3 minutes, until golden brown.Transfer the pancakes to a plate and continue making pancakes until the batter is gone.Serve warm.  Serve the pancakes stacked high with plenty of maple syrup and extra butter, if desired.", Servings = 7, Stars = 4, Time = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { Id = 2, Calories = 255, Carbohydrates = 15.0, Description = "This Thai Chicken Wild Rice recipe is full of the best fresh and creamy curry flavors, and it’s easy to make in the Instant Pot, Crock-Pot or on the stovetop.", Fats = 10.0, ImageUrl = "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Thai-Chicken-Wild-Rice-Soup-Recipe-1.jpg", Name = "Thai Chicken Wild Rice", Proteins = 8.0, Recipe = "Cook the base of the soup. Whichever cooking method you choose, we will simmer the base soup ingredients (chicken, rice, broth, veggies and seasonings) until the rice is cooked and tender. Shred the chicken.Once the rice and chicken are tender,remove the cooked chicken and shred with two forks into bite - sized pieces, then add it back into the soup.  (Or alternately, you’re welcome to just cut the chicken into bite - sized pieces beforehand.) Season.Stir in the coconut milk.Then taste the soup and season with salt, pepper and / or extra Thai red curry paste as needed. Serve warm. Garnished with a squeeze of lime juice and fresh cilantro, plus an extra toppings that sound good.", Servings = 7, Stars = 1, Time = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { Id = 3, Calories = 199, Carbohydrates = 10.0, Description = "This hearty Broccoli Chicken Casserole recipe is made with your choice of pasta, tender chicken and broccoli, and the most delicious creamy cheddar mushroom sauce.  See notes above for possible ingredient variations too.", Fats = 7.0, ImageUrl = "https://www.gimmesomeoven.com/wp-content/uploads/2019/08/Healthy-Broccoli-Chicken-Casserole-Recipe-7.jpg", Name = "Broccoli Chicken Casserole", Proteins = 9.0, Recipe = "Cook the pasta and broccoli.  Cook the pasta in a large pot of boiling water (don’t forget to generously salt the water!) until it is al dente.  But — plot twist! — toss the broccoli florets into the water about 1 minute before the pasta is done cooking to give it a quick cook too.  Drain both. Make the mushroom sauce. Meanwhile, we’ll work on the sauce.  Sauté the onion, followed by the mushrooms and garlic in butter (or oil) until softened.  Stir in some flour and let it cook for 1 minute (this will help to thicken the sauce).  Then add in the stock, milk, Dijon, salt and pepper, and cook until the sauce reaches a simmer.  Stir in half of the shredded cheese, taste, and adjust any seasonings as needed. Put everything together.  In a large 9 x 13-inch baking dish, give everything a good toss — the cooked pasta, broccoli, mushroom sauce and chicken — until combined.Bake.  Bake uncovered for 15 minutes.  Then remove pan from the oven, sprinkle the remaining cheddar cheese evenly on top of the casserole, and bake for 10 more minutes or until the cheese is nice and melty. Enjoy! Serve nice and warm, garnished with extra black pepper and/or fresh herbs, if desired.", Servings = 7, Stars = 1, Time = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { Id = 4, Calories = 234, Carbohydrates = 13.0, Description = "My all-time favorite Butternut Squash Soup recipe!  It’s super-easy to make, naturally gluten-free and vegan, and SO incredibly cozy and delicious.  Stovetop, Crock-Pot and Instant Pot instructions included below.", Fats = 12.0, ImageUrl = "https://www.gimmesomeoven.com/wp-content/uploads/2015/02/The-Best-Butternut-Squash-Soup-Recipe-1.jpg", Name = "Butternut squash soup", Proteins = 20.0, Recipe = "Combine your ingredients (minus the coconut milk) in a slow cooker*.  Roughly diced — don’t spend time perfectly chopping all of your ingredients.  Feel free to use a large (6-quart) slow cooker or a small (3.5- to 4-quart) slow cooker. Cook until tender.  Generally about 6-8 hours on low, or 3-4 hours on high.  Then remove and discard the sage and add in the coconut milk. Blend.  Either use an immersion blender to puree the soup until smooth.  Or you can transfer the soup in two batches to a traditional blender and puree it there.  (Just be extremely careful blending hot liquids; you do not want the blender to be too full.) Taste and season.  Add extra salt, pepper and/or cayenne if needed, to taste. Serve and enjoy!  Garnished with any of your favorite toppings.", Servings = 7, Stars = 1, Time = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { Id = 5, Calories = 378, Carbohydrates = 15.0, Description = "These healthy pumpkin muffins are naturally gluten-free, sweetened with maple syrup, quick and easy to make, and so perfecty pumpkin-y.", Fats = 10.0, ImageUrl = "https://www.gimmesomeoven.com/wp-content/uploads/2018/09/Healthy-Pumpkin-Muffins-Recipe-Gluten-Free-Vegan-2.jpg", Name = "Pumpkin muffins", Proteins = 12.0, Recipe = "Make your oat “flour”: Add your oats to a blender or food processor and pulse until they reach a flour-like consistency. Combine your dry ingredients: Add the pumpkin pie spice, salt and baking soda, and pulse until evenly combined. Whisk together your wet ingredients: In a separate mixing bowl, whisk together the pumpkin, eggs, maple syrup, almond milk and vanilla until evenly combined. Combine the two.  Fold the dry ingredients in with the wet, and use a spatula to stir together until just combined.  (Try not to over-stir.) Fill your muffin cups.  Portion the batter evenly between 12 muffin cups.  (I always like to do this with a large cookie scoop.  You’ll need a heaping scoop of batter for this specific recipe — about 1/3 cup per muffin.)  Then sprinkle with a pinch of turbinado sugar, if you’d like. Bake.  Until a toothpick inserted in the center of a muffin comes out clean, about 15 minutes. Enjoy!  I love these muffins best fresh outta the oven.  But once they have cooled to room temperature, feel free to store them in a sealed container for up to 3 days, or freeze (wrapped tightly in plastic wrap) for up to 3 months.", Servings = 12, Stars = 1, Time = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { Id = 6, Calories = 268, Carbohydrates = 16.0, Description = "These Easy Veggie Quesadillas are 100% customizable with whatever veggies you have on hand or happen to love most.  See notes above for possible ingredient variations!", Fats = 13.0, ImageUrl = "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Healthy-Veggie-Quesadillas-Recipe-6-2.jpg", Name = "Veggie quesadillas", Proteins = 18.0, Recipe = "Heat 1 tablespoon olive oil over medium-high heat in a large non-stick sauté pan.  Add sweet potato and sauté for 5-6 minutes, stirring occasionally, until cooked through.  Transfer to a separate plate and set aside. Add the remaining 1 tablespoon oil to the pan.  Add the veggies and jalapeño, and sauté for 4-5 minutes.  Stir in the cooked sweet potato, black beans, cumin, chili powder, a generous pinch of salt and black pepper, and sauté for 2 more minutes.  Taste and add more salt, pepper and/or cumin if needed.  Transfer the mixture to a large bowl and set aside.  Rinse (or just wipe off) the sauté pan until it is clean. Return the sauté pan to the stove, and reduce heat to medium.  Place a tortilla* in the center of the pan and immediately sprinkle your desired amount of cheese evenly over the surface of the tortilla.  Add a few large spoonfuls (about 1 cup) of the veggie mixture on one half of the tortilla, then sprinkle on some cilantro.  Fold the other side of the tortilla over to create a half moon.  Continue cooking for another 30 seconds or so, or until the bottom of the tortilla is crisp and golden.  (Just lift it up and take a peek to see when it’s ready to go.)  Then carefully flip the tortilla over and cook it for an additional 30-60 seconds on the second side. Transfer to a serving plate*, slice into triangles, then repeat with the remaining ingredients. Serve warm, along with your favorite salsa, guacamole and/or sour cream for dipping.", Servings = 7, Stars = 1, Time = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { Id = 7, Calories = 345, Carbohydrates = 15.0, Description = "The beauty of this salad is that it keeps really well in the fridge, so feel free to prep it in advance if you’d like! ", Fats = 13.0, ImageUrl = "https://www.gimmesomeoven.com/wp-content/uploads/2019/07/Roasted-Broccoli-Chickpea-and-Farro-Bowls-Recipe-2-2.jpg", Name = "Roasted Broccoli and Farro Bowls", Proteins = 18.0, Recipe = "Roast the broccoli.  I detailed how to do this in yesterday’s post.  Basically, toss in oil, season with S&P and roast over high heat! Cook the farro.  On the stovetop, in veggie stock (instead of water) for extra flavor. Make the dressing.  Whisk all of the ingredients together in a small bowl (or shake together in a mason jar) until combined. Toss everything together.  Then in a large bowl, combine the broccoli, farro, arugula, chickpeas, almonds and dressing.  Toss to combine. Serve or refrigerate for later.  Then serve it up immediately, or transfer the salad to a sealed container and refrigerate for up to 3 days.", Servings = 12, Stars = 1, Time = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { Id = 8, Calories = 390, Carbohydrates = 15.0, Description = "This easy apple crisp (apple crumble) recipe is made with a warm cinnamon apple filling and an irresistible buttery crunchy crumble topping.  Plus this no-fuss version takes less than 20 minutes to prep — no apple peeling required!", Fats = 14.0, ImageUrl = "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Easy-Apple-Crisp-Recipe-1-3.jpg", Name = "Apple Crisp", Proteins = 19.0, Recipe = "Make the filling. Toss together the apples, lemon juice, brown sugar, flour and cinnamon until combined.  Then spread everything out in an even layer in a 9 x 13-inch baking dish. Make the topping.  Stir together the oats, flour, brown sugar, pecans, cinnamon and salt until combined.  Then drizzle with the melted butter and toss together until the dry ingredients are moistened, yet still nice and clumpy (not over-mixed). Bake. Sprinkle the topping over the apples, then pop the pan in the oven and bake for about 40-50 minutes, or until the filling is bubbly and the topping is nice and crisp. Serve.  Dish it up while the apple crisp is nice and warm, topped with a generous scoop of vanilla ice cream", Servings = 12, Stars = 1, Time = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { Id = 9, Calories = 390, Carbohydrates = 18.0, Description = "This Thai Basil Beef Noodle Stir-Fry recipe is easy to make and tossed with the best savory Thai basil sauce.  Feel free to sub in chicken, pork, shrimp or crispy tofu in place of the beef if you would like!", Fats = 15.0, ImageUrl = "https://www.gimmesomeoven.com/wp-content/uploads/2019/06/Thai-Basil-Beef-Noodle-Stir-Fry-Recipe-2.jpg", Name = "Thai Basil Beef Noodle Stir-Fry", Proteins = 17.0, Recipe = "Prep the sauce. Whisk the sauce ingredients together in a small bowl or measuring cup until combined. Prep the noodles.  Cook the noodles according to package instructions until they are al dente.  Then drain and set aside until ready to use. Sear the beef.  Heat some cooking oil in a large sauté pan or wok over medium-high heat.  Cook the beef briefly until it is browned on both sides.  Then transfer it to a separate (clean) plate, and return the pan to the heat. Cook the veggies.  Give the veggies a quick sauté until they are cooked through. Combine everything together.  Then add the cooked noodles, sauce, beef, and Thai basil to the pan, and toss until everything is coated evenly with the sauce. Serve warm.  Serve immediately while the stir-fry is nice and hot, garnished with any of your desired toppings.", Servings = 12, Stars = 1, Time = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                    );
                });

            modelBuilder.Entity("IntelligentCooking.Core.Entities.DishCategory", b =>
                {
                    b.Property<int>("CategoryId");

                    b.Property<int>("DishId");

                    b.HasKey("CategoryId", "DishId");

                    b.HasIndex("DishId");

                    b.ToTable("DishCategories");

                    b.HasData(
                        new { CategoryId = 1, DishId = 1 },
                        new { CategoryId = 5, DishId = 1 },
                        new { CategoryId = 5, DishId = 2 },
                        new { CategoryId = 5, DishId = 3 },
                        new { CategoryId = 5, DishId = 4 },
                        new { CategoryId = 5, DishId = 5 },
                        new { CategoryId = 5, DishId = 6 },
                        new { CategoryId = 5, DishId = 7 },
                        new { CategoryId = 5, DishId = 8 },
                        new { CategoryId = 5, DishId = 9 }
                    );
                });

            modelBuilder.Entity("IntelligentCooking.Core.Entities.DishIngredient", b =>
                {
                    b.Property<int>("DishId");

                    b.Property<int>("IngredientId");

                    b.Property<string>("Amount")
                        .IsRequired();

                    b.HasKey("DishId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("DishIngredients");

                    b.HasData(
                        new { DishId = 1, IngredientId = 1, Amount = "2 1/2 cups" },
                        new { DishId = 1, IngredientId = 2, Amount = "2 tablespoons" },
                        new { DishId = 1, IngredientId = 3, Amount = "4 teaspoons" },
                        new { DishId = 1, IngredientId = 4, Amount = "1 teaspoon" },
                        new { DishId = 1, IngredientId = 5, Amount = "3/4 teaspoon" },
                        new { DishId = 1, IngredientId = 6, Amount = "3 cups" },
                        new { DishId = 1, IngredientId = 7, Amount = "4 tablespoons" },
                        new { DishId = 1, IngredientId = 8, Amount = "2 large" },
                        new { DishId = 1, IngredientId = 9, Amount = "1 teaspoon" },
                        new { DishId = 1, IngredientId = 10, Amount = "as mush as you want" },
                        new { DishId = 2, IngredientId = 10, Amount = "as mush as you want" },
                        new { DishId = 3, IngredientId = 10, Amount = "as mush as you want" },
                        new { DishId = 4, IngredientId = 10, Amount = "as mush as you want" },
                        new { DishId = 5, IngredientId = 10, Amount = "as mush as you want" },
                        new { DishId = 6, IngredientId = 10, Amount = "as mush as you want" },
                        new { DishId = 7, IngredientId = 10, Amount = "as mush as you want" },
                        new { DishId = 8, IngredientId = 10, Amount = "as mush as you want" },
                        new { DishId = 9, IngredientId = 10, Amount = "as mush as you want" }
                    );
                });

            modelBuilder.Entity("IntelligentCooking.Core.Entities.Favourite", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("DishId");

                    b.HasKey("UserId", "DishId");

                    b.HasIndex("DishId");

                    b.ToTable("Favourites");
                });

            modelBuilder.Entity("IntelligentCooking.Core.Entities.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Ingredients");

                    b.HasData(
                        new { Id = 1, Description = "all-purpose", Name = "flour" },
                        new { Id = 2, Description = "", Name = "sugar" },
                        new { Id = 3, Description = "", Name = "baking powder" },
                        new { Id = 4, Description = "", Name = "baking soda" },
                        new { Id = 5, Description = "", Name = "sea salt" },
                        new { Id = 6, Description = "at room temperature", Name = "buttermilk" },
                        new { Id = 7, Description = "melted and cooled to room temperature, plus more for cooking", Name = "unsalted butter" },
                        new { Id = 8, Description = "slightly beaten, at room temperature", Name = "eggs" },
                        new { Id = 9, Description = "", Name = "vanilla extract" },
                        new { Id = 10, Description = "for serving", Name = "maple syrup" }
                    );
                });

            modelBuilder.Entity("IntelligentCooking.Core.Entities.Like", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("DishId");

                    b.HasKey("UserId", "DishId");

                    b.HasIndex("DishId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("IntelligentCooking.Core.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("IntelligentCooking.Core.Entities.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("IntelligentCooking.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("IntelligentCooking.Core.Entities.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("IntelligentCooking.Core.Entities.UserLogin", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("IntelligentCooking.Core.Entities.UserRole", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("IntelligentCooking.Core.Entities.UserToken", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("IntelligentCooking.Core.Entities.DishCategory", b =>
                {
                    b.HasOne("IntelligentCooking.Core.Entities.Category", "Category")
                        .WithMany("DishCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("IntelligentCooking.Core.Entities.Dish", "Dish")
                        .WithMany("DishCategories")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IntelligentCooking.Core.Entities.DishIngredient", b =>
                {
                    b.HasOne("IntelligentCooking.Core.Entities.Dish", "Dish")
                        .WithMany("DishIngredients")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IntelligentCooking.Core.Entities.Ingredient", "Ingredient")
                        .WithMany("DishIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("IntelligentCooking.Core.Entities.Favourite", b =>
                {
                    b.HasOne("IntelligentCooking.Core.Entities.Dish", "Dish")
                        .WithMany("Favourites")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IntelligentCooking.Core.Entities.User", "User")
                        .WithMany("Favourites")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IntelligentCooking.Core.Entities.Like", b =>
                {
                    b.HasOne("IntelligentCooking.Core.Entities.Dish", "Dish")
                        .WithMany("Likes")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IntelligentCooking.Core.Entities.User", "User")
                        .WithMany("Likes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IntelligentCooking.Core.Entities.RoleClaim", b =>
                {
                    b.HasOne("IntelligentCooking.Core.Entities.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IntelligentCooking.Core.Entities.UserClaim", b =>
                {
                    b.HasOne("IntelligentCooking.Core.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IntelligentCooking.Core.Entities.UserLogin", b =>
                {
                    b.HasOne("IntelligentCooking.Core.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IntelligentCooking.Core.Entities.UserRole", b =>
                {
                    b.HasOne("IntelligentCooking.Core.Entities.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IntelligentCooking.Core.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IntelligentCooking.Core.Entities.UserToken", b =>
                {
                    b.HasOne("IntelligentCooking.Core.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
