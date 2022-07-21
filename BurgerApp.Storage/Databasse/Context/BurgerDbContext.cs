using BurgerApp.Domain.Enteties;
using Microsoft.EntityFrameworkCore;

namespace BurgerApp.Storage
{
    public class BurgerDbContext : DbContext, IBurgerDbContext
    {
        public DbSet<Burger> Burgers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<User>  Users { get; set; }

        public BurgerDbContext(DbContextOptions<BurgerDbContext> option):base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Burger>().Property(x => x.Price).HasColumnType("money");
            modelBuilder.Entity<User>().HasMany(x => x.Orders).WithOne(x => x.User).HasForeignKey(x => x.UserFk);
        }
    }
}
