
using BurgerApp.Models.Domain;

namespace BurgerApp.Storage
{
    public static class Database
    {

        public static List<Burger> Burgers = new List<Burger>()
        {
            new Burger("Whooper",12,false,false,true,"https://static.independent.co.uk/2022/03/31/14/burger%20king%20whopper%20%281%29.jpg?width=1200"),
            new Burger("Vegy",18,false,true,true,"https://www.kindpng.com/picc/m/160-1607050_come-into-our-hamburger-planet-there-hamburger-for.png"),
            new Burger("Nature",20,true,false,false,"https://assets.bonappetit.com/photos/57acae2d1b33404414975121/5:4/w_3029,h_2423,c_limit/ultimate-veggie-burger.jpg"),
            new Burger("Double Whooper",24,false,false,true,"https://cdn.shopify.com/s/files/1/0271/0205/2407/products/03299-86_20DIG_Silo_Double_20Whopper_500x540_CR_500x.png?v=1597779164"),
            new Burger("Chesse Burger",10,false,false,true,"https://uae.burgerking.me/Images/Products/CHEESEBURGER.jpg"),
            new Burger("DoubleChesse Burger",10,false,false,true,"https://fastfoodnutrition.org/item-photos/full/2089_s.jpg"),
        };
    }
}
