using Microsoft.AspNetCore.Mvc;
using MyMongoProjectNight.Dtos.CategoryDtos;
using MyMongoProjectNight.Services.CategoryServices;

namespace MyMongoProjectNight.Areas.Admin.Controllers
{

        [Area("Admin")]
        public class CategoryController : Controller
        {
            private readonly ICategoryService _categoryService;

            public CategoryController(ICategoryService categoryService)
            {
                _categoryService = categoryService;
            }

            [HttpGet]
            public IActionResult CreateCategory()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
            {
                await _categoryService.CreateCategoryasync(createCategoryDto);
                return RedirectToAction("CategoryList");
            }

            public async Task<IActionResult> CategoryList()
            {
                var values = await _categoryService.GetAllCategoryAsync();
                return View(values);
            }

            public async Task<IActionResult> DeleteCategory(string id)
            {
                await _categoryService.DeleteCategoryAsync(id);
                return RedirectToAction("CategoryList");
            }

            [HttpGet]
            public async Task<IActionResult> UpdateCategory(string id)
            {
                var value = await _categoryService.GetByIdCategoryAsync(id);
                return View(value);
            }

            [HttpPost]
            public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
            {
                await _categoryService.UpdateCategoryAsync(updateCategoryDto);
                return RedirectToAction("CategoryList");
            }
    }
}
