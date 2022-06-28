using BurgerApp.Models.ViewModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BurgerApp.Models.Domain
{
    public class Burger
    {
        public int Id { get; set; }

        [DisplayName("Name:")]
        public string Name { get; set; }

        [DisplayName("Price:")]
        public decimal Price { get; set; }

        [DisplayName("Vegeterian")]
        public bool IsVegetarian { get; set; }

        [DisplayName("Vegan")]
        public bool IsVegan { get; set; }

        [DisplayName("Fries")]
        public bool HasFries { get; set; }

        [DisplayName("Image URL:")]
        [DataType(DataType.ImageUrl)]
        public string ImageURL { get; set; }

        public Burger()
        {

        }

        public Burger(int id, string name, decimal price, bool isVegetarian, bool isVegan, bool hasFries, string imageURL)
        {
            Id = id;
            Name = name;
            Price = price;
            IsVegetarian = isVegetarian;
            IsVegan = isVegan;
            HasFries = hasFries;
            ImageURL = imageURL;
        }

        public void Update(BurgerViewModel burgerNew)
        {
            Name = burgerNew.BurgerName;
            Price = burgerNew.BurgerPrice;
            IsVegan = burgerNew.BurgerIsVegan;
            IsVegetarian = burgerNew.BurgerIsVegetarian;
            HasFries = burgerNew.BurgerHasFries;
            ImageURL = burgerNew.BurgerURL;
        }

        internal void SetId(int id)
        {
            Id=id;
        }
    }
}
