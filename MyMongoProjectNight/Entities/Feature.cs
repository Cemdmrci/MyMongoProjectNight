﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MyMongoProjectNight.Entities
{
    public class Feature
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string FeatureId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FeatureImageURL { get; set; }
    }
}
