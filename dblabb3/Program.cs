using System;
using MongoDB.Driver;

namespace dblabb3
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoDBManager dbManager = new MongoDBManager(MongoDBManager.DbType.MongoDb);
            dbManager.ConnectToServer();
            var db = dbManager.GetCurrentDb<IMongoDatabase>();
            dbManager.SetDatabase("dblabb3");
            
        }
    }
}
