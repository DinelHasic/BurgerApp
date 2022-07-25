using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BurgerApp.Models.ViewModel
{
    public class BurgerViewModel
    {
        public int BurgerId { get; set; }

        [Required]
        [StringLength(15,MinimumLength = 3)]
        [DisplayName("Name:")]
        public string BurgerName { get; set; }

        [DataType(DataType.Currency)]
        [DisplayName("Price:")]
        public decimal BurgerPrice { get; set; }

        [DisplayName("Vegetarian")]
        public bool BurgerIsVegetarian { get; set; }

        [DisplayName("Vegan")]
        public bool BurgerIsVegan { get; set; }

        [DisplayName("Fries")]
        public bool BurgerHasFries { get; set; }

        [DisplayName("Image URL:")]
        [DataType(DataType.Url)]
        public string BurgerURL { get; set; }


    }
}
