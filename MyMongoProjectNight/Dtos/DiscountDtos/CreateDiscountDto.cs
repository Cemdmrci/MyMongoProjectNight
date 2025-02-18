namespace MyMongoProjectNight.Dtos.DiscountDtos
{
    public class CreateDiscountDto
    {
        public string? CategoryId { get; set; }
        public string? ProductId { get; set; }
        public int DiscountRate { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
