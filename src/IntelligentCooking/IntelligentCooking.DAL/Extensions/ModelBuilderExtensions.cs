using IntelligentCooking.Core.Entities;
using IntelligentCooking.DAL.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;

namespace IntelligentCooking.DAL.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SetConfigurations(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new DishCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new DishConfiguration());
            modelBuilder.ApplyConfiguration(new DishIngredientConfiguration());
            modelBuilder.ApplyConfiguration(new FavouriteConfiguration());
            modelBuilder.ApplyConfiguration(new IngredientConfiguration());
            modelBuilder.ApplyConfiguration(new LikeConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ImageConfiguration());
        }

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasData(
                    new Category
                    {
                        Id = 1,
                        Name = "Sweets",
                        ImageUrl =
                            "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Perfect-Buttermilk-Pancakes-Recipe-1-1100x1650.jpg"
                    },
                    new Category
                    {
                        Id = 2,
                        Name = "Soup",
                        ImageUrl =
                            "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Perfect-Buttermilk-Pancakes-Recipe-1-1100x1650.jpg"
                    },
                    new Category
                    {
                        Id = 3,
                        Name = "Italian",
                        ImageUrl =
                            "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Perfect-Buttermilk-Pancakes-Recipe-1-1100x1650.jpg"
                    },
                    new Category
                    {
                        Id = 4,
                        Name = "Thai",
                        ImageUrl =
                            "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Perfect-Buttermilk-Pancakes-Recipe-1-1100x1650.jpg"
                    },
                    new Category
                    {
                        Id = 5,
                        Name = "Breakfast",
                        ImageUrl =
                            "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Perfect-Buttermilk-Pancakes-Recipe-1-1100x1650.jpg"
                    },
                    new Category
                    {
                        Id = 6,
                        Name = "Quick and Easy",
                        ImageUrl =
                            "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Perfect-Buttermilk-Pancakes-Recipe-1-1100x1650.jpg"
                    },
                    new Category
                    {
                        Id = 7,
                        Name = "Vegetarian",
                        ImageUrl =
                            "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Perfect-Buttermilk-Pancakes-Recipe-1-1100x1650.jpg"
                    }
                );


            modelBuilder.Entity<Dish>()
                .HasData(
                    new Dish
                    {
                        Id = 1,
                        Name = "Buttermilk pancakes",
                        Recipe =
                            @"Whisk together the dry ingredients.  Flour, sugar, baking powder, baking soda, and salt.Whisk together the wet ingredients.In a separate medium bowl — buttermilk, melted butter, eggs and vanilla.Combine.Pour the wet ingredients over the dry and whisk until just combined.  (Don’t overmix, it’s ok for the batter to be a bit lumpy!) Let the batter sit at room temperature for 10 minutes to thicken up.Prepare the skillet or griddle.Preheat a griddle pan or large non - stick skillet over medium - high heat, or an electric griddle to 350°F.Cook the pancakes.Grease the griddle or skillet with a generous pat of butter.* Pour the batter in 1 / 2 * -cup dollops on the hot griddle — as many as will comfortably fit with room to flip the pancakes.Cook the pancakes until bubbles begin to pop on the top and the edges are set, about 3 minutes.Use a spatula to flip and cook for another 2 to 3 minutes, until golden brown.Transfer the pancakes to a plate and continue making pancakes until the batter is gone.Serve warm.  Serve the pancakes stacked high with plenty of maple syrup and extra butter, if desired.",
                        Time = new DateTime(2100),
                        Servings = 7,
                        Stars = 4,
                        Description = "This classic buttermilk pancakes recipe is easy to make and yields the most delicious, "
                                      + "fluffy, homemade pancakes.  See notes above for possible ingredient add-ins.",
                        Calories = 400,
                        Fats = 1,
                        Proteins = 32,
                        Carbohydrates = 32
                    },
                    new Dish
                    {
                        Id = 2,
                        Name = "Thai Chicken Wild Rice",
                        Recipe =
                            @"Cook the base of the soup. Whichever cooking method you choose, we will simmer the base soup ingredients (chicken, rice, broth, veggies and seasonings) until the rice is cooked and tender. Shred the chicken.Once the rice and chicken are tender,remove the cooked chicken and shred with two forks into bite - sized pieces, then add it back into the soup.  (Or alternately, you’re welcome to just cut the chicken into bite - sized pieces beforehand.) Season.Stir in the coconut milk.Then taste the soup and season with salt, pepper and / or extra Thai red curry paste as needed. Serve warm. Garnished with a squeeze of lime juice and fresh cilantro, plus an extra toppings that sound good.",
                        Time = new DateTime(3600),
                        Servings = 7,
                        Stars = 1,
                        Description = "This Thai Chicken Wild Rice recipe is full of the best fresh and creamy curry flavors, and "
                                      + "it’s easy to make in the Instant Pot, Crock-Pot or on the stovetop.",
                        Calories = 255,
                        Fats = 10,
                        Proteins = 8,
                        Carbohydrates = 15
                    },
                    new Dish
                    {
                        Id = 3,
                        Name = "Broccoli Chicken Casserole",
                        Recipe =
                            @"Cook the pasta and broccoli.  Cook the pasta in a large pot of boiling water (don’t forget to generously salt the water!) until it is al dente.  But — plot twist! — toss the broccoli florets into the water about 1 minute before the pasta is done cooking to give it a quick cook too.  Drain both. Make the mushroom sauce. Meanwhile, we’ll work on the sauce.  Sauté the onion, followed by the mushrooms and garlic in butter (or oil) until softened.  Stir in some flour and let it cook for 1 minute (this will help to thicken the sauce).  Then add in the stock, milk, Dijon, salt and pepper, and cook until the sauce reaches a simmer.  Stir in half of the shredded cheese, taste, and adjust any seasonings as needed. Put everything together.  In a large 9 x 13-inch baking dish, give everything a good toss — the cooked pasta, broccoli, mushroom sauce and chicken — until combined.Bake.  Bake uncovered for 15 minutes.  Then remove pan from the oven, sprinkle the remaining cheddar cheese evenly on top of the casserole, and bake for 10 more minutes or until the cheese is nice and melty. Enjoy! Serve nice and warm, garnished with extra black pepper and/or fresh herbs, if desired.",
                        Time = new DateTime(3600),
                        Servings = 7,
                        Stars = 1,
                        Description =
                            "This hearty Broccoli Chicken Casserole recipe is made with your choice of pasta, tender chicken and broccoli, and the most delicious creamy cheddar mushroom sauce.  See notes above for possible ingredient variations too.",
                        Calories = 199,
                        Fats = 7,
                        Proteins = 9,
                        Carbohydrates = 10
                    },
                    new Dish
                    {
                        Id = 4,
                        Name = "Butternut squash soup",
                        Recipe =
                            @"Combine your ingredients (minus the coconut milk) in a slow cooker*.  Roughly diced — don’t spend time perfectly chopping all of your ingredients.  Feel free to use a large (6-quart) slow cooker or a small (3.5- to 4-quart) slow cooker. Cook until tender.  Generally about 6-8 hours on low, or 3-4 hours on high.  Then remove and discard the sage and add in the coconut milk. Blend.  Either use an immersion blender to puree the soup until smooth.  Or you can transfer the soup in two batches to a traditional blender and puree it there.  (Just be extremely careful blending hot liquids; you do not want the blender to be too full.) Taste and season.  Add extra salt, pepper and/or cayenne if needed, to taste. Serve and enjoy!  Garnished with any of your favorite toppings.",
                        Time = new DateTime(3000),
                        Servings = 7,
                        Stars = 1,
                        Description =
                            "My all-time favorite Butternut Squash Soup recipe!  It’s super-easy to make, naturally gluten-free and vegan, and SO incredibly cozy and delicious.  Stovetop, Crock-Pot and Instant Pot instructions included below.",
                        Calories = 234,
                        Fats = 12,
                        Proteins = 20,
                        Carbohydrates = 13
                    },
                    new Dish
                    {
                        Id = 5,
                        Name = "Pumpkin muffins",
                        Recipe =
                            @"Make your oat “flour”: Add your oats to a blender or food processor and pulse until they reach a flour-like consistency. Combine your dry ingredients: Add the pumpkin pie spice, salt and baking soda, and pulse until evenly combined. Whisk together your wet ingredients: In a separate mixing bowl, whisk together the pumpkin, eggs, maple syrup, almond milk and vanilla until evenly combined. Combine the two.  Fold the dry ingredients in with the wet, and use a spatula to stir together until just combined.  (Try not to over-stir.) Fill your muffin cups.  Portion the batter evenly between 12 muffin cups.  (I always like to do this with a large cookie scoop.  You’ll need a heaping scoop of batter for this specific recipe — about 1/3 cup per muffin.)  Then sprinkle with a pinch of turbinado sugar, if you’d like. Bake.  Until a toothpick inserted in the center of a muffin comes out clean, about 15 minutes. Enjoy!  I love these muffins best fresh outta the oven.  But once they have cooled to room temperature, feel free to store them in a sealed container for up to 3 days, or freeze (wrapped tightly in plastic wrap) for up to 3 months.",
                        Time = new DateTime(1800),
                        Servings = 12,
                        Stars = 1,
                        Description =
                            "These healthy pumpkin muffins are naturally gluten-free, sweetened with maple syrup, quick and easy to make, and so perfecty pumpkin-y.",
                        Calories = 378,
                        Fats = 10,
                        Proteins = 12,
                        Carbohydrates = 15
                    },
                    new Dish
                    {
                        Id = 6,
                        Name = "Veggie quesadillas",
                        Recipe =
                            @"Heat 1 tablespoon olive oil over medium-high heat in a large non-stick sauté pan.  Add sweet potato and sauté for 5-6 minutes, stirring occasionally, until cooked through.  Transfer to a separate plate and set aside. Add the remaining 1 tablespoon oil to the pan.  Add the veggies and jalapeño, and sauté for 4-5 minutes.  Stir in the cooked sweet potato, black beans, cumin, chili powder, a generous pinch of salt and black pepper, and sauté for 2 more minutes.  Taste and add more salt, pepper and/or cumin if needed.  Transfer the mixture to a large bowl and set aside.  Rinse (or just wipe off) the sauté pan until it is clean. Return the sauté pan to the stove, and reduce heat to medium.  Place a tortilla* in the center of the pan and immediately sprinkle your desired amount of cheese evenly over the surface of the tortilla.  Add a few large spoonfuls (about 1 cup) of the veggie mixture on one half of the tortilla, then sprinkle on some cilantro.  Fold the other side of the tortilla over to create a half moon.  Continue cooking for another 30 seconds or so, or until the bottom of the tortilla is crisp and golden.  (Just lift it up and take a peek to see when it’s ready to go.)  Then carefully flip the tortilla over and cook it for an additional 30-60 seconds on the second side. Transfer to a serving plate*, slice into triangles, then repeat with the remaining ingredients. Serve warm, along with your favorite salsa, guacamole and/or sour cream for dipping.",
                        Time = new DateTime(2400),
                        Servings = 7,
                        Stars = 1,
                        Description =
                            "These Easy Veggie Quesadillas are 100% customizable with whatever veggies you have on hand or happen to love most.  See notes above for possible ingredient variations!",
                        Calories = 268,
                        Fats = 13,
                        Proteins = 18,
                        Carbohydrates = 16
                    },
                    new Dish
                    {
                        Id = 7,
                        Name = "Roasted Broccoli and Farro Bowls",
                        Recipe =
                            @"Roast the broccoli.  I detailed how to do this in yesterday’s post.  Basically, toss in oil, season with S&P and roast over high heat! Cook the farro.  On the stovetop, in veggie stock (instead of water) for extra flavor. Make the dressing.  Whisk all of the ingredients together in a small bowl (or shake together in a mason jar) until combined. Toss everything together.  Then in a large bowl, combine the broccoli, farro, arugula, chickpeas, almonds and dressing.  Toss to combine. Serve or refrigerate for later.  Then serve it up immediately, or transfer the salad to a sealed container and refrigerate for up to 3 days.",
                        Time = new DateTime(1800),
                        Servings = 12,
                        Stars = 1,
                        Description =
                            "The beauty of this salad is that it keeps really well in the fridge, so feel free to prep it in advance if you’d like! ",
                        Calories = 345,
                        Fats = 13,
                        Proteins = 18,
                        Carbohydrates = 15
                    },
                    new Dish
                    {
                        Id = 8,
                        Name = "Apple Crisp",
                        Recipe =
                            @"Make the filling. Toss together the apples, lemon juice, brown sugar, flour and cinnamon until combined.  Then spread everything out in an even layer in a 9 x 13-inch baking dish. Make the topping.  Stir together the oats, flour, brown sugar, pecans, cinnamon and salt until combined.  Then drizzle with the melted butter and toss together until the dry ingredients are moistened, yet still nice and clumpy (not over-mixed). Bake. Sprinkle the topping over the apples, then pop the pan in the oven and bake for about 40-50 minutes, or until the filling is bubbly and the topping is nice and crisp. Serve.  Dish it up while the apple crisp is nice and warm, topped with a generous scoop of vanilla ice cream",
                        Time = new DateTime(1800),
                        Servings = 12,
                        Stars = 1,
                        Description =
                            "This easy apple crisp (apple crumble) recipe is made with a warm cinnamon apple filling and an irresistible buttery crunchy crumble topping.  Plus this no-fuss version takes less than 20 minutes to prep — no apple peeling required!",
                        Calories = 390,
                        Fats = 14,
                        Proteins = 19,
                        Carbohydrates = 15
                    },
                    new Dish
                    {
                        Id = 9,
                        Name = "Thai Basil Beef Noodle Stir-Fry",
                        Recipe =
                            @"Prep the sauce. Whisk the sauce ingredients together in a small bowl or measuring cup until combined. Prep the noodles.  Cook the noodles according to package instructions until they are al dente.  Then drain and set aside until ready to use. Sear the beef.  Heat some cooking oil in a large sauté pan or wok over medium-high heat.  Cook the beef briefly until it is browned on both sides.  Then transfer it to a separate (clean) plate, and return the pan to the heat. Cook the veggies.  Give the veggies a quick sauté until they are cooked through. Combine everything together.  Then add the cooked noodles, sauce, beef, and Thai basil to the pan, and toss until everything is coated evenly with the sauce. Serve warm.  Serve immediately while the stir-fry is nice and hot, garnished with any of your desired toppings.",
                        Time = new DateTime(1800),
                        Servings = 12,
                        Stars = 1,
                        Description =
                            "This Thai Basil Beef Noodle Stir-Fry recipe is easy to make and tossed with the best savory Thai basil sauce.  Feel free to sub in chicken, pork, shrimp or crispy tofu in place of the beef if you would like!",
                        Calories = 390,
                        Fats = 15,
                        Proteins = 17,
                        Carbohydrates = 18
                    }
                );

            modelBuilder.Entity<Image>()
                .HasData(
                    new Image
                    {
                        DishId = 1,
                        Url =
                            "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Perfect-Buttermilk-Pancakes-Recipe-1-1100x1650.jpg",
                        Priority = 1
                    },
                    new Image
                    {
                        DishId = 2,
                        Url =
                            "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Perfect-Buttermilk-Pancakes-Recipe-1-1100x1650.jpg",
                        Priority = 1
                    },
                    new Image
                    {
                        DishId = 3,
                        Url =
                            "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Perfect-Buttermilk-Pancakes-Recipe-1-1100x1650.jpg",
                        Priority = 1
                    },
                    new Image
                    {
                        DishId = 4,
                        Url =
                            "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Perfect-Buttermilk-Pancakes-Recipe-1-1100x1650.jpg",
                        Priority = 1
                    },
                    new Image
                    {
                        DishId = 5,
                        Url =
                            "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Perfect-Buttermilk-Pancakes-Recipe-1-1100x1650.jpg",
                        Priority = 1
                    },
                    new Image
                    {
                        DishId = 6,
                        Url =
                            "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Perfect-Buttermilk-Pancakes-Recipe-1-1100x1650.jpg",
                        Priority = 1
                    },
                    new Image
                    {
                        DishId = 7,
                        Url =
                            "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Perfect-Buttermilk-Pancakes-Recipe-1-1100x1650.jpg",
                        Priority = 1
                    },
                    new Image
                    {
                        DishId = 8,
                        Url =
                            "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Perfect-Buttermilk-Pancakes-Recipe-1-1100x1650.jpg",
                        Priority = 1
                    },
                    new Image
                    {
                        DishId = 9,
                        Url =
                            "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Perfect-Buttermilk-Pancakes-Recipe-1-1100x1650.jpg",
                        Priority = 1
                    });

            modelBuilder.Entity<Ingredient>()
                .HasData(
                    new Ingredient
                    {
                        Id = 1,
                        Name = "flour",
                        Description = "all-purpose"
                    },
                    new Ingredient
                    {
                        Id = 2,
                        Name = "sugar",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 3,
                        Name = "baking powder",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 4,
                        Name = "baking soda",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 5,
                        Name = "sea salt",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 6,
                        Name = "buttermilk",
                        Description = "at room temperature"
                    },
                    new Ingredient
                    {
                        Id = 7,
                        Name = "unsalted butter",
                        Description = "melted and cooled to room temperature, plus more for cooking"
                    },
                    new Ingredient
                    {
                        Id = 8,
                        Name = "eggs",
                        Description = "slightly beaten, at room temperature"
                    },
                    new Ingredient
                    {
                        Id = 9,
                        Name = "vanilla extract",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 10,
                        Name = "maple syrup",
                        Description = "for serving"
                    }
                );

            modelBuilder.Entity<DishCategory>()
                .HasData(
                    new DishCategory
                    {
                        DishId = 1,
                        CategoryId = 1
                    },
                    new DishCategory
                    {
                        DishId = 1,
                        CategoryId = 5
                    },

                    //fake data
                    new DishCategory
                    {
                        DishId = 2,
                        CategoryId = 5
                    },
                    new DishCategory
                    {
                        DishId = 3,
                        CategoryId = 5
                    },
                    new DishCategory
                    {
                        DishId = 4,
                        CategoryId = 5
                    },
                    new DishCategory
                    {
                        DishId = 5,
                        CategoryId = 5
                    },
                    new DishCategory
                    {
                        DishId = 6,
                        CategoryId = 5
                    },
                    new DishCategory
                    {
                        DishId = 7,
                        CategoryId = 5
                    },
                    new DishCategory
                    {
                        DishId = 8,
                        CategoryId = 5
                    },
                    new DishCategory
                    {
                        DishId = 9,
                        CategoryId = 5
                    }
                );

            modelBuilder.Entity<DishIngredient>()
                .HasData(
                    new DishIngredient
                    {
                        DishId = 1,
                        IngredientId = 1,
                        Amount = "2 1/2 cups"
                    },
                    new DishIngredient
                    {
                        DishId = 1,
                        IngredientId = 2,
                        Amount = "2 tablespoons"
                    },
                    new DishIngredient
                    {
                        DishId = 1,
                        IngredientId = 3,
                        Amount = "4 teaspoons"
                    },
                    new DishIngredient
                    {
                        DishId = 1,
                        IngredientId = 4,
                        Amount = "1 teaspoon"
                    },
                    new DishIngredient
                    {
                        DishId = 1,
                        IngredientId = 5,
                        Amount = "3/4 teaspoon"
                    },
                    new DishIngredient
                    {
                        DishId = 1,
                        IngredientId = 6,
                        Amount = "3 cups"
                    },
                    new DishIngredient
                    {
                        DishId = 1,
                        IngredientId = 7,
                        Amount = "4 tablespoons"
                    },
                    new DishIngredient
                    {
                        DishId = 1,
                        IngredientId = 8,
                        Amount = "2 large"
                    },
                    new DishIngredient
                    {
                        DishId = 1,
                        IngredientId = 9,
                        Amount = "1 teaspoon"
                    },
                    new DishIngredient
                    {
                        DishId = 1,
                        IngredientId = 10,
                        Amount = "as mush as you want"
                    },

                    //fake data
                    new DishIngredient
                    {
                        DishId = 2,
                        IngredientId = 10,
                        Amount = "as mush as you want"
                    },
                    new DishIngredient
                    {
                        DishId = 3,
                        IngredientId = 10,
                        Amount = "as mush as you want"
                    },
                    new DishIngredient
                    {
                        DishId = 4,
                        IngredientId = 10,
                        Amount = "as mush as you want"
                    },
                    new DishIngredient
                    {
                        DishId = 5,
                        IngredientId = 10,
                        Amount = "as mush as you want"
                    },
                    new DishIngredient
                    {
                        DishId = 6,
                        IngredientId = 10,
                        Amount = "as mush as you want"
                    },
                    new DishIngredient
                    {
                        DishId = 7,
                        IngredientId = 10,
                        Amount = "as mush as you want"
                    },
                    new DishIngredient
                    {
                        DishId = 8,
                        IngredientId = 10,
                        Amount = "as mush as you want"
                    },
                    new DishIngredient
                    {
                        DishId = 9,
                        IngredientId = 10,
                        Amount = "as mush as you want"
                    }
                );

            modelBuilder.Entity<Like>()
                .HasData(
                );
        }
    }
}
