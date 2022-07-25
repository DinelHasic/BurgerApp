using BurgerApp.Domain.Enteties;
using Microsoft.EntityFrameworkCore;

namespace BurgerApp.Storage
{
    public class BurgerDbContext : DbContext, IBurgerDbContext
    {
        public DbSet<Burger> Burgers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<User> Users { get; set; }

        public BurgerDbContext(DbContextOptions<BurgerDbContext> option) : base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Burger>().Property(x => x.Price).HasColumnType("money");
            modelBuilder.Entity<User>().HasMany(x => x.Orders).WithOne(x => x.User).HasForeignKey(x => x.UserFk);
            modelBuilder.Entity<Order>().Property<DateTime>("OrderDate");

            modelBuilder.Entity<Burger>().HasData
            (
            new Burger("Whooper", 12, false, false, true, "https://cdn.sanity.io/images/czqk28jt/prod_bk_us/84743a96a55cb36ef603c512d5b97c9141c40a33-1333x1333.png?w=750&q=40&fit=max&auto=format") {Id = 1},
            new Burger("Vegy", 18, false, true, true, "https://cdn.sanity.io/images/czqk28jt/prod_bk_us/f574650a6eecf9595cfcd164387cd6bbc54b5040-1333x1333.png?w=750&q=40&fit=max&auto=format") { Id = 2 },
            new Burger("Nature", 20, true, false, false, "https://freepngimg.com/thumb/salad/76555-king-hamburger-mcdonald's-cheeseburger-veggie-pounder-burger.png") { Id = 3 },
            new Burger("Double Whooper", 24, false, false, true, "https://cdn.shopify.com/s/files/1/0271/0205/2407/products/03299-86_20DIG_Silo_Double_20Whopper_500x540_CR_500x.png?v=1597779164") { Id = 4 },
            new Burger("Chiken Burger", 10, false, false, true, "https://cdn.sanity.io/images/czqk28jt/prod_bk_us/bcd42730abc57596736977ba25daae24d197354a-1333x1333.png?w=750&q=40&fit=max&auto=format") { Id = 5 },
            new Burger("DoubleChesse Burger", 10, false, false, true, "https://cdn.sanity.io/images/czqk28jt/prod_bk_us/f3d7588c1f46ad6a1afaa3404cec65ed6053879f-1333x1333.png?w=750&q=40&fit=max&auto=format") { Id = 6 }
            );

            modelBuilder.Entity<User>().HasData
            (
            new User("Tomy", "Cruse", "Bulevar 12", "222 222 333") {Id = 1 },
            new User("Jhon", "Klon", "Bulevar 11", "222 111 131") { Id = 2 },
            new User("Elizabet", "Brown", "Bulevar 7", "222 244 232") { Id = 3 } 
            );

            
        }
    }
}
