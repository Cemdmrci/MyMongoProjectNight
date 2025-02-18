using Microsoft.AspNetCore.Mvc;
using MyMongoProjectNight.Services.ProductServices;

namespace MyMongoProjectNight.ViewComponents
{
    public class _DefaultTrendingProductComponentPartial:ViewComponent
    {
        private readonly IProductService _productService;

        public _DefaultTrendingProductComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productService.GetAllProductWithCategoryAsync();
            return View(values);
        }
    }
}
