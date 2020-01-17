using System;
using MongoDB.Driver;

namespace dblabb3
{
    internal class DbManager
    {
        public enum DbType {MongoDb}
        public object db;
        public DbManager(DbType dbType)
        {
            switch (dbType)
            {
                case DbType.MongoDb:
                    db = SetupMongoDb();
                    break;
                default:
                    break;
            }
        }

        private IMongoDatabase SetupMongoDb()
        {            
            MongoUrlBuilder urlBuilder = new MongoUrlBuilder();
            urlBuilder.Server = new MongoServerAddress("localhost", 27017);
            urlBuilder.Scheme = MongoDB.Driver.Core.Configuration.ConnectionStringScheme.MongoDB;

            MongoClient mongoClient = new MongoClient(urlBuilder.ToMongoUrl());
            return mongoClient.GetDatabase("lab3");
            //var collection = db.GetCollection<BsonDocument>("collectionName");
        }
    }
}