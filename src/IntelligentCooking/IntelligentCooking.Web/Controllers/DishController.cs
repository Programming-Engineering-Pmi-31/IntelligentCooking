﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InelligentCooking.BLL.DTOs;
using InelligentCooking.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InelligentCooking.BLL.Interfaces;

namespace IntelligentCooking.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private IDishService _dishService;

        public DishController(IDishService dishService)
        {
            _dishService = dishService;
        }

        [HttpGet]
        public async Task<IEnumerable<DishPreviewDto>> GetDishesInfo()
        {
            return await _dishService.GetDishesInfo();
        }

        [HttpPost]
        public async Task<DishPreviewDto> AddDish([FromForm]AddDishDto addDish)
        {
            return await _dishService.AddDish(addDish);
        }

        [HttpGet("{id}")]
        public async Task<DishDto> GetDishById(int id)
        {
            return await _dishService.GetDishById(id);
        }
    }
}