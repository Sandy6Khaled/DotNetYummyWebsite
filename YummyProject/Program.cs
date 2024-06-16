using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using YummyProject.Contexts;
using YummyProject.Models;
using YummyProject.Repositories.Classes;
using YummyProject.Repositories.Interfaces;


namespace YummyProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<YummyContext>(op => 
                op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                );

            builder.Services.AddScoped<IMealRepo, MealRepo>();
            builder.Services.AddScoped<IAreaRepo, AreaRepo>();
            builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
            builder.Services.AddScoped<IMealIngredientRepo, MealIngredientRepo>();
            builder.Services.AddScoped<IIngredientRepo,  IngredientRepo>();
            builder.Services.AddScoped<IUserRepo, UserRepo>();
            builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<YummyContext>();


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
        }
    }
}
