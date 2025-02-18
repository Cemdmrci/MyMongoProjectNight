using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MyMongoProjectNight.Entities
{
    public class Discount
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string DiscountId { get; set; }
        public int DiscountRate { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string? CategoryId { get; set; }
        [BsonIgnore]
        public Category Category { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string? ProductId { get; set; }
        [BsonIgnore]
        public Product Product { get; set; }
    }
}
