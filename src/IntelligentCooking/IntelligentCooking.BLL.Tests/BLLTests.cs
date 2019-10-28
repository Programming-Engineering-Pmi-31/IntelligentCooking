using InelligentCooking.BLL.DTOs;
using InelligentCooking.BLL.Services;
using System;
using Xunit;
using IntelligentCooking.DAL.UnitsOfWork;
using AutoMapper;
using System.Linq;
using Moq;
using IntelligentCooking.Core.Interfaces.UnitsOfWork;
using System.Collections.Generic;
using IntelligentCooking.Core.Interfaces.Repositories;
using IntelligentCooking.Core.Entities;
using InelligentCooking.BLL.MappingProviders;
using IntelligentCooking.Web.Controllers;
using System.Threading.Tasks;
using InelligentCooking.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System.IO;

namespace IntelligentCooking.BLL.Tests
{
    public class BLLTests
    {
        [Fact]
        public void GetCategoryAsync()
        {
            Mock<IIntelligentCookingUnitOfWork> mockUnitOfWork = new Mock<IIntelligentCookingUnitOfWork>();

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<Category, CategoryDto>(It.IsAny<Category>())).Returns((Category c) =>
            {
                return new CategoryDto()
                {
                    Id = c.Id,
                    ImageUrl = c.ImageUrl,
                    Name = c.Name
                };
            }
            );


            var categories = new List<Category>
            {
                new Category() { Id = 1, Name = "Category1", ImageUrl = "Image1" },
                new Category() { Id = 2, Name = "Category2", ImageUrl = "Image2" },
                new Category() { Id = 3, Name = "Category3", ImageUrl = "Image3" }
            };

            mockUnitOfWork.Setup(m => m.Categories.GetAsync()).Returns(Task.FromResult((IEnumerable<Category>)categories));

            CategoryService categoryService = new CategoryService(unitOfWork: mockUnitOfWork.Object, mapper: mapperMock.Object);

            var result = categoryService.GetCategoriesAsync();

            Assert.Equal(3, result.Result.Count());
        }

        [Fact]
        public void GetIngredientAsync()
        {
            Mock<IIntelligentCookingUnitOfWork> mockUnitOfWork = new Mock<IIntelligentCookingUnitOfWork>();

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<Ingredient, IngredientDto>(It.IsAny<Ingredient>())).Returns((Ingredient i) =>
            {
                return new IngredientDto()
                {
                    Id = i.Id,
                    Name = i.Name
                };
            });


            var ingredients = new List<Ingredient>
            {
                new Ingredient() { Id = 1, Name = "Ingredient1", Description = "Desc1"},
                new Ingredient() { Id = 2, Name = "Ingredient2", Description = "Desc2"},
            };

            mockUnitOfWork.Setup(m => m.Ingredients.GetAsync()).Returns(Task.FromResult((IEnumerable<Ingredient>)ingredients));

            IngredientService ingredientService = new IngredientService(unitOfWork: mockUnitOfWork.Object, mapper: mapperMock.Object);

            var result = ingredientService.GetIngredientsAsync();

            Assert.Equal(2, result.Result.Count());
        }
        

        [Fact]
        public void GetDishesInfoAsync()
        {
            Mock<IIntelligentCookingUnitOfWork> mockUnitOfWork = new Mock<IIntelligentCookingUnitOfWork>();

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<Dish, DishDto>(It.IsAny<Dish>())).Returns((Dish d) =>
            {
                return new DishDto()
                {
                    Id = d.Id,
                    Name = d.Name,
                    Recipe = d.Recipe,
                    Servings = d.Servings,
                    Rating = d.Stars,
                    Description = d.Description
                };
            }
            );

            Mock<IImageService> mockImageService = new Mock<IImageService>();

            var dishes = new List<Dish>
            {
                new Dish() { Id = 1, Name = "Dish1", Recipe ="Recipe1", Time = new DateTime(20000), Servings = 1, Stars = 1, Description = "Desc1" },
                new Dish() { Id = 2, Name = "Dish2", Recipe ="Recipe2", Time = new DateTime(20000), Servings = 1, Stars = 1, Description = "Desc2" },
                new Dish() { Id = 3, Name = "Dish3", Recipe ="Recipe3", Time = new DateTime(20000), Servings = 1, Stars = 1, Description = "Desc3" }
            };

            mockUnitOfWork.Setup(m => m.Dishes.GetDishesWithIngredientsCategoriesAndLikes(null, null, false, false)).Returns(Task.FromResult((IEnumerable<Dish>)dishes));

            DishService dishService = new DishService(unitOfWork: mockUnitOfWork.Object, imageService: mockImageService.Object, mapper: mapperMock.Object);

            var result = dishService.GetDishesInfoAsync(new MainGetDishDto() { ByCalories = false, ByTime = false});

            Assert.Equal(3, result.Result.Count());
        }

        [Fact]
        public void AddDishAsync()
        {
            Mock<IIntelligentCookingUnitOfWork> mockUnitOfWork = new Mock<IIntelligentCookingUnitOfWork>();          

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<Dish, DishDto>(It.IsAny<Dish>())).Returns((Dish d) =>
            {
                return new DishDto()
                {
                    Id = d.Id,
                    Name = d.Name,
                    Recipe = d.Recipe,
                    Servings = d.Servings,
                    Rating = d.Stars,
                    Description = d.Description
                };
            }
            );

            Mock<IImageService> mockImageService = new Mock<IImageService>();

            var dishes = new List<Dish>
            {
                new Dish() { Id = 1, Name = "Dish1", Recipe ="Recipe1", Time = new DateTime(20000), Servings = 1, Stars = 1, Description = "Desc1" },
                new Dish() { Id = 2, Name = "Dish2", Recipe ="Recipe2", Time = new DateTime(20000), Servings = 1, Stars = 1, Description = "Desc2" },
                new Dish() { Id = 3, Name = "Dish3", Recipe ="Recipe3", Time = new DateTime(20000), Servings = 1, Stars = 1, Description = "Desc3" }
            };

            mockUnitOfWork.Setup(m => m.Dishes.Add(It.IsAny<Dish>())).Returns((Dish d) => d).Callback((Dish d) => dishes.Add(d));

            var strings = new List<string>()
            {
                "url1"
            };

            mockImageService.Setup(m => m.UploadRangeAsync(It.IsAny<IEnumerable<IFormFile>>())).Returns(Task.FromResult((IEnumerable<string>)strings));

            DishService dishService = new DishService(unitOfWork: mockUnitOfWork.Object, imageService: mockImageService.Object, mapper: mapperMock.Object);

            var files = new List<FormFile>();

            using (var stream = File.OpenRead(@"C:\Users\Юра Мичка\Pictures\2019-05-24\001.jpg"))
            {
                files.Add(new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
                {
                    Headers = new HeaderDictionary(),
                    ContentType = "application/jpg"
                });
            }

            var dishToAdd = new AddDishDto() { Title = "Dish4", Recipe = "Recipe4", Time = "20000", Servings = 1, Description = "Desc4", Images=files};

            var dish = dishService.AddDishAsync(dishToAdd);
            
            Assert.Equal(4, dishes.Count());
        }

        [Fact]
        public void FindById()
        {
            Mock<IIntelligentCookingUnitOfWork> mockUnitOfWork = new Mock<IIntelligentCookingUnitOfWork>();

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<Dish, DishDto>(It.IsAny<Dish>())).Returns((Dish d) => 
            {
                return new DishDto()
                {
                    Id = d.Id,
                    Name = d.Name,
                    Recipe = d.Recipe,
                    Servings = d.Servings,
                    Rating = d.Stars, 
                    Description = d.Description
                };
            } 
            );

            Mock<IImageService> mockImageService = new Mock<IImageService>();

            var dishes = new List<Dish>
            {
                new Dish() { Id = 1, Name = "Dish1", Recipe ="Recipe1", Time = new DateTime(20000), Servings = 1, Stars = 1, Description = "Desc1" },
                new Dish() { Id = 2, Name = "Dish2", Recipe ="Recipe2", Time = new DateTime(20000), Servings = 1, Stars = 1, Description = "Desc2" },
                new Dish() { Id = 3, Name = "Dish3", Recipe ="Recipe3", Time = new DateTime(20000), Servings = 1, Stars = 1, Description = "Desc3" }
            };

            int id = 3;

            mockUnitOfWork.Setup(m => m.Dishes.FindAsync(id)).Returns(Task.FromResult((Dish)dishes.FirstOrDefault(d=>d.Id == id)));

            DishService dishService = new DishService(unitOfWork: mockUnitOfWork.Object, imageService: mockImageService.Object, mapper: mapperMock.Object);

            var result = dishService.FindByIdAsync(id).Result;

            Assert.Equal("Dish3", result.Name);
        }
    }
}
