using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dblabb3
{
    internal class Restaurant
    {
        [BsonElement("Id")]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public int Stars { get; set; }
        public string[] Categories { get; set; }
    }
}