using MyMongoProjectNight.Dtos.DiscountDtos;

namespace MyMongoProjectNight.Services.DiscountServices
{
    public interface IDiscountService
    {
        Task<List<ResultDiscountDto>> GetAllDiscountAsync();
        Task CreateDiscountAsync(CreateDiscountDto createDiscountDto);
        Task UpdateDiscountAsync(UpdateDiscountDto updateDiscountDto);
        Task DeleteDiscountAsync(string discountId);
        Task<GetByIdDiscountDto> GetByIdDiscountAsync(string discountId);
    }
}
