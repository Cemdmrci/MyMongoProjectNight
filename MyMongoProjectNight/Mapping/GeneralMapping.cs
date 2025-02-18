using AutoMapper;
using MyMongoProjectNight.Dtos.CategoryDtos;
using MyMongoProjectNight.Dtos.CustomerDtos;
using MyMongoProjectNight.Dtos.DepartmentDtos;
using MyMongoProjectNight.Dtos.DiscountDtos;
using MyMongoProjectNight.Dtos.FeatureDtos;
using MyMongoProjectNight.Dtos.ProductDtos;
using MyMongoProjectNight.Dtos.SaleDtos;
using MyMongoProjectNight.Entities;

namespace MyMongoProjectNight.Mapping
{
    public class GeneralMapping : Profile //Profile Automapperın metotlarını tutmamızı sağlıyor.
    {
        public GeneralMapping()
        {
            CreateMap<Customer, CreateCustomerDto>().ReverseMap();
            CreateMap<Customer, UpdateCustomerDto>().ReverseMap();
            CreateMap<Customer, ResultCustomerDto>().ReverseMap();
            CreateMap<Customer, GetByIdCustomerDto>().ReverseMap();

            CreateMap<Department, CreateDepartmentDto>().ReverseMap();
            CreateMap<Department, UpdateDepartmentDto>().ReverseMap();
            CreateMap<Department, ResultDepartmentDto>().ReverseMap();
            CreateMap<Department, GetByIdDepartmentDto>().ReverseMap();

            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDto>().ReverseMap();

            CreateMap<Discount, CreateDiscountDto>().ReverseMap();
            CreateMap<Discount, UpdateDiscountDto>().ReverseMap();
            CreateMap<Discount, ResultDiscountDto>().ReverseMap();
            CreateMap<Discount, GetByIdDiscountDto>().ReverseMap();

            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();

            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();

            CreateMap<Sale, CreateSaleDto>().ReverseMap();
            CreateMap<Sale, UpdateSaleDto>().ReverseMap();
            CreateMap<Sale, ResultSaleDto>().ReverseMap();
            CreateMap<Sale, GetByIdSaleDto>().ReverseMap();

            CreateMap<Customer, ResultCustomerWithCategoryDto>().ForMember(x => x.DepartmentName, y => y.MapFrom(z => z.Department.DepartmentName));

            CreateMap<Product, ResultProductWithCategoryDto>()
                .ForMember(x => x.CategoryName, y => y.MapFrom(z => z.Category.CategoryName))
                .ForMember(a => a.CategoryImageURL, b => b.MapFrom(c => c.Category.CategoryImageURL));

            CreateMap<Sale, ResultSaleWithProductDto>()
        .ForMember(x => x.ProductName, y => y.MapFrom(z => z.Product.ProductName))
        .ForMember(x => x.Price, y => y.MapFrom(z => z.Product.Price))
        .ForMember(x => x.ProductImageURL, y => y.MapFrom(z => z.Product.ProductImageURL));
        }
    }
}
