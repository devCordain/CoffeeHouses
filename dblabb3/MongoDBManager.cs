using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace dblabb3
{
    public class MongoDBManager
    {
        //Fields for MongoDB
        private IMongoDatabase db { get; set; }
        private MongoClient mongoClient;

        //Insert fields for other databases

        public MongoDBManager()
        {
            MongoUrlBuilder urlBuilder = new MongoUrlBuilder();
            urlBuilder.Server = new MongoServerAddress("localhost", 27017);
            urlBuilder.Scheme = MongoDB.Driver.Core.Configuration.ConnectionStringScheme.MongoDB;
            mongoClient = new MongoClient(urlBuilder.ToMongoUrl());
            SetDb("labb3");
            SetCollection("restaurants");
        }


        private void SetDb(string databaseName)
        {
            db = mongoClient.GetDatabase(databaseName);
        }
        
        private void SeedDb()
        {
            List<Restaurant> seedData = new List<Restaurant>
            {
                new Restaurant("5c39f9b5df831369c19b6bca", "Sun Bakery Trattoria", 4, new string[] { "Pizza", "Pasta", "Italian", "Coffee", "Sandwiches"}),
                new Restaurant("5c39f9b5df831369c19b6bcb", "Blue Bagels Grill", 4, new string[] { "Pizza", "Pasta", "Italian", "Coffee", "Sandwiches"}),
                new Restaurant("5c39f9b5df831369c19b6bca", "Sun Bakery Trattoria", 4, new string[] { "Pizza", "Pasta", "Italian", "Coffee", "Sandwiches"}),
                new Restaurant("5c39f9b5df831369c19b6bca", "Sun Bakery Trattoria", 4, new string[] { "Pizza", "Pasta", "Italian", "Coffee", "Sandwiches"}),
                new Restaurant("5c39f9b5df831369c19b6bca", "Sun Bakery Trattoria", 4, new string[] { "Pizza", "Pasta", "Italian", "Coffee", "Sandwiches"}),
                "{ '_id' : ObjectId(''), 'name' : '', 'stars' : 3,  'categories' : [ 'Bagels', 'Cookies', 'Sandwiches' ] }",
                "{ '_id' : ObjectId('5c39f9b5df831369c19b6bcc'), 'name' : 'Hot Bakery Cafe', 'stars' : 4, 'categories' : [ 'Bakery', 'Cafe', 'Coffee', 'Dessert' ] }",
                "{ '_id' : ObjectId('5c39f9b5df831369c19b6bcd'), 'name' : 'XYZ Coffee Bar', 'stars' : 5, 'categories' : [ 'Coffee', 'Cafe', 'Bakery', 'Chocolates' ] }",
                "{ '_id' : ObjectId('5c39f9b5df831369c19b6bce'), 'name' : '456 Cookies Shop', 'stars' : 4, 'categories' : [ 'Bakery', 'Cookies', 'Cake', 'Coffee' ] }"
            };

            IMongoCollection<Restaurant> restaurants = db.GetCollection<Restaurant>("restaurants");

            restaurants.InsertMany(seedData);
        }
    }
}