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

namespace IntelligentCooking.BLL.Tests
{
    public class CategoryServiceTest
    {
        [Fact]
        public void GetCategoryAsync()
        {
            Mock<IIntelligentCookingUnitOfWork> mockUnitOfWork = new Mock<IIntelligentCookingUnitOfWork>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            var categories = new List<CategoryDto>
            {
                new CategoryDto() { Id = 1, Name = "Category1", ImageUrl = "Image1" },
                new CategoryDto() { Id = 2, Name = "Category2", ImageUrl = "Image2" },
                new CategoryDto() { Id = 3, Name = "Category3", ImageUrl = "Image3" }
            };

            mockUnitOfWork.Setup(m => m.Categories).Returns(value: categories);

            CategoryService categoryService = new CategoryService(unitOfWork: mockUnitOfWork.Object, mapper: mockMapper.Object);

            categoryService.GetCategoriesAsync();
        }
    }
}
