using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace reservation_project.Datacontracts.Theaters
{
    public class TheaterEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string TheaterName { get; set; }
        public string City { get; set; }
        public string PlaysId { get; set; }

    }
}
