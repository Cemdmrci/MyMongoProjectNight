using Microsoft.AspNetCore.Mvc;
using MyMongoProjectNight.Services.CategoryServices;

namespace MyMongoProjectNight.ViewComponents
{
    public class _DefaultCategorySectionComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _DefaultCategorySectionComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _categoryService.GetAllCategoryAsync();
            return View(values);
        }
    }
}
