using Microsoft.AspNetCore.Mvc;
using Services.CategoryService;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Entities;
using Models.CategoryModel;

namespace Controllers
{
    [Route("api/categories")]
    public class CategoryController: Controller
    {
        private ICategoryService _categoryService;
        private IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet()]
        public IActionResult GetCategories()
        {
            var categories = _categoryService.GetCategories();
            var categoriesMapped = _mapper.Map<IEnumerable<GetCategoryModel>>(categories);
            return Ok(categoriesMapped);
        }
    }
}
