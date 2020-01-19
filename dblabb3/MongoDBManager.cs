using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace dblabb3
{
    public class MongoDBManager
    {
        //Fields for MongoDB
        private IMongoDatabase db;
        private MongoClient mongoClient;
        private IMongoCollection<BsonDocument> restaurants;

        //Insert fields for other databases

        public MongoDBManager()
        {
            MongoUrlBuilder urlBuilder = new MongoUrlBuilder();
            urlBuilder.Server = new MongoServerAddress("localhost", 27017);
            urlBuilder.Scheme = MongoDB.Driver.Core.Configuration.ConnectionStringScheme.MongoDB;
            mongoClient = new MongoClient(urlBuilder.ToMongoUrl());
            db = mongoClient.GetDatabase("labb3");
            restaurants = db.GetCollection<BsonDocument>("restaurants");
        }

        public void SeedDb()
        {
            List<Restaurant> seedData = new List<Restaurant>
            {
                new Restaurant
                {
                    Id =  new ObjectId("5c39f9b5df831369c19b6bca"),
                    Name = "Sun Bakery Trattoria",
                    Stars = 4,
                    Categories = new string[] { "Pizza", "Pasta", "Italian", "Coffee", "Sandwiches"}
                },
                new Restaurant
                {
                    Id =  new ObjectId("5c39f9b5df831369c19b6bcb"),
                    Name = "Blue Bagels Grill",
                    Stars = 3,
                    Categories = new string[] { "Bagels", "Cookies", "Sandwiches" }
                },
                new Restaurant
                {
                    Id =  new ObjectId("5c39f9b5df831369c19b6bcc"),
                    Name = "Hot Bakery Cafe",
                    Stars = 4,
                    Categories = new string[] { "Bakery", "Cafe", "Coffee", "Dessert" }
                },
                new Restaurant
                {
                    Id =  new ObjectId("5c39f9b5df831369c19b6bcd"),
                    Name = "XYZ Coffee Bar",
                    Stars = 5,
                    Categories = new string[] { "Coffee", "Cafe", "Bakery", "Chocolates" }
                },
                new Restaurant
                {
                    Id =  new ObjectId("5c39f9b5df831369c19b6bce"),
                    Name = "456 Cookies Shop",
                    Stars = 4,
                    Categories = new string[] { "Bakery", "Cookies", "Cake", "Coffee" }
                }
            };

            foreach (var item in seedData)
            {
                restaurants.InsertOne(item.ToBsonDocument());
            }
        }

        public void PrintAllDocuments()
        {
            var allBsonRestaurants = restaurants.Find(new BsonDocument()).ToList();
            foreach (var bsonRestaurant in allBsonRestaurants)
            {
                Console.WriteLine(BsonSerializer.Deserialize<Restaurant>(bsonRestaurant).ToString());
            }
        }
    }
}