using Microsoft.AspNetCore.Mvc;
using MyMongoProjectNight.Dtos.DiscountDtos;
using MyMongoProjectNight.Services.CategoryServices;
using MyMongoProjectNight.Services.DiscountServices;
using MyMongoProjectNight.Services.ProductServices;

namespace MyMongoProjectNight.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public IActionResult CreateDiscount()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            await _discountService.CreateDiscountAsync(createDiscountDto);
            return RedirectToAction("DiscountList");
        }

        public async Task<IActionResult> DiscountList()
        {
            var values = await _discountService.GetAllDiscountAsync();
            return View(values);
        }

        public async Task<IActionResult> DeleteDiscount(string id)
        {
            await _discountService.DeleteDiscountAsync(id);
            return RedirectToAction("DiscountList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateDiscount(string id)
        {
            var value = await _discountService.GetByIdDiscountAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            await _discountService.UpdateDiscountAsync(updateDiscountDto);
            return RedirectToAction("DiscountList");
        }
    }
}
