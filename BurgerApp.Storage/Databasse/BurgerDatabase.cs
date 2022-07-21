

using BurgerApp.Domain.Enteties;

namespace BurgerApp.Storage.Database
{
    public  static class BurgerDatabase
    {
        public static List<Burger> Burgers = new List<Burger>()
        {
            new Burger(1,"Whooper",12,false,false,true,"https://cdn.sanity.io/images/czqk28jt/prod_bk_us/84743a96a55cb36ef603c512d5b97c9141c40a33-1333x1333.png?w=750&q=40&fit=max&auto=format"),
            new Burger(2,"Vegy",18,false,true,true,"https://cdn.sanity.io/images/czqk28jt/prod_bk_us/f574650a6eecf9595cfcd164387cd6bbc54b5040-1333x1333.png?w=750&q=40&fit=max&auto=format"),
            new Burger(3,"Nature",20,true,false,false,"https://freepngimg.com/thumb/salad/76555-king-hamburger-mcdonald's-cheeseburger-veggie-pounder-burger.png"),
            new Burger(4,"Double Whooper",24,false,false,true,"https://cdn.shopify.com/s/files/1/0271/0205/2407/products/03299-86_20DIG_Silo_Double_20Whopper_500x540_CR_500x.png?v=1597779164"),
            new Burger(5,"Chiken Burger",10,false,false,true,"https://cdn.sanity.io/images/czqk28jt/prod_bk_us/bcd42730abc57596736977ba25daae24d197354a-1333x1333.png?w=750&q=40&fit=max&auto=format"),
            new Burger(7,"DoubleChesse Burger",10,false,false,true,"https://cdn.sanity.io/images/czqk28jt/prod_bk_us/f3d7588c1f46ad6a1afaa3404cec65ed6053879f-1333x1333.png?w=750&q=40&fit=max&auto=format"),
        };

        public static List<User> Users = new List<User>()
        {
            new User(1,"Tomy","Cruse","Bulevar 12","222 222 333"),
            new User(2,"Jhon","Klon","Bulevar 11","222 111 131"),
            new User(3,"Elizabet","Brown","Bulevar 7","222 244 232")

        };

        public static List<Order> Orders = new List<Order>()
        {
            new Order(1,Users.First(),
                new List<Burger>(){
                    Burgers.First(),Burgers.Last()
                })
        };

    public static int GetNextBurgerId()
        {
            return (Burgers.OrderByDescending(x => x.Id)?.First().Id ?? 0) + 1;
        }
    }
}
