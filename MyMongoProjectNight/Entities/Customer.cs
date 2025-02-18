using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyMongoProjectNight.Entities
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] //ilgili propertynin veri türünü özelleştirmeye yarar

        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string DepartmentId { get; set; }
        [BsonIgnore]//üzerinde bulunduğu propertyi göstermeyecek
        public Department Department { get; set; }
    }
}