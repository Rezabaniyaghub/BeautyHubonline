using DataAccess.Entity;
using DataAccess.Repositorys;
using Domain.Abstract;
using Domain.Services;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver.Core.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddTransient<IApponintmentRepository, AppointmentRepository>();
        builder.Services.AddTransient<IAppointmentService, AppointmentService>();

        builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
        builder.Services.AddTransient<ICustomerServicee, CustomerService>();

        builder.Services.AddTransient<ICustomerServiceRepository, CustomerServiceRepository>();
        builder.Services.AddTransient<ICustomerSevice2, CustomerService2>();

        builder.Services.AddTransient<IGivingTimeRepository, GivingTimeRepository>();
        builder.Services.AddTransient<IGivingTimeService, GivingTimeServise>();

        builder.Services.AddTransient<IHirstylRepository, HairstylistRepository>();
        builder.Services.AddTransient<IHirstylService, HirstylService>();

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString, b => b.MigrationsAssembly("DataAccess")));

        // Add services to the container.
        builder.Services.AddControllersWithViews();

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