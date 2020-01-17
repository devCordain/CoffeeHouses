using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace dblabb3
{
    internal class DbManager
    {
        //Expandable enum for multiple database types
        public enum DbType {MongoDb};
        private DbType currentDbType;

        //Fields for MongoDB
        private IMongoDatabase mongoDb;
        private MongoClient mongoClient;
        private IMongoDatabase mongoDatabase;

        public DbManager(DbType dbType)
        {
            switch (dbType)
            {
                case DbType.MongoDb:
                    currentDbType = dbType;
                    break;
                default:
                    break;
            }
        }
        public void ConnectToServer()
        {
            switch (currentDbType)
            {
                case DbType.MongoDb:
                    MongoUrlBuilder urlBuilder = new MongoUrlBuilder();
                    urlBuilder.Server = new MongoServerAddress("localhost", 27017);
                    urlBuilder.Scheme = MongoDB.Driver.Core.Configuration.ConnectionStringScheme.MongoDB;
                    mongoClient = new MongoClient(urlBuilder.ToMongoUrl());
                    break;
                default:
                    break;
            }
        }

        public void SetDatabase(string databaseName)
        {
            switch (currentDbType)
            {
                case DbType.MongoDb:
                    mongoDatabase = mongoClient.GetDatabase(databaseName);
                    break;
                default:
                    break;
            }
        }
        public T GetCurrentDb<T>()
        {

        }

    }
}