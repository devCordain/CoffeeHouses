using System;
using MongoDB.Driver;

namespace dblabb3
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoDBManager dbManager = new MongoDBManager();
            //dbManager.SeedDb();
            dbManager.PrintAllDocuments();
        }
    }
}
