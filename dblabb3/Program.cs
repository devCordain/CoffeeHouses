using System;
using MongoDB.Driver;

namespace dblabb3
{
    class Program
    {
        static void Main(string[] args)
        {
            DbManager dbManager = new DbManager(DbManager.DbType.MongoDb);
            dbManager.ConnectToServer();
            var db = dbManager.GetCurrentDb<IMongoDatabase>();
            dbManager.SetDatabase("dblabb3");
            
        }
    }
}
