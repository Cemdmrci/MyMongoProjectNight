using MyMongoProjectNight.Dtos.CustomerDtos;

namespace MyMongoProjectNight.Services
{
    public interface ICustomerService
    {
        Task<List<ResultCustomerDto>> GetAllCustomerAsync();
        Task CreateCustomerasync(CreateCustomerDto createCustomerDto);
        Task UpdateCustomerAsync(UpdateCustomerDto updateCustomerDto);
        Task DeleteCustomerAsync(string customerId);
        Task<GetByIdCustomerDto> GetByIdCustomerAsync(string customerId);
        Task<List< ResultCustomerWithCategoryDto>>GetAllCustomerWithCategoryAsync();
    }
}
