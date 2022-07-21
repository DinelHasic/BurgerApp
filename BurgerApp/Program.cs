using BurgerApp.Contracts;
using BurgerApp.Domain.Repository;
using BurgerApp.Domain.UnitOfWork;
using BurgerApp.Services;
using BurgerApp.Storage;
using BurgerApp.Storage.Repository;
using BurgerApp.Storage.UnitOfWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

string databaseConnectionString = builder.Configuration.GetConnectionString("Database");

builder.Services.AddScoped<IBurgerServices, BurgerServices>()
                .AddScoped<IBurgerRepository, BurgerRepository>()
                .AddScoped<IOrderServices, OrderServices>()
                .AddScoped<IOrderRepository, OrderRepository>()
                .AddDbContext<BurgerDbContext>(options =>
                 {
                     options.UseSqlServer(databaseConnectionString);
                 })
                .AddScoped<IBurgerDbContext, BurgerDbContext>()
                .AddScoped<IUserServices, UserServices>()
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<IUserRepository, UserRepository>();
                


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
