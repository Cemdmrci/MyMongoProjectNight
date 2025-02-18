using MyMongoProjectNight.Dtos.CategoryDtos;

namespace MyMongoProjectNight.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task CreateCategoryasync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(string categoryId);
        Task<GetByIdCategoryDto> GetByIdCategoryAsync(string categoryId);
    }
}
