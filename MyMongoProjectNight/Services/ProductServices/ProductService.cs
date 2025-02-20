using AutoMapper;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MyMongoProjectNight.Dtos.ProductDtos;
using MyMongoProjectNight.Entities;
using MyMongoProjectNight.Settings;

namespace MyMongoProjectNight.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductAsync(string productId)
        {
            await _productCollection.DeleteOneAsync(x => x.ProductId == productId);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

		public async Task<List<ResultProductWithCategoryDto>> GetAllProductOfFastFoodCategoryAsync()
		{
			var category = await _categoryCollection.Find(x => x.CategoryName == "FastFood").FirstOrDefaultAsync();
			if (category == null)
				return new List<ResultProductWithCategoryDto>();

			var products = await _productCollection.Find(x => x.CategoryId == category.CategoryId).ToListAsync();
			foreach (var product in products)
			{
				product.Category = category;
			}

			return _mapper.Map<List<ResultProductWithCategoryDto>>(products);
		}

		public async Task<List<ResultProductWithCategoryDto>> GetAllProductOfSebzeMeyveCategoryAsync()
		{
			var category = await _categoryCollection.Find(x => x.CategoryName == "SebzeMeyve").FirstOrDefaultAsync();
			if (category == null)
				return new List<ResultProductWithCategoryDto>();

			var products = await _productCollection.Find(x => x.CategoryId == category.CategoryId).ToListAsync();
			foreach (var product in products)
			{
				product.Category = category;
			}

			return _mapper.Map<List<ResultProductWithCategoryDto>>(products);
		
	}

		public async Task<List<ResultProductWithCategoryDto>> GetAllProductOfSekerlemelerCategoryAsync()
		{
			var category = await _categoryCollection.Find(x => x.CategoryName == "Şekerlemeler").FirstOrDefaultAsync();
			if (category == null)
				return new List<ResultProductWithCategoryDto>();

			var products = await _productCollection.Find(x => x.CategoryId == category.CategoryId).ToListAsync();
			foreach (var product in products)
			{
				product.Category = category;
			}

			return _mapper.Map<List<ResultProductWithCategoryDto>>(products);
		}

		public async Task<List<ResultProductWithCategoryDto>> GetAllProductOfSutUrunleriCategoryAsync()
		{
			var category = await _categoryCollection.Find(x => x.CategoryName == "SütÜrünleri").FirstOrDefaultAsync();
			if (category == null)
				return new List<ResultProductWithCategoryDto>();

			var products = await _productCollection.Find(x => x.CategoryId == category.CategoryId).ToListAsync();
			foreach (var product in products)
			{
				product.Category = category;
			}

			return _mapper.Map<List<ResultProductWithCategoryDto>>(products);
		}

		public async Task<List<ResultProductWithCategoryDto>> GetAllProductOfUnluMamullerCategoryAsync()
		{
			var category = await _categoryCollection.Find(x => x.CategoryName == "UnluMamüller").FirstOrDefaultAsync();
			if (category == null)
				return new List<ResultProductWithCategoryDto>();

			var products = await _productCollection.Find(x => x.CategoryId == category.CategoryId).ToListAsync();
			foreach (var product in products)
			{
				product.Category = category;
			}

			return _mapper.Map<List<ResultProductWithCategoryDto>>(products);
		}

		public async Task<List<ResultProductWithCategoryDto>> GetAllProductOfYagCategoryAsync()
		{
			var category = await _categoryCollection.Find(x => x.CategoryName == "Yağ").FirstOrDefaultAsync();
			if (category == null)
				return new List<ResultProductWithCategoryDto>();

			var products = await _productCollection.Find(x => x.CategoryId == category.CategoryId).ToListAsync();
			foreach (var product in products)
			{
				product.Category = category;
			}

			return _mapper.Map<List<ResultProductWithCategoryDto>>(products);
		}

		public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            foreach (var item in values)
            {
                item.Category = await _categoryCollection.Find(x => x.CategoryId == item.CategoryId).FirstOrDefaultAsync();
            }
            return _mapper.Map<List<ResultProductWithCategoryDto>>(values);
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string productId)
        {
            var values = await _productCollection.Find(x => x.ProductId == productId).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(values);
        }

        public async Task<List<ResultProductDto>> SearchProductsAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return new List<ResultProductDto>();

            var products = await _productCollection.AsQueryable()
                .Where(product => product.ProductName.ToLower().Contains(query.ToLower()))
                .ToListAsync();

            var result = products.Select(product => new ResultProductDto
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                CategoryId = product.CategoryId,
                ProductImageURL = product.ProductImageURL,
                Price = product.Price
            }).ToList();

            return result;
        
	}

		public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var values = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, values);
        }
    }
}
