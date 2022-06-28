using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BurgerApp.Models.ViewModel
{
    public class BurgerViewModel
    {
        public int BurgerId { get; set; }

        [DisplayName("Name:")]
        public string BurgerName { get; set; }

        [DisplayName("Price:")]
        public decimal BurgerPrice { get; set; }

        [DisplayName("Vegetarian")]
        public bool BurgerIsVegetarian { get; set; }

        [DisplayName("Vegan")]
        public bool BurgerIsVegan { get; set; }

        [DisplayName("Fries")]
        public bool BurgerHasFries { get; set; }

        [DisplayName("Image URL:")]
        public string BurgerURL { get; set; }


    }
}
