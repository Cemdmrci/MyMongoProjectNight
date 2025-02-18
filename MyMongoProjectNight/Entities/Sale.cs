using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MyMongoProjectNight.Entities
{
    public class Sale
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SaleId { get; set; }
        public int NumberOfProducts { get; set; }
        public decimal TotalPrice { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }
        [BsonIgnore]
        public Product Product { get; set; }
    }
}
