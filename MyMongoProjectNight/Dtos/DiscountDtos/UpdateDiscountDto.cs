﻿namespace MyMongoProjectNight.Dtos.DiscountDtos
{
    public class UpdateDiscountDto
    {
        public string DiscountId { get; set; }
        public int DiscountRate { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? CategoryId { get; set; }
        public string? ProductId { get; set; }
    }
}
