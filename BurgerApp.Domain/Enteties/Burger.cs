using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Domain.Enteties
{
    public class Burger : BaseEntity
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool IsVegetarian { get; set; }

        public bool IsVegan { get; set; }

        public bool HasFries { get; set; }

        public string ImageURL { get; set; }

        public List<Order> Orders { get; set; }

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


        internal void SetId(int id)
        {
            Id = id;
        }
    }
}
