using System;

namespace dblabb3
{
    class Program
    {
        static void Main(string[] args)
        {
            DbManager dbManager = new DbManager(DbManager.DbType.MongoDb);
            dbManager.db.
            Console.WriteLine("Hello World!");
        }
    }
}
