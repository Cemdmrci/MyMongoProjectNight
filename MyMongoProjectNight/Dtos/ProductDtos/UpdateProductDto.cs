﻿namespace MyMongoProjectNight.Dtos.ProductDtos
{
    public class UpdateProductDto
    {
        public string ProductId { get; set; }
        public string CategoryId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ProductImageURL { get; set; }
    }
}
