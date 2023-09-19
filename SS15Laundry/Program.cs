using Microsoft.EntityFrameworkCore;
using SS15Laundry.Data;
using SS15Laundry.Repository;

namespace SS15Laundry;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        //Connection String
        var conString = @"Server=localhost;Database=SS15Laundry;User Id=sa;Password=Strong.Pwd-123;TrustServerCertificate=true;";
        builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlServer(conString));
        // Add services to the container.
        builder.Services.AddTransient<IPickUpService, PickService>();
        builder.Services.AddControllersWithViews()
            .AddRazorRuntimeCompilation();

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

