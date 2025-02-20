namespace MyMongoProjectNight.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ProductImageURL { get; set; }
    }
}
