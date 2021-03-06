// <auto-generated />
using System;
using BurgerApp.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BurgerApp.Storage.Migrations
{
    [DbContext(typeof(BurgerDbContext))]
    [Migration("20220725152425_AddDateOrder")]
    partial class AddDateOrder
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BurgerApp.Domain.Enteties.Burger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("HasFries")
                        .HasColumnType("bit");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsVegan")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVegetarian")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.ToTable("Burgers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HasFries = true,
                            ImageURL = "https://cdn.sanity.io/images/czqk28jt/prod_bk_us/84743a96a55cb36ef603c512d5b97c9141c40a33-1333x1333.png?w=750&q=40&fit=max&auto=format",
                            IsVegan = false,
                            IsVegetarian = false,
                            Name = "Whooper",
                            Price = 12m
                        },
                        new
                        {
                            Id = 2,
                            HasFries = true,
                            ImageURL = "https://cdn.sanity.io/images/czqk28jt/prod_bk_us/f574650a6eecf9595cfcd164387cd6bbc54b5040-1333x1333.png?w=750&q=40&fit=max&auto=format",
                            IsVegan = true,
                            IsVegetarian = false,
                            Name = "Vegy",
                            Price = 18m
                        },
                        new
                        {
                            Id = 3,
                            HasFries = false,
                            ImageURL = "https://freepngimg.com/thumb/salad/76555-king-hamburger-mcdonald's-cheeseburger-veggie-pounder-burger.png",
                            IsVegan = false,
                            IsVegetarian = true,
                            Name = "Nature",
                            Price = 20m
                        },
                        new
                        {
                            Id = 4,
                            HasFries = true,
                            ImageURL = "https://cdn.shopify.com/s/files/1/0271/0205/2407/products/03299-86_20DIG_Silo_Double_20Whopper_500x540_CR_500x.png?v=1597779164",
                            IsVegan = false,
                            IsVegetarian = false,
                            Name = "Double Whooper",
                            Price = 24m
                        },
                        new
                        {
                            Id = 5,
                            HasFries = true,
                            ImageURL = "https://cdn.sanity.io/images/czqk28jt/prod_bk_us/bcd42730abc57596736977ba25daae24d197354a-1333x1333.png?w=750&q=40&fit=max&auto=format",
                            IsVegan = false,
                            IsVegetarian = false,
                            Name = "Chiken Burger",
                            Price = 10m
                        },
                        new
                        {
                            Id = 6,
                            HasFries = true,
                            ImageURL = "https://cdn.sanity.io/images/czqk28jt/prod_bk_us/f3d7588c1f46ad6a1afaa3404cec65ed6053879f-1333x1333.png?w=750&q=40&fit=max&auto=format",
                            IsVegan = false,
                            IsVegetarian = false,
                            Name = "DoubleChesse Burger",
                            Price = 10m
                        });
                });

            modelBuilder.Entity("BurgerApp.Domain.Enteties.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserFk")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserFk");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BurgerApp.Domain.Enteties.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Adress = "Bulevar 12",
                            FirstName = "Tomy",
                            LastName = "Cruse",
                            PhoneNumber = "222 222 333"
                        },
                        new
                        {
                            Id = 2,
                            Adress = "Bulevar 11",
                            FirstName = "Jhon",
                            LastName = "Klon",
                            PhoneNumber = "222 111 131"
                        },
                        new
                        {
                            Id = 3,
                            Adress = "Bulevar 7",
                            FirstName = "Elizabet",
                            LastName = "Brown",
                            PhoneNumber = "222 244 232"
                        });
                });

            modelBuilder.Entity("BurgerOrder", b =>
                {
                    b.Property<int>("BurgersId")
                        .HasColumnType("int");

                    b.Property<int>("OrdersId")
                        .HasColumnType("int");

                    b.HasKey("BurgersId", "OrdersId");

                    b.HasIndex("OrdersId");

                    b.ToTable("BurgerOrder");
                });

            modelBuilder.Entity("BurgerApp.Domain.Enteties.Order", b =>
                {
                    b.HasOne("BurgerApp.Domain.Enteties.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BurgerOrder", b =>
                {
                    b.HasOne("BurgerApp.Domain.Enteties.Burger", null)
                        .WithMany()
                        .HasForeignKey("BurgersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BurgerApp.Domain.Enteties.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BurgerApp.Domain.Enteties.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
