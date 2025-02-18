using AutoMapper;
using MongoDB.Driver;
using MyMongoProjectNight.Dtos.CustomerDtos;
using MyMongoProjectNight.Entities;
using MyMongoProjectNight.Settings;

namespace MyMongoProjectNight.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMongoCollection<Customer> _customerCollection;
        private readonly IMongoCollection<Department> _departmentCollection;
        private readonly IMapper _mapper;
        public CustomerService(IMapper mapper, IDatabaseSettings _databaseSettings) //4 parametre ataması yaptığım için dışarıdan implement ediyorum
        {
            var client = new MongoClient(_databaseSettings.ConnectionString); //client ile bağlantı adrsine eriştim
            var database = client.GetDatabase(_databaseSettings.DatabaseName); //veritabanı adına ulaştım
            _customerCollection = database.GetCollection<Customer>(_databaseSettings.CustomerCollectionName);//tabloya ulaştım
            _departmentCollection = database.GetCollection<Department>(_databaseSettings.DepartmentCollectionName);
            _mapper = mapper;
        }
        public async Task CreateCustomerasync(CreateCustomerDto createCustomerDto)
        {
            var value = _mapper.Map<Customer>(createCustomerDto); //customer tablomu createcustomerdtodan gelen değerlerle maple
            await _customerCollection.InsertOneAsync(value);  //mongodbde ekleme işlemi için ınsertoneasync kullanılır.
        }
        public async Task DeleteCustomerAsync(string customerId)
        {
            await _customerCollection.DeleteOneAsync(x => x.CustomerId == customerId);
        }
        public async Task<List<ResultCustomerDto>> GetAllCustomerAsync()
        {
            var values = await _customerCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultCustomerDto>>(values); //ResultCustomerDto valuesten gelen değerler maplenir.
        }

        public async Task<List<ResultCustomerWithCategoryDto>> GetAllCustomerWithCategoryAsync()
        {
            var values = await _customerCollection.Find(x => true).ToListAsync(); //(x => true) herhangi bir şart olmadan anlamı taşır.
            foreach (var item in values)
            {
                item.Department = await _departmentCollection.Find(x => x.DepartmentId == item.DepartmentId).FirstAsync();
            }
            return _mapper.Map<List<ResultCustomerWithCategoryDto >> (values);
        }

        public async Task<GetByIdCustomerDto> GetByIdCustomerAsync(string customerId)
        {
            var values = await _customerCollection.Find(x => x.CustomerId == customerId).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdCustomerDto>(values);
        }
        public async Task UpdateCustomerAsync(UpdateCustomerDto updateCustomerDto)
        {
            var values = _mapper.Map<Customer>(updateCustomerDto);
            await _customerCollection.FindOneAndReplaceAsync(x => x.CustomerId == updateCustomerDto.CustomerId, values);
        }
    }
}
