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

        public override string ToString()
        {
            var cat = "";

            for (int i = 0; i < Categories.Length; i++)
            {
                cat += ", " + Categories[i];
            }

            return "Name: " + Name + ", Stars: " + Stars + ", Categories: " + cat + ".";
        }
    }
}