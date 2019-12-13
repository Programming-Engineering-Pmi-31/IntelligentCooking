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
            modelBuilder.ApplyConfiguration(new RatingConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ImageConfiguration());
            modelBuilder.ApplyConfiguration(new RefreshTokenConfiguration());
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
                             "https://ukrhealth.net/wp-content/uploads/2018/01/shutterstock_361496144-696x464.jpg"
                     },
                     new Category
                     {
                         Id = 2,
                         Name = "Soup",
                         ImageUrl =
                             "https://www.gimmesomeoven.com/wp-content/uploads/2015/02/The-Best-Butternut-Squash-Soup-Recipe-1.jpg"
                     },
                     new Category
                     {
                         Id = 3,
                         Name = "Italian",
                         ImageUrl =
                             "https://www.englishclub.com/images/vocabulary/food/italian/italian-food-640.jpg"
                     },
                     new Category
                     {
                         Id = 4,
                         Name = "Thai",
                         ImageUrl =
                             "https://www.untoldmorsels.com/wp-content/uploads/2018/08/thai-food-culture.jpg"
                     },
                     new Category
                     {
                         Id = 5,
                         Name = "Breakfast",
                         ImageUrl =
                             "https://olo-images-live.imgix.net/3a/3afe98ddcf4643a0b20c068b2c59f2ce.jpg?auto=format%2Ccompress&q=60&cs=tinysrgb&w=500&h=333&fit=fill&fm=png32&bg=transparent&s=862b0bcde81b3d6190fb8465f031a5cf"
                     },
                     new Category
                     {
                         Id = 6,
                         Name = "Quick and Easy",
                         ImageUrl =
                             "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Healthy-Veggie-Quesadillas-Recipe-6-2.jpg"
                     },
                     new Category
                     {
                         Id = 7,
                         Name = "Vegetarian",
                         ImageUrl =
                             "https://static.standard.co.uk/s3fs-public/thumbnails/image/2019/05/14/15/vegetarian-meal-14-05-19-0.jpg?w968"
                     },
                     new Category
                     {
                         Id = 8,
                         Name = "Drinks",
                         ImageUrl =
                             "https://img.thedailybeast.com/image/upload/c_crop,d_placeholder_euli9k,h_1440,w_2560,x_0,y_0/dpr_1.5/c_limit,w_1044/fl_lossy,q_auto/v1517521303/180131-wondrich-bad-cocktail-tease_wghhv8"
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
                        Time = new TimeSpan(0, 35, 0),
                        Servings = 7,
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
                        Name = "Thai Chicken Wild Rice Soup",
                        Recipe =
                            @"Cook the base of the soup. Whichever cooking method you choose, we will simmer the base soup ingredients (chicken, rice, broth, veggies and seasonings) until the rice is cooked and tender. Shred the chicken.Once the rice and chicken are tender,remove the cooked chicken and shred with two forks into bite - sized pieces, then add it back into the soup.  (Or alternately, you’re welcome to just cut the chicken into bite - sized pieces beforehand.) Season.Stir in the coconut milk.Then taste the soup and season with salt, pepper and / or extra Thai red curry paste as needed. Serve warm. Garnished with a squeeze of lime juice and fresh cilantro, plus an extra toppings that sound good.",
                        Time = new TimeSpan(0, 35, 0),
                        Servings = 7,
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
                        Time = new TimeSpan(1, 0, 0),
                        Servings = 7,
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
                        Time = new TimeSpan(0, 50, 0),
                        Servings = 7,
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
                        Time = new TimeSpan(0, 30, 0),
                        Servings = 12,
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
                        Time = new TimeSpan(0, 40, 0),
                        Servings = 7,
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
                        Time = new TimeSpan(0, 45, 0),
                        Servings = 12,
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
                        Time = new TimeSpan(0, 20, 0),
                        Servings = 12,
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
                        Time = new TimeSpan(1, 0, 0),
                        Servings = 12,
                        Description =
                            "This Thai Basil Beef Noodle Stir-Fry recipe is easy to make and tossed with the best savory Thai basil sauce.  Feel free to sub in chicken, pork, shrimp or crispy tofu in place of the beef if you would like!",
                        Calories = 390,
                        Fats = 15,
                        Proteins = 17,
                        Carbohydrates = 18
                    },
                    new Dish
                    {
                        Id = 10,
                        Name = "Green Bean Casserole",
                        Recipe =
                            @"Preheat oven.  Heat oven to 375°F. Trim, cut and briefly boil the green beans. Heat a large stockpot of water over high-heat until boiling. Meanwhile, trim and cut the green beans.  Then add the beans to the boiling water and cook for 3-5 minutes, depending on how crispy you like your green beans. (Keep in mind that the beans will cook more in the oven, so err on the side of undercooking them to your taste during this step.)  Then use a slotted spoon or large strainer to transfer the beans immediately into a large bowl of ice water, and give them a quick stir.  This will prevent them from cooking longer.  Set aside. Prepare your crispy onion topping.  Melt 1/2 tablespoon butter (or olive oil) in a large sauté pan over medium-high heat.  Add the onion and sauté for 2-3 minutes, stirring occasionally, until the onion is partially cooked but still holds its shape.  (You don’t want the onion to get too soft.)  Transfer the onion to a clean bowl.  Add the remaining 1/2 tablespoon butter to the sauté pan, along with the panko, and stir to combine.  Cook for 2-3 minutes, stirring constantly, until the panko is lightly golden.  Remove from heat, and transfer the panko to the bowl with the onions.  Add in the Parmesan, salt and pepper, and toss the onion mixture until evenly combined.  Set aside. Prepare your mushroom alfredo sauce.  Briefly rinse and dry the sauté pan.  Then return it to the stove.  Melt the butter over medium-high heat. Then add the mushrooms and sauté for 5 minutes, stirring occasionally, until lightly browned and soft.  Add the garlic and sauté for 1-2 more minutes, stirring occasionally, until fragrant.  Stir in the flour and sauté for 1 more minute, stirring occasionally.  Then add in the vegetable stock, and stir until the flour is evenly dissolved.  Add the milk and Parmesan, and stir to combine.  Continue cooking the sauce until it reaches a simmer and thickens.  Then remove from heat, and season with salt and pepper to taste. Put it all together!  Combine the green beans and mushroom alfredo sauce in the stockpot, and stir the green bean mixture until evenly combined.  Transfer to a 9 x 13-inch baking dish, and spread the green bean mixture out in an even layer.  Sprinkle evenly with the crispy onion topping mixture. Bake.  Then bake for about 25 minutes, or until the crispy onion topping is golden and crispy.  (Keep an eye on it so that it does not burn.  If it does start to char, simply lay a piece of aluminum foil on top of the casserole.) Serve warm.  Remove from the oven and serve warm, garnished with extra freshly-cracked black pepper (plus maybe some parsley) if you’d like.",
                        Time = new TimeSpan(1, 0, 0),
                        Servings = 10,
                        Description =
                            "This easy Green Bean Casserole recipe is made from scratch with lightened-up ingredients, it’s nice and fresh and crispy, and it is full of the absolute best flavors.  Always a crowd fave!",
                        Calories = 380,
                        Fats = 16,
                        Proteins = 13,
                        Carbohydrates = 14
                    },
                    new Dish
                    {
                        Id = 11,
                        Name = "Mulled Wine",
                        Recipe =
                            @"Combine all ingredients in a saucepan and heat until the mixture just barely reaches a simmer over medium-high heat.  (Avoid boiling — you don’t want to boil off the alcohol.)  Reduce heat to medium-low, cover, and let the wine simmer for at least 15 minutes or up to 3 hours. Strain, and serve warm with your desired garnishes.",
                        Time = new TimeSpan(0, 20, 0),
                        Servings = 5,
                        Description =
                            "Homemade mulled wine is incredibly easy to make on the stovetop (or simmer in the slow cooker), it’s easy to customize with your favorite spices and add-ins, and it is SO cozy and delicious.  Perfect for winter and holiday entertaining!",
                        Calories = 120,
                        Fats = 0,
                        Proteins = 2,
                        Carbohydrates = 10
                    },
                    new Dish
                    {
                        Id = 12,
                        Name = "Brussels Sprouts, Cranberry and Quinoa Salad",
                        Recipe =
                            @"Make the vinaigrette. In a small bowl, whisk all of the vinaigrette ingredients together until combined.  (Or my preference — combine them in a mason jar, cover, and shake until combined.) Make the salad. Combine the shredded Brussels, cooked quinoa, dried cranberries, chopped pecans and shallot in a large bowl.  Drizzle evenly with the vinaigrette, then tossed until completely combined. Season.  Taste and season the salad with extra salt and pepper, as needed. Serve. Serve immediately, or refrigerate in a sealed container for up to 3 days.",
                        Time = new TimeSpan(0, 15, 0),
                        Servings = 5,
                        Description = "This Brussels Sprouts, Cranberry and Quinoa Salad is super-easy to make with shredded fresh Brussels sprouts and a zippy orange vinaigrette.  It’s also naturally gluten-free and vegan, so that everyone at the table can enjoy it.",
                        Calories = 345,
                        Fats = 8,
                        Proteins = 15,
                        Carbohydrates = 10
                    },
                    new Dish
                    {
                        Id = 13,
                        Name = "Savory Sweet Potato Casserole",
                        Recipe =
                            @"Boil the sweet potatoes.  Cut the sweet potatoes into evenly-sized chunks (about 1 inch thick) and boil them in a large stockpot until tender. Prepare the melted butter mixture.  Meanwhile, as the sweet potatoes are boiling, heat the butter, milk, smoked paprika, and sea salt together in a small saucepan or in the microwave until the butter is just melted.  (You want to avoid boiling the milk.) Mash the potatoes.  Drain and briefly pan-dry the sweet potatoes, to remove any excess moisture.  Then, using your preferred kind of potato masher (I recommend this one in general, or this one for extra-smooth), mash the sweet potatoes to your desired consistency.  Pour the melted butter mixture over the potatoes, and fold it in with a wooden spoon or spatula until potatoes have soaked up the liquid.  Taste and season with extra salt, pepper, and/or smoked paprika as needed, to taste. Prepare the walnut topping.  In a separate small bowl, stir together the maple rosemary walnut topping ingredients until evenly combined. Assemble and bake.  Spread the mashed sweet potatoes out in an even layer in a 9×13-inch baking dish, and top evenly with the walnut topping.  Bake for about 20-25 minutes, or until the walnuts are toasted and fragrant (but not burnt). Serve warm.  Then serve warm, garnished with fresh chives, extra black pepper, or any extra toppings that sound good!",
                        Time = new TimeSpan(0, 35, 0),
                        Servings = 12,
                        Description = "This savory sweet potato casserole recipe is made with a creamy garlicky mashed filling, and sprinkled with the most irresistible maple rosemary walnut topping.  It’s also naturally gluten-free and can be made vegan, if you’d like.",
                        Calories = 450,
                        Fats = 15,
                        Proteins = 17,
                        Carbohydrates = 18
                    },
                    new Dish
                    {
                        Id = 14,
                        Name = "Pecan Pie",
                        Recipe =
                            @"Blind bake the pie crust. Use parchment paper to line the inside of a chilled unbaked pie crust, then fill the bottom of the crust with pie weights or dried beans.  Bake for 15 minutes. Then remove the pie pan from the oven, carefully lift out the parchment and weights, and set them aside. Prepare the maple sauce: Whisk together three of the eggs, maple syrup, coconut sugar (or brown sugar), bourbon, cornstarch, vanilla, sea salt and ground cinnamon — followed by the melted butter — together in a large bowl until combined. Make the egg wash.  In a separate small bowl, whisk together the remaining one egg and an extra tablespoon or milk (or water) until combined.  Brush the egg wash lightly over the edges of the pie crust, which will help it to bake up nice and golden. Assemble the pie. Arrange the pecans in an even layer in the blind-baked pie crust, then pour the maple sauce evenly over the top of the pecans. Bake.  Bake the pie for 40-50 minutes, or until the top is lightly browned. After the first 20 to 25 minutes of bake time, you are welcome to loosely tent a piece of aluminum foil over the top of the whole pie if the crust or pecans seem to be browning too quickly.  The pie will be ready to go once the top is puffed up into a dome (which will sink to become flat again, once the pie has set and cooled).  Transfer the pie to a wire rack and let it rest until it reaches room temperature. Serve. Slice and serve pie at room temperature (or you can refrigerate and chill the pie, if you prefer).  Cover and store leftover pie at room temperature for 1-2 days or in the refrigerator for 4-5 days.",
                        Time = new TimeSpan(1, 25, 0),
                        Servings = 12,
                        Description = "This homemade pecan pie recipe is naturally sweetened (no corn syrup!), easy to make, and so comforting and delicious!",
                        Calories = 375,
                        Fats = 20,
                        Proteins = 10,
                        Carbohydrates = 18
                    },
                    new Dish
                    {
                        Id = 15,
                        Name = "Tahini Granola",
                        Recipe =
                            @"Mix the ingredients. In one bowl, combine the base ingredients (oats and nuts).  In a second bowl, combine the tahini sauce (tahini, honey, coconut oil, vanilla, salt, cardamom, cinnamon and sesame seeds), and heat the mixture slightly until warm but not bubbly.  Pour the tahini sauce over the base ingredients, and stir to combine. Bake. Spread the granola out evenly on a large parchment-covered baking sheet.  Bake for 25 minutes, stirring once halfway through.  Then sprinkle the coconut evenly over the top of the granola (if using), bake for 5-10 more minutes until toasted, and transfer the baking sheet to a wire rack and let it cool completely to room temperature without stirring. Break it up.  At this point, you can break the granola up into your desired size of clumps.  (I love mine extra clumpy!) Serve.  Then serve it immediately or store in an airtight container at room temp for up to 1 month.",
                        Time = new TimeSpan(0, 40, 0),
                        Servings = 4,
                        Description = "This tahini granola recipe is easy to make, perfectly crispy and clustery, and full of the best sweet and savory flavors.",
                        Calories = 290,
                        Fats = 10,
                        Proteins = 18,
                        Carbohydrates = 10
                    },
                    new Dish
                    {
                        Id = 16,
                        Name = "Ranch Mashed Potatoes",
                        Recipe =
                            @"Cut the potatoes.  For even cooking, be sure to have them cut into evenly-sized chunks (about 1-inch wide). Boil the potatoes.  The usual method — place the potatoes in a large pot, cover with cold water, bring to a boil, simmer until tender, then drain. Prepare your melted butter mixture.  While the potatoes are cooking, heat the butter, buttermilk, salt and pepper together in the microwave (or a small saucepan) until the butter is just melted.  (You want to avoid boiling the buttermilk.) Pan-dry the potatoes.  Once the potatoes have been drained, immediately return them to the hot stockpot, place it back on the hot burner, and turn the heat down to low.  Using two oven mitts, carefully hold the handles on the stockpot and shake it gently on the burner for about 1 minute.  This step will help cook off some of the remaining steam within the potatoes. Mash the potatoes.  Using your preferred kind of potato masher (I recommend this one in general, or this one for extra-smooth), mash the potatoes to your desired consistency.  Then stir the herbs into the melted butter mixture until combined, then gradually fold the butter mixture and cream cheese into the mashed potatoes.  As always, try not to overmix the potatoes to prevent them from turning gummy. Taste and season.  One final time, taste the potatoes and season with extra salt and pepper as needed.  (I still usually add in quite a bit at this point.) Serve.  Serve warm, garnished with extra chopped herbs if you would like, and dig in!",
                        Time = new TimeSpan(0, 45, 0),
                        Servings = 11,
                        Description = @"100% obsessed with this creamy buttermilk ranch mashed potatoes recipe!  They’re easy to make, perfectly fluffy and creamy, and made with the tastiest fresh herb ranch seasoning.",
                        Calories = 340,
                        Fats = 10,
                        Proteins = 11,
                        Carbohydrates = 9
                    },
                    new Dish
                    {
                        Id = 17,
                        Name = "Instant Pot Mac and Cheese",
                        Recipe =
                            @"Prep the pasta. Add the pasta, water, butter, mustard, garlic powder and 1 teaspoon salt to the bowl of an Instant Pot, and briefly stir to combine. Pressure cook. Cover and cook on high pressure for 4 minutes, followed by a quick release. Stir in the cheese. Stir in the milk and cheeses until they have melted into a creamy sauce.  The sauce will continue to thicken as it sits, so if it seems too thin, just let it rest for an extra minute or two.  Season with S&P. Serve warm.  Then serve while the mac and cheese is still nice and warm.  Enjoy!",
                        Time = new TimeSpan(0, 25, 0),
                        Servings = 7,
                        Description = "This Instant Pot Mac and Cheese recipe is super-easy to make with just a few simple ingredients and tastes perfectly creamy and cheesy!",
                        Calories = 300,
                        Fats = 10,
                        Proteins = 8,
                        Carbohydrates = 15
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
                            "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Thai-Chicken-Wild-Rice-Soup-Recipe-1.jpg",
                        Priority = 1
                    },
                    new Image
                    {
                        DishId = 3,
                        Url =
                            "https://www.gimmesomeoven.com/wp-content/uploads/2019/08/Healthy-Broccoli-Chicken-Casserole-Recipe-6-1.jpg",
                        Priority = 1
                    },
                    new Image
                    {
                        DishId = 4,
                        Url =
                            "https://www.gimmesomeoven.com/wp-content/uploads/2015/02/The-Best-Butternut-Squash-Soup-Recipe-1.jpg",
                        Priority = 1
                    },
                    new Image
                    {
                        DishId = 5,
                        Url =
                            "https://www.gimmesomeoven.com/wp-content/uploads/2018/09/Healthy-Pumpkin-Muffins-Recipe-Gluten-Free-Vegan-2.jpg",
                        Priority = 1
                    },
                    new Image
                    {
                        DishId = 6,
                        Url =
                            "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Healthy-Veggie-Quesadillas-Recipe-6-2.jpg",
                        Priority = 1
                    },
                    new Image
                    {
                        DishId = 7,
                        Url =
                            "https://www.gimmesomeoven.com/wp-content/uploads/2019/07/Roasted-Broccoli-Chickpea-and-Farro-Bowls-Recipe-2-2.jpg",
                        Priority = 1
                    },
                    new Image
                    {
                        DishId = 8,
                        Url =
                            "https://www.gimmesomeoven.com/wp-content/uploads/2019/09/Easy-Apple-Crisp-Recipe-1-3.jpg",
                        Priority = 1
                    },
                    new Image
                    {
                        DishId = 9,
                        Url =
                            "https://www.gimmesomeoven.com/wp-content/uploads/2019/06/Thai-Basil-Beef-Noodle-Stir-Fry-Recipe-2.jpg",
                        Priority = 1
                    },
                    new Image
                    {
                        DishId = 10,
                        Url =
                            "https://www.gimmesomeoven.com/wp-content/uploads/2018/11/Healthy-Green-Bean-Casserole-Recipe-1-2.jpg",
                        Priority = 1
                    },
                    new Image
                    {
                        DishId = 11,
                        Url =
                            "https://www.gimmesomeoven.com/wp-content/uploads/2013/10/Mulled-Wine-Recipe-1-2.jpg",
                        Priority = 1
                    },
                    new Image
                    {
                        DishId = 12,
                        Url =
                            "https://www.gimmesomeoven.com/wp-content/uploads/2014/11/Brussels-Sprouts-Cranberry-and-Quinoa-Salad-Recipe-7.jpg",
                        Priority = 1
                    },
                    new Image
                    {
                        DishId = 13,
                        Url =
                            "https://www.gimmesomeoven.com/wp-content/uploads/2019/11/Savory-Sweet-Potato-Casserole-Recipe-2a-2.jpg",
                        Priority = 1
                    },
                    new Image
                    {
                        DishId = 14,
                        Url =
                            "https://www.gimmesomeoven.com/wp-content/uploads/2019/11/Pecan-Pie-Recipe-4-4.jpg",
                        Priority = 1
                    },
                    new Image
                    {
                        DishId = 15,
                        Url =
                            "https://www.gimmesomeoven.com/wp-content/uploads/2019/11/Tahini-Granola-Recipe-5-1.jpg",
                        Priority = 1
                    },
                    new Image
                    {
                        DishId = 16,
                        Url =
                            "https://www.gimmesomeoven.com/wp-content/uploads/2019/11/Ranch-Buttermilk-Mashed-Potatoes-Recipe-1-4.jpg",
                        Priority = 1
                    },
                    new Image
                    {
                        DishId = 17,
                        Url =
                            "https://www.gimmesomeoven.com/wp-content/uploads/2019/11/Instant-Pot-Mac-and-Cheese-Recipe-6.jpg",
                        Priority = 1
                    }
                );

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
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 7,
                        Name = "butter",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 8,
                        Name = "egg",
                        Description = ""
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
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 11,
                        Name = "chicken",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 12,
                        Name = "wild rice",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 13,
                        Name = "checken stock",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 14,
                        Name = "baby bella mushroom",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 15,
                        Name = "garlic",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 16,
                        Name = "bell pepper",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 17,
                        Name = "carrot",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 18,
                        Name = "onion",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 19,
                        Name = "ginger",
                        Description = "f"
                    },
                    new Ingredient
                    {
                        Id = 20,
                        Name = "coconut milk",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 21,
                        Name = "pasta",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 22,
                        Name = "broccoli",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 23,
                        Name = "butter oil",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 24,
                        Name = "olive oil",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 25,
                        Name = "milk",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 26,
                        Name = "Dijon mustard",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 27,
                        Name = "cheddar cheese",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 28,
                        Name = "black papper",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 29,
                        Name = "vegetable stock",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 30,
                        Name = "Granny Smith apple",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 31,
                        Name = "butternut squash",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 32,
                        Name = "sage",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 33,
                        Name = "salt",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 34,
                        Name = "cayenne",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 35,
                        Name = "oats",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 36,
                        Name = "pumpkin pie spice",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 37,
                        Name = "other oats",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 38,
                        Name = "special pumpkin pie spice",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 39,
                        Name = "pumpkin puree",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 40,
                        Name = "coconut oil",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 41,
                        Name = "sweet potato",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 42,
                        Name = "jalapeño",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 43,
                        Name = "black beans",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 44,
                        Name = "flour tortillas",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 45,
                        Name = "Mexican-blend cheese",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 46,
                        Name = "farro",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 47,
                        Name = "baby arugula",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 48,
                        Name = "chickpeas",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 49,
                        Name = "almonds",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 50,
                        Name = "lemon juice",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 51,
                        Name = "cinnamon",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 52,
                        Name = "rice noodles",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 53,
                        Name = "flank steak",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 54,
                        Name = "green beans",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 55,
                        Name = "red wine",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 56,
                        Name = "orange",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 57,
                        Name = "cranberries",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 58,
                        Name = "pecans",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 59,
                        Name = "shallot",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 60,
                        Name = "smoked paprika",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 61,
                        Name = "pie crust",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 62,
                        Name = "bourbon",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 63,
                        Name = "pecan halves",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 64,
                        Name = "raw pepitas",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 65,
                        Name = "potato",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 66,
                        Name = "water",
                        Description = ""
                    },
                    new Ingredient
                    {
                        Id = 67,
                        Name = "Parmesan cheese",
                        Description = ""
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
                    new DishCategory
                    {
                        DishId = 2,
                        CategoryId = 2
                    },
                    new DishCategory
                    {
                        DishId = 2,
                        CategoryId = 4
                    },
                    new DishCategory
                    {
                        DishId = 3,
                        CategoryId = 7
                    },
                    new DishCategory
                    {
                        DishId = 4,
                        CategoryId = 2
                    },
                    new DishCategory
                    {
                        DishId = 5,
                        CategoryId = 1
                    },
                    new DishCategory
                    {
                        DishId = 6,
                        CategoryId = 6
                    },
                    new DishCategory
                    {
                        DishId = 6,
                        CategoryId = 7
                    },
                    new DishCategory
                    {
                        DishId = 7,
                        CategoryId = 7
                    },
                    new DishCategory
                    {
                        DishId = 8,
                        CategoryId = 5
                    },
                    new DishCategory
                    {
                        DishId = 9,
                        CategoryId = 4
                    },
                    new DishCategory
                    {
                        DishId = 9,
                        CategoryId = 5
                    },
                    new DishCategory
                    {
                        DishId = 10,
                        CategoryId = 7
                    },
                    new DishCategory
                    {
                        DishId = 11,
                        CategoryId = 8
                    },
                    new DishCategory
                    {
                        DishId = 12,
                        CategoryId = 7
                    },
                    new DishCategory
                    {
                        DishId = 13,
                        CategoryId = 7
                    },
                    new DishCategory
                    {
                        DishId = 14,
                        CategoryId = 1
                    },
                    new DishCategory
                    {
                        DishId = 15,
                        CategoryId = 5
                    },
                    new DishCategory
                    {
                        DishId = 16,
                        CategoryId = 7
                    },
                    new DishCategory
                    {
                        DishId = 17,
                        CategoryId = 6
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

                    new DishIngredient
                    {
                        DishId = 2,
                        IngredientId = 11,
                        Amount = "1 pound boneless skinless chicken breasts"
                    },
                    new DishIngredient
                    {
                        DishId = 2,
                        IngredientId = 12,
                        Amount = "1 cup"
                    },
                    new DishIngredient
                    {
                        DishId = 2,
                        IngredientId = 13,
                        Amount = "2 cups"
                    },
                    new DishIngredient
                    {
                        DishId = 2,
                        IngredientId = 14,
                        Amount = "8 ounces"
                    },
                    new DishIngredient
                    {
                        DishId = 2,
                        IngredientId = 15,
                        Amount = "4 cloves"
                    },
                    new DishIngredient
                    {
                        DishId = 2,
                        IngredientId = 16,
                        Amount = "2 small"
                    },
                    new DishIngredient
                    {
                        DishId = 2,
                        IngredientId = 17,
                        Amount = "2 medium"
                    },
                    new DishIngredient
                    {
                        DishId = 2,
                        IngredientId = 18,
                        Amount = "1 small"
                    },
                    new DishIngredient
                    {
                        DishId = 2,
                        IngredientId = 19,
                        Amount = "2 tablespoons"
                    },
                    new DishIngredient
                    {
                        DishId = 2,
                        IngredientId = 20,
                        Amount = "1 (15 ounce) can"
                    },


                    new DishIngredient
                    {
                        DishId = 3,
                        IngredientId = 21,
                        Amount = "8 ounces"
                    },
                    new DishIngredient
                    {
                        DishId = 3,
                        IngredientId = 22,
                        Amount = "1 large head"
                    },
                    new DishIngredient
                    {
                        DishId = 3,
                        IngredientId = 24,
                        Amount = "2 tablespoons"
                    },
                    new DishIngredient
                    {
                        DishId = 3,
                        IngredientId = 18,
                        Amount = "1 small"
                    },
                    new DishIngredient
                    {
                        DishId = 3,
                        IngredientId = 14,
                        Amount = "8 ounces"
                    },
                    new DishIngredient
                    {
                        DishId = 3,
                        IngredientId = 15,
                        Amount = "4 cloves"
                    },
                    new DishIngredient
                    {
                        DishId = 3,
                        IngredientId = 1,
                        Amount = "3 tablespoons"
                    },
                    new DishIngredient
                    {
                        DishId = 3,
                        IngredientId = 13,
                        Amount = "1 cup"
                    },
                    new DishIngredient
                    {
                        DishId = 3,
                        IngredientId = 25,
                        Amount = "1 1/2 cups"
                    },
                    new DishIngredient
                    {
                        DishId = 3,
                        IngredientId = 26,
                        Amount = "1 teaspoon"
                    },
                    new DishIngredient
                    {
                        DishId = 3,
                        IngredientId = 5,
                        Amount = "1/2 teaspoon"
                    },
                    new DishIngredient
                    {
                        DishId = 3,
                        IngredientId = 28,
                        Amount = "1/4 teaspoon"
                    },
                    new DishIngredient
                    {
                        DishId = 3,
                        IngredientId = 27,
                        Amount = "2 cups (8 ounces)"
                    },
                    new DishIngredient
                    {
                        DishId = 3,
                        IngredientId = 11,
                        Amount = "2 cups"
                    },
                    new DishIngredient
                    {
                        DishId = 3,
                        IngredientId = 29,
                        Amount = "2 cups"
                    },
                    new DishIngredient
                    {
                        DishId = 4,
                        IngredientId = 15,
                        Amount = "4 cloves"
                    },
                    new DishIngredient
                    {
                        DishId = 4,
                        IngredientId = 17,
                        Amount = "1"
                    },
                    new DishIngredient
                    {
                        DishId = 4,
                        IngredientId = 30,
                        Amount = "1"
                    },
                    new DishIngredient
                    {
                        DishId = 4,
                        IngredientId = 31,
                        Amount = "1 medium"
                    },
                    new DishIngredient
                    {
                        DishId = 4,
                        IngredientId = 18,
                        Amount = "1"
                    },
                    new DishIngredient
                    {
                        DishId = 4,
                        IngredientId = 32,
                        Amount = "1 sprig"
                    },
                    new DishIngredient
                    {
                        DishId = 4,
                        IngredientId = 33,
                        Amount = "1/2 teaspoon"
                    },
                    new DishIngredient
                    {
                        DishId = 4,
                        IngredientId = 28,
                        Amount = "1/4 teaspoon"
                    },
                    new DishIngredient
                    {
                        DishId = 4,
                        IngredientId = 34,
                        Amount = "1/8 teaspoon"
                    },
                    new DishIngredient
                    {
                        DishId = 4,
                        IngredientId = 20,
                        Amount = "1/2 cup"
                    },
                    new DishIngredient
                    {
                        DishId = 5,
                        IngredientId = 35,
                        Amount = "3 cups"
                    },
                    new DishIngredient
                    {
                        DishId = 5,
                        IngredientId = 38,
                        Amount = "1 tablespoon"
                    },
                    new DishIngredient
                    {
                        DishId = 5,
                        IngredientId = 4,
                        Amount = "1 1/2 teaspoons"
                    },
                    new DishIngredient
                    {
                        DishId = 5,
                        IngredientId = 5,
                        Amount = "3/4 teaspoon"
                    },
                    new DishIngredient
                    {
                        DishId = 5,
                        IngredientId = 8,
                        Amount = "2"
                    },
                    new DishIngredient
                    {
                        DishId = 5,
                        IngredientId = 25,
                        Amount = "1 cup"
                    },
                    new DishIngredient
                    {
                        DishId = 5,
                        IngredientId = 39,
                        Amount = "1 cup"
                    },
                    new DishIngredient
                    {
                        DishId = 5,
                        IngredientId = 10,
                        Amount = "1/2 cup"
                    },
                    new DishIngredient
                    {
                        DishId = 5,
                        IngredientId = 40,
                        Amount = "3 tablespoons"
                    },
                    new DishIngredient
                    {
                        DishId = 5,
                        IngredientId = 9,
                        Amount = "1 teaspoon"
                    },
                    new DishIngredient
                    {
                        DishId = 6,
                        IngredientId = 24,
                        Amount = "2 tablespoons"
                    },
                    new DishIngredient
                    {
                        DishId = 6,
                        IngredientId = 41,
                        Amount = "1 small"
                    },
                    new DishIngredient
                    {
                        DishId = 6,
                        IngredientId = 42,
                        Amount = "1 small"
                    },
                    new DishIngredient
                    {
                        DishId = 6,
                        IngredientId = 43,
                        Amount = "1 (15-ounce) can"
                    },
                    new DishIngredient
                    {
                        DishId = 6,
                        IngredientId = 44,
                        Amount = "4–6 large"
                    },
                    new DishIngredient
                    {
                        DishId = 6,
                        IngredientId = 45,
                        Amount = "3–4 cups"
                    },
                    new DishIngredient
                    {
                        DishId = 7,
                        IngredientId = 29,
                        Amount = "3 cups"
                    },
                    new DishIngredient
                    {
                        DishId = 7,
                        IngredientId = 46,
                        Amount = "1 cup"
                    },
                    new DishIngredient
                    {
                        DishId = 7,
                        IngredientId = 22,
                        Amount = "1 medium head"
                    },
                    new DishIngredient
                    {
                        DishId = 7,
                        IngredientId = 24,
                        Amount = "2 tablespoons"
                    },
                    new DishIngredient
                    {
                        DishId = 7,
                        IngredientId = 47,
                        Amount = "2 large handfuls"
                    },
                    new DishIngredient
                    {
                        DishId = 7,
                        IngredientId = 48,
                        Amount = "1 (15-ounce) can"
                    },
                    new DishIngredient
                    {
                        DishId = 7,
                        IngredientId = 18,
                        Amount = "half of a medium"
                    },
                    new DishIngredient
                    {
                        DishId = 7,
                        IngredientId = 49,
                        Amount = "1/3 cup"
                    },
                    new DishIngredient
                    {
                        DishId = 8,
                        IngredientId = 30,
                        Amount = "8 medium"
                    },
                    new DishIngredient
                    {
                        DishId = 8,
                        IngredientId = 50,
                        Amount = "1/4 cup"
                    },
                    new DishIngredient
                    {
                        DishId = 8,
                        IngredientId = 2,
                        Amount = "1/4 cup + 2/3 cup"
                    },
                    new DishIngredient
                    {
                        DishId = 8,
                        IngredientId = 1,
                        Amount = "1 tablespoon + 1 cup"
                    },
                    new DishIngredient
                    {
                        DishId = 8,
                        IngredientId = 51,
                        Amount = "1 tablespoon + 1 tablespoon"
                    },
                    new DishIngredient
                    {
                        DishId = 8,
                        IngredientId = 37,
                        Amount = "1 cup"
                    },
                    new DishIngredient
                    {
                        DishId = 8,
                        IngredientId = 5,
                        Amount = "3/4 teaspoon"
                    },
                    new DishIngredient
                    {
                        DishId = 8,
                        IngredientId = 7,
                        Amount = "1/2 cup"
                    },
                    new DishIngredient
                    {
                        DishId = 9,
                        IngredientId = 52,
                        Amount = "8 ounces"
                    },
                    new DishIngredient
                    {
                        DishId = 9,
                        IngredientId = 53,
                        Amount = "1 1/4 pounds"
                    },
                    new DishIngredient
                    {
                        DishId = 9,
                        IngredientId = 14,
                        Amount = "8 ounces"
                    },
                    new DishIngredient
                    {
                        DishId = 10,
                        IngredientId = 54,
                        Amount = "2 pounds"
                    },
                    new DishIngredient
                    {
                        DishId = 11,
                        IngredientId = 55,
                        Amount = "1 (750 ml) bottle"
                    },
                    new DishIngredient
                    {
                        DishId = 11,
                        IngredientId = 56,
                        Amount = "1"
                    },
                    new DishIngredient
                    {
                        DishId = 11,
                        IngredientId = 2,
                        Amount = "2–4 tablespoons"
                    },
                    new DishIngredient
                    {
                        DishId = 12,
                        IngredientId = 57,
                        Amount = "1 cup"
                    },
                    new DishIngredient
                    {
                        DishId = 12,
                        IngredientId = 58,
                        Amount = "2/3 cup"
                    },
                    new DishIngredient
                    {
                        DishId = 12,
                        IngredientId = 59,
                        Amount = "1 medium"
                    },
                    new DishIngredient
                    {
                        DishId = 13,
                        IngredientId = 41,
                        Amount = "4 pounds"
                    },
                    new DishIngredient
                    {
                        DishId = 13,
                        IngredientId = 25,
                        Amount = "2 tablespoons"
                    },
                    new DishIngredient
                    {
                        DishId = 13,
                        IngredientId = 60,
                        Amount = "2 teaspoons"
                    },
                    new DishIngredient
                    {
                        DishId = 13,
                        IngredientId = 15,
                        Amount = "4 cloves"
                    },
                    new DishIngredient
                    {
                        DishId = 14,
                        IngredientId = 61,
                        Amount = "1 (9-inch)"
                    },
                    new DishIngredient
                    {
                        DishId = 14,
                        IngredientId = 8,
                        Amount = "4 large"
                    },
                    new DishIngredient
                    {
                        DishId = 14,
                        IngredientId = 62,
                        Amount = "2 tablespoons"
                    },
                    new DishIngredient
                    {
                        DishId = 14,
                        IngredientId = 63,
                        Amount = "2 teaspoons"
                    },
                    new DishIngredient
                    {
                        DishId = 15,
                        IngredientId = 35,
                        Amount = "2 teaspoons"
                    },
                    new DishIngredient
                    {
                        DishId = 15,
                        IngredientId = 64,
                        Amount = "1/2 cup"
                    },
                    new DishIngredient
                    {
                        DishId = 15,
                        IngredientId = 50,
                        Amount = "1/2 cup"
                    },
                    new DishIngredient
                    {
                        DishId = 16,
                        IngredientId = 65,
                        Amount = "5 pounds"
                    },
                    new DishIngredient
                    {
                        DishId = 16,
                        IngredientId = 7,
                        Amount = "6 tablespoons"
                    },
                    new DishIngredient
                    {
                        DishId = 16,
                        IngredientId = 6,
                        Amount = "1 1/2 cups"
                    },
                    new DishIngredient
                    {
                        DishId = 17,
                        IngredientId = 21,
                        Amount = "1 pound"
                    },
                    new DishIngredient
                    {
                        DishId = 17,
                        IngredientId = 66,
                        Amount = "4 cups"
                    },
                    new DishIngredient
                    {
                        DishId = 17,
                        IngredientId = 7,
                        Amount = "2 tablespoons"
                    },
                    new DishIngredient
                    {
                        DishId = 17,
                        IngredientId = 26,
                        Amount = " 1/2 teaspoons"
                    },
                    new DishIngredient
                    {
                        DishId = 17,
                        IngredientId = 67,
                        Amount = "1/2 cup"
                    }
                );

            modelBuilder.Entity<Rating>()
                .HasData(
                );
        }
    }
}
