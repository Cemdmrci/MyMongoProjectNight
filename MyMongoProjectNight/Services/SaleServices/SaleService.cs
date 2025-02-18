using AutoMapper;
using MongoDB.Driver;
using MyMongoProjectNight.Dtos.SaleDtos;
using MyMongoProjectNight.Entities;
using MyMongoProjectNight.Settings;

namespace MyMongoProjectNight.Services.SaleServices
{
    public class SaleService : ISaleService
    {
        private readonly IMongoCollection<Sale> _saleCollection;
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;

        public SaleService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
			var client = new MongoClient(_databaseSettings.ConnectionString);
			var database = client.GetDatabase(_databaseSettings.DatabaseName);
			_saleCollection = database.GetCollection<Sale>(_databaseSettings.SaleCollectionName);
			_productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
			_mapper = mapper;
		}

        public async Task CreateSaleAsync(CreateSaleDto createSaleDto)
        {
            var value = _mapper.Map<Sale>(createSaleDto);
            await _saleCollection.InsertOneAsync(value);
        }

        public async Task DeleteSaleAsync(string saleId)
        {
            await _saleCollection.DeleteOneAsync(x => x.SaleId == saleId);
        }

        public async Task<List<ResultSaleWithProductDto>> GetAllSaleAsync()
        {
			var sales = await _saleCollection.Find(x => true).ToListAsync();

			var result = new List<ResultSaleWithProductDto>();

			foreach (var sale in sales)
			{
				var product = await _productCollection.Find(x => x.ProductId == sale.ProductId).FirstOrDefaultAsync();

				if (product != null)
				{
					result.Add(new ResultSaleWithProductDto
					{
						SaleId = sale.SaleId,
						NumberOfProducts = sale.NumberOfProducts,
						TotalPrice = sale.TotalPrice,
						ProductName = product.ProductName,   // Ürün Adı
						Price = product.Price.ToString(),   // Ürün Fiyatı
						ProductImageURL = product.ProductImageURL // Ürün Görseli
					});
				}
			}

			return result;
		}

        public async Task<GetByIdSaleDto> GetByIdSaleAsync(string saleId)
        {
            var values = await _saleCollection.Find(x => x.SaleId == saleId).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdSaleDto>(values);
        }

        public async Task UpdateSaleAsync(UpdateSaleDto updateSaleDto)
        {
            var values = _mapper.Map<Sale>(updateSaleDto);
            await _saleCollection.FindOneAndReplaceAsync(x => x.SaleId == updateSaleDto.SaleId, values);
        }
    }
}
