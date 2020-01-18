namespace dblabb3
{
    internal class Restaurant
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Stars { get; set; }
        public string[] Categories { get; set; }

        public Restaurant() 
        {
        
        }

        public Restaurant(string id, string name, int stars, string[] categories)
        {
            Id = id;
            Name = name;
            Stars = stars;
            Categories = categories;
        }
    }
}