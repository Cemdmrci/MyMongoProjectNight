using Microsoft.AspNetCore.Mvc;
using MyMongoProjectNight.Dtos.ProductDtos;
using MyMongoProjectNight.Services.ProductServices;
using System.Data.Common;

namespace MyMongoProjectNight.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


		public async Task<IActionResult> Index()
		{
			var values = await _productService.GetAllProductWithCategoryAsync();
			return View(values);
		}

		[HttpGet]
		public async Task<IActionResult> Search(string query)
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return RedirectToAction("Index");
			}
			var searchResults = await _productService.SearchProductsAsync(query);
			return View("Index", searchResults);
		}

		public async Task<IActionResult> UnluMamuller()
		{
			var products = await _productService.GetAllProductOfUnluMamullerCategoryAsync();
			return View(products);
		}

		public async Task<IActionResult> SebzeMeyve()
		{
			var products = await _productService.GetAllProductOfSebzeMeyveCategoryAsync();
			return View(products);
		}

		public async Task<IActionResult> SutUrunleri()
		{
			var products = await _productService.GetAllProductOfSutUrunleriCategoryAsync();
			return View(products);
		}

		public async Task<IActionResult> Yag()
		{
			var products = await _productService.GetAllProductOfYagCategoryAsync();
			return View(products);
		}

		public async Task<IActionResult> Sekerlemeler()
		{
			var products = await _productService.GetAllProductOfSekerlemelerCategoryAsync();
			return View(products);
		}

		public async Task<IActionResult> FastFood()
		{
			var products = await _productService.GetAllProductOfFastFoodCategoryAsync();
			return View(products);
		}

	}
}
