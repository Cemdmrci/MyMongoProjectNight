using MyMongoProjectNight.Dtos.SaleDtos;

namespace MyMongoProjectNight.Services.SaleServices
{
    public interface ISaleService
    {
        Task<List<ResultSaleWithProductDto>> GetAllSaleAsync();
        Task CreateSaleAsync(CreateSaleDto createSaleDto);
        Task UpdateSaleAsync(UpdateSaleDto updateSaleDto);
        Task DeleteSaleAsync(string saleId);
        Task<GetByIdSaleDto> GetByIdSaleAsync(string saleId);


    }
}
