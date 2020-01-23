using System;
using MongoDB.Driver;

namespace dblabb3
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoDBManager dbManager = new MongoDBManager();


            //Nedan är metodanropen med invariabler som jag gör för att klara uppgifterna i labben.
            //dbManager.SeedDb();
            //dbManager.PrintAllDocuments();
            //dbManager.PrintAllDocumentNamesInCategory("Cafe");
            //dbManager.UpdateStars("XYZ Coffee Bar", 2);
            //dbManager.UpdateName("XYZ Coffee Bar", "Bara bar baren");
            //dbManager.UpdateName("Bara bar baren", "XYZ Coffee Bar");
            //dbManager.TopRestaurants(4);
        }
    }
}

