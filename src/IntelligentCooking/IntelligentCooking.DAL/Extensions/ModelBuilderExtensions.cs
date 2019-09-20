using IntelligentCooking.Core.Entities;
using IntelligentCooking.DAL.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntelligentCooking.DAL.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SetConfigurations(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Category>(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration<DishCategory>(new DishCategoryConfiguration());
            modelBuilder.ApplyConfiguration<Dish>(new DishConfiguration());
            modelBuilder.ApplyConfiguration<DishIngredient>(new DishIngredientConfiguration());
            modelBuilder.ApplyConfiguration<Favourite>(new FavouriteConfiguration());
            modelBuilder.ApplyConfiguration<Ingredient>(new IngredientConfiguration());
            modelBuilder.ApplyConfiguration<Like>(new LikeConfiguration());
            modelBuilder.ApplyConfiguration<User>(new UserConfiguration());
        }

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                    new Category
                    {
                        CategoryId = 1,
                        Name = "sweets"
                    },
                    new Category
                    {
                        CategoryId = 2,
                        Name = "soup"
                    },
                    new Category
                    {
                        CategoryId = 3,
                        Name = "Italian"
                    },
                    new Category
                    {
                        CategoryId = 4,
                        Name = "Thai"
                    },
                    new Category
                    {
                        CategoryId = 5,
                        Name = "breakfast"
                    }
                );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    Login = "Tom",
                    Email = "tom@gmail.com",
                    Password = "tom123",
                    IsAdmin = true
                },
                new User
                {
                    UserId = 2,
                    Login = "Ann",
                    Email = "ann@gmail.com",
                    Password = "ann456",
                    IsAdmin = false
                },
                new User
                {
                    UserId = 3,
                    Login = "Rob",
                    Email = "rob@gmail.com",
                    Password = "rob789",
                    IsAdmin = false
                }
            );

            modelBuilder.Entity<Dish>().HasData(
                new Dish
                {
                    DishId = 1,
                    Name = "Buttermilk pancakes",
                    ImageUrl = "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Perfect-Buttermilk-Pancakes-Recipe-1-1100x1650.jpg",
                    Recipe = @"Whisk together the dry ingredients.  Flour, sugar, baking powder, baking soda, and salt.Whisk together the wet ingredients.In a separate medium bowl — buttermilk, melted butter, eggs and vanilla.Combine.Pour the wet ingredients over the dry and whisk until just combined.  (Don’t overmix, it’s ok for the batter to be a bit lumpy!) Let the batter sit at room temperature for 10 minutes to thicken up.Prepare the skillet or griddle.Preheat a griddle pan or large non - stick skillet over medium - high heat, or an electric griddle to 350°F.Cook the pancakes.Grease the griddle or skillet with a generous pat of butter.* Pour the batter in 1 / 2 * -cup dollops on the hot griddle — as many as will comfortably fit with room to flip the pancakes.Cook the pancakes until bubbles begin to pop on the top and the edges are set, about 3 minutes.Use a spatula to flip and cook for another 2 to 3 minutes, until golden brown.Transfer the pancakes to a plate and continue making pancakes until the batter is gone.Serve warm.  Serve the pancakes stacked high with plenty of maple syrup and extra butter, if desired.",
                    Time = new DateTime(2100),
                    Servings = 7,
                    Stars = 1,
                    Description = "This classic buttermilk pancakes recipe is easy to make and yields the most delicious, " +
                    "fluffy, homemade pancakes.  See notes above for possible ingredient add-ins."
                },
                new Dish
                {
                    DishId = 2,
                    Name = "Thai Chicken Wild Rice",
                    ImageUrl = "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Thai-Chicken-Wild-Rice-Soup-Recipe-1.jpg",
                    Recipe = @"Cook the base of the soup. Whichever cooking method you choose, we will simmer the base soup ingredients (chicken, rice, broth, veggies and seasonings) until the rice is cooked and tender. Shred the chicken.Once the rice and chicken are tender,remove the cooked chicken and shred with two forks into bite - sized pieces, then add it back into the soup.  (Or alternately, you’re welcome to just cut the chicken into bite - sized pieces beforehand.) Season.Stir in the coconut milk.Then taste the soup and season with salt, pepper and / or extra Thai red curry paste as needed. Serve warm. Garnished with a squeeze of lime juice and fresh cilantro, plus an extra toppings that sound good.",
                    Time = new DateTime(3600),
                    Servings = 7,
                    Stars = 1,
                    Description = "This Thai Chicken Wild Rice recipe is full of the best fresh and creamy curry flavors, and " +
                    "it’s easy to make in the Instant Pot, Crock-Pot or on the stovetop."
                },
                new Dish
                {
                    DishId = 3,
                    Name = "Broccoli Chicken Casserole",
                    ImageUrl = "https://www.gimmesomeoven.com/wp-content/uploads/2019/08/Healthy-Broccoli-Chicken-Casserole-Recipe-7.jpg",
                    Recipe = @"Cook the pasta and broccoli.  Cook the pasta in a large pot of boiling water (don’t forget to generously salt the water!) until it is al dente.  But — plot twist! — toss the broccoli florets into the water about 1 minute before the pasta is done cooking to give it a quick cook too.  Drain both. Make the mushroom sauce. Meanwhile, we’ll work on the sauce.  Sauté the onion, followed by the mushrooms and garlic in butter (or oil) until softened.  Stir in some flour and let it cook for 1 minute (this will help to thicken the sauce).  Then add in the stock, milk, Dijon, salt and pepper, and cook until the sauce reaches a simmer.  Stir in half of the shredded cheese, taste, and adjust any seasonings as needed. Put everything together.  In a large 9 x 13-inch baking dish, give everything a good toss — the cooked pasta, broccoli, mushroom sauce and chicken — until combined.Bake.  Bake uncovered for 15 minutes.  Then remove pan from the oven, sprinkle the remaining cheddar cheese evenly on top of the casserole, and bake for 10 more minutes or until the cheese is nice and melty. Enjoy! Serve nice and warm, garnished with extra black pepper and/or fresh herbs, if desired.",
                    Time = new DateTime(3600),
                    Servings = 7,
                    Stars = 1,
                    Description = "This hearty Broccoli Chicken Casserole recipe is made with your choice of pasta, tender chicken and broccoli, and the most delicious creamy cheddar mushroom sauce.  See notes above for possible ingredient variations too."
                },
                new Dish
                {
                    DishId = 4,
                    Name = "Butternut squash soup",
                    ImageUrl = "https://www.gimmesomeoven.com/wp-content/uploads/2015/02/The-Best-Butternut-Squash-Soup-Recipe-1.jpg",
                    Recipe = @"Combine your ingredients (minus the coconut milk) in a slow cooker*.  Roughly diced — don’t spend time perfectly chopping all of your ingredients.  Feel free to use a large (6-quart) slow cooker or a small (3.5- to 4-quart) slow cooker. Cook until tender.  Generally about 6-8 hours on low, or 3-4 hours on high.  Then remove and discard the sage and add in the coconut milk. Blend.  Either use an immersion blender to puree the soup until smooth.  Or you can transfer the soup in two batches to a traditional blender and puree it there.  (Just be extremely careful blending hot liquids; you do not want the blender to be too full.) Taste and season.  Add extra salt, pepper and/or cayenne if needed, to taste. Serve and enjoy!  Garnished with any of your favorite toppings.",
                    Time = new DateTime(3000),
                    Servings = 7,
                    Stars = 1,
                    Description = "My all-time favorite Butternut Squash Soup recipe!  It’s super-easy to make, naturally gluten-free and vegan, and SO incredibly cozy and delicious.  Stovetop, Crock-Pot and Instant Pot instructions included below."
                },
                new Dish
                {
                    DishId = 5,
                    Name = "Pumpkin muffins",
                    ImageUrl = "https://www.gimmesomeoven.com/wp-content/uploads/2018/09/Healthy-Pumpkin-Muffins-Recipe-Gluten-Free-Vegan-2.jpg",
                    Recipe = @"Make your oat “flour”: Add your oats to a blender or food processor and pulse until they reach a flour-like consistency. Combine your dry ingredients: Add the pumpkin pie spice, salt and baking soda, and pulse until evenly combined. Whisk together your wet ingredients: In a separate mixing bowl, whisk together the pumpkin, eggs, maple syrup, almond milk and vanilla until evenly combined. Combine the two.  Fold the dry ingredients in with the wet, and use a spatula to stir together until just combined.  (Try not to over-stir.) Fill your muffin cups.  Portion the batter evenly between 12 muffin cups.  (I always like to do this with a large cookie scoop.  You’ll need a heaping scoop of batter for this specific recipe — about 1/3 cup per muffin.)  Then sprinkle with a pinch of turbinado sugar, if you’d like. Bake.  Until a toothpick inserted in the center of a muffin comes out clean, about 15 minutes. Enjoy!  I love these muffins best fresh outta the oven.  But once they have cooled to room temperature, feel free to store them in a sealed container for up to 3 days, or freeze (wrapped tightly in plastic wrap) for up to 3 months.",
                    Time = new DateTime(1800),
                    Servings = 12,
                    Stars = 1,
                    Description = "These healthy pumpkin muffins are naturally gluten-free, sweetened with maple syrup, quick and easy to make, and so perfecty pumpkin-y."
                }
                );

            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient
                {
                    IngnredientId = 1,
                    Name = "flour",
                    Description = "all-purpose"
                },
                new Ingredient
                {
                    IngnredientId = 2,
                    Name = "sugar",
                    Description = ""
                },
                new Ingredient
                {
                    IngnredientId = 3,
                    Name = "baking powder",
                    Description = ""
                },
                new Ingredient
                {
                    IngnredientId = 4,
                    Name = "baking soda",
                    Description = ""
                },
                new Ingredient
                {
                    IngnredientId = 5,
                    Name = "sea salt",
                    Description = ""
                },
                new Ingredient
                {
                    IngnredientId = 6,
                    Name = "buttermilk",
                    Description = "at room temperature"
                },
                new Ingredient
                {
                    IngnredientId = 7,
                    Name = "unsalted butter",
                    Description = "melted and cooled to room temperature, plus more for cooking"
                },
                new Ingredient
                {
                    IngnredientId = 8,
                    Name = "eggs",
                    Description = "slightly beaten, at room temperature"
                },
                new Ingredient
                {
                    IngnredientId = 9,
                    Name = "vanilla extract",
                    Description = ""
                },
                new Ingredient
                {
                    IngnredientId = 10,
                    Name = "maple syrup",
                    Description = "for serving"
                }
                );

            modelBuilder.Entity<DishCategory>().HasData(
                new DishCategory
                {
                    DishId = 1,
                    CategoryId = 1
                },
                new DishCategory
                {
                    DishId = 1,
                    CategoryId = 5
                }
                );

            modelBuilder.Entity<DishIngredient>().HasData(
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
                }
                );

            modelBuilder.Entity<Favourite>().HasData(
                new Favourite
                {
                    UserId = 1,
                    DishId = 1
                },
                new Favourite
                {
                    UserId = 1,
                    DishId = 2
                },
                new Favourite
                {
                    UserId = 2,
                    DishId = 3
                },
                new Favourite
                {
                    UserId = 2,
                    DishId = 4
                },
                new Favourite
                {
                    UserId = 3,
                    DishId = 5
                }
                );

            modelBuilder.Entity<Like>().HasData(
                new Like
                {
                    UserId = 1,
                    DishId = 1
                },
                new Like
                {
                    UserId = 1,
                    DishId = 2
                },
                new Like
                {
                    UserId = 2,
                    DishId = 3
                },
                new Like
                {
                    UserId = 2,
                    DishId = 4
                },
                new Like
                {
                    UserId = 3,
                    DishId = 5
                }
                );
        }
    }
}
