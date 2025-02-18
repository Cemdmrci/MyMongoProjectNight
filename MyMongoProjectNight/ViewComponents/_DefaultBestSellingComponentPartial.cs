using Microsoft.AspNetCore.Mvc;
using MyMongoProjectNight.Services.SaleServices;

namespace MyMongoProjectNight.ViewComponents
{
    public class _DefaultBestSellingComponentPartial:ViewComponent
    {
        private readonly ISaleService _saleService;

        public _DefaultBestSellingComponentPartial(ISaleService saleService)
        {
            _saleService = saleService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _saleService.GetAllSaleAsync();
            return View(values);
        }
    }
}
