using Microsoft.AspNetCore.Mvc;
using MyMongoProjectNight.Services.DiscountServices;

namespace MyMongoProjectNight.ViewComponents
{
    public class _DefaultCategoryDiscountSectionComponentPartial:ViewComponent
    {
        private readonly IDiscountService _discountService;

        public _DefaultCategoryDiscountSectionComponentPartial(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var discounts = await _discountService.GetAllDiscountAsync();
            return View(discounts);
        }
        }
}
