namespace BurgerApp.Models.Domain
{
    public class Burger
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public bool IsVegetarian { get; set; }

        public bool IsVegan { get; set; }

        public bool HasFries { get; set; }

        public string ImageURL { get; set; }

        public Burger(string name, decimal price, bool isVegetarian, bool isVegan, bool hasFries, string imageURL)
        {
            Name = name;
            Price = price;
            IsVegetarian = isVegetarian;
            IsVegan = isVegan;
            HasFries = hasFries;
            ImageURL = imageURL;
        }
    }
}
