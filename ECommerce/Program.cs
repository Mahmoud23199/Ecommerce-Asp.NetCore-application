using ECommerce.Models;
using ECommerce.RepositoryServices;
using Microsoft.AspNetCore.Mvc;
using ECommerce.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using ECommerce.Data.Cart;

namespace ECommerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Register DbContext
            builder.Services.AddDbContext<EcommerceContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped(typeof(IgenericRepository<>), typeof(genericRepository<>));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWorkClass>();
            //shopcart
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddScoped(sc=>ShoppingCart.GetShoppingCart(sc));
            builder.Services.AddSession();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
