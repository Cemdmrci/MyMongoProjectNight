using AutoMapper;
using MongoDB.Driver;
using MyMongoProjectNight.Dtos.DiscountDtos;
using MyMongoProjectNight.Entities;
using MyMongoProjectNight.Settings;

namespace MyMongoProjectNight.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly IMongoCollection<Discount> _discountCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;

        public DiscountService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _discountCollection = database.GetCollection<Discount>(_databaseSettings.DiscountCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }

        public async Task CreateDiscountAsync(CreateDiscountDto createDiscountDto)
        {
            var value = _mapper.Map<Discount>(createDiscountDto);
            await _discountCollection.InsertOneAsync(value);
        }

        public async Task DeleteDiscountAsync(string discountId)
        {
            await _discountCollection.DeleteOneAsync(x => x.DiscountId == discountId);
        }

        public async Task<List<ResultDiscountDto>> GetAllDiscountAsync()
        {
            var values = await _discountCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultDiscountDto>>(values);
        }

        public async Task<GetByIdDiscountDto> GetByIdDiscountAsync(string discountId)
        {
            var values = await _discountCollection.Find(x => x.DiscountId == discountId).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdDiscountDto>(values);
        }

        public async Task UpdateDiscountAsync(UpdateDiscountDto updateDiscountDto)
        {
            var values = _mapper.Map<Discount>(updateDiscountDto);
            await _discountCollection.FindOneAndReplaceAsync(x => x.DiscountId == updateDiscountDto.DiscountId, values);
        }
    }
}
