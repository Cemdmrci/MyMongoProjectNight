using MyMongoProjectNight.Dtos.ProductDtos;

namespace MyMongoProjectNight.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string productId);
        Task<GetByIdProductDto> GetByIdProductAsync(string productId);
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();
		Task<List<ResultProductDto>> SearchProductsAsync(string query);
		Task<List<ResultProductWithCategoryDto>> GetAllProductOfUnluMamullerCategoryAsync();
		Task<List<ResultProductWithCategoryDto>> GetAllProductOfSebzeMeyveCategoryAsync();
		Task<List<ResultProductWithCategoryDto>> GetAllProductOfSutUrunleriCategoryAsync();
		Task<List<ResultProductWithCategoryDto>> GetAllProductOfYagCategoryAsync();
		Task<List<ResultProductWithCategoryDto>> GetAllProductOfSekerlemelerCategoryAsync();
		Task<List<ResultProductWithCategoryDto>> GetAllProductOfFastFoodCategoryAsync();


	}
}
