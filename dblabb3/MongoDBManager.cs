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
            var urlBuilder = new MongoUrlBuilder();
            urlBuilder.Server = new MongoServerAddress("localhost", 27017);
            urlBuilder.Scheme = MongoDB.Driver.Core.Configuration.ConnectionStringScheme.MongoDB;
            mongoClient = new MongoClient(urlBuilder.ToMongoUrl());
            db = mongoClient.GetDatabase("labb3");
            restaurants = db.GetCollection<BsonDocument>("restaurants");
        }

        public void SeedDb()
        {
            var seedData = new List<Restaurant>
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

        //Skriv en metod som skriver ut (Console.Writeline) alla dokument i samlingen.
        public void PrintAllDocuments()
        {
            var allBsonRestaurants = restaurants.Find(new BsonDocument()).ToList();
            foreach (var bsonRestaurant in allBsonRestaurants)
            {
                Console.WriteLine(BsonSerializer.Deserialize<Restaurant>(bsonRestaurant).ToString());
            }
        }

        //Skriv en metod som skriver ut namnet på alla dokument som har kategorin “Cafe” 
        //OBS! Exkludera id så att bara namn visas
        public void PrintAllDocumentNamesInCategory(string searchCategory)
        {
            var categoryFilter = Builders<BsonDocument>.Filter.Where(rest => rest["Categories"] == searchCategory);
            var allMatches = restaurants.Find(categoryFilter).ToList();
       
            foreach (var item in allMatches)
            {
                Console.WriteLine(BsonSerializer.Deserialize<Restaurant>(item).Name);
            }
        }

        //Skriv en metod som uppdaterar genom increment “stars” för den restaurang som har “name” “XYZ Coffee Bar” 
        //så att nya värdet på stars blir 6. 
        //OBS! Ni ska använda increment.
        //OBS! Skriv ut alla restauranger igen, så att jag kan se att “stars” blivit 6, för denna restaurang när jag kör ert program. 
        public void UpdateStars(string restaurantName, int incrementBy)
        {
            var filter = Builders<BsonDocument>.Filter.Where(rest => rest["Name"] == restaurantName);
            var update = Builders<BsonDocument>.Update.Inc("Stars", incrementBy);

            var rest = BsonSerializer.Deserialize<Restaurant>(restaurants.Find(filter).Single());
            Console.WriteLine(rest.Name + ", stars before update: " + rest.Stars);
            restaurants.UpdateOne(filter, update);
            rest = BsonSerializer.Deserialize<Restaurant>(restaurants.Find(filter).Single());
            Console.WriteLine(rest.Name + ", stars after update: " + rest.Stars);
        }

        //Skriv en metod som uppdaterar “name” för "456 Cookies Shop" till “123 Cookies Heaven” 
        //OBS! Skriv ut alla restauranger igen, så att jag kan se att namnet ändrats för denna restaurang när jag kör ert program.
        public void UpdateName(string restaurantName, string newName)
        {
            var filter = Builders<BsonDocument>.Filter.Where(rest => rest["Name"] == restaurantName);
            var update = Builders<BsonDocument>.Update.Set("Name", newName);
            Console.WriteLine(BsonSerializer.Deserialize<Restaurant>(restaurants.Find(filter).Single()).ToString());
            restaurants.UpdateOne(filter, update);
            filter = Builders<BsonDocument>.Filter.Where(rest => rest["Name"] == newName);
            Console.WriteLine(BsonSerializer.Deserialize<Restaurant>(restaurants.Find(filter).Single()).ToString());
        }

        //Skriv en metod som aggregerar en lista med alla restauranger som har 4 eller fler “stars” och skriver ut endast “name” och “stars” 
        //OBS! Metoderna ska skriva ut via Console.Writeline resultatet, det vill säga, när jag kör ert program ska jag se resultatet från utskrifterna.

        public void TopRestaurants(int minStars)
        {
            var filter = Builders<BsonDocument>.Filter.Where(rest => rest["Stars"] >= minStars);
            var topRestaurants = restaurants.Aggregate().Match(filter).SortByDescending(rest => rest["Stars"]).ToList();
            foreach (var item in topRestaurants)
            {
                var rest = BsonSerializer.Deserialize<Restaurant>(item);
                Console.WriteLine("Name: " + rest.Name + ", Stars: " + rest.Stars);
            }
        }

    }
}