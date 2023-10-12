using HW2.DAL.Abstract;
using HW2.DAL.Concrete;
using HW2.Models;
using Microsoft.EntityFrameworkCore;

namespace HW2;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        string connectionString = builder.Configuration.GetConnectionString("StreamingConnectionDocker");
        builder.Services.AddDbContext<StreamingDbContext>(options => options
            .UseLazyLoadingProxies()
            .UseSqlServer(connectionString));
        builder.Services.AddScoped<DbContext, StreamingDbContext>();         // Need this line since our generic repository is based on DbContext directly
        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));    // Easy way to register all the generic repositories 
        builder.Services.AddScoped<IShowRepository,ShowRepository>();
        builder.Services.AddScoped<IGenreRepository,GenreRepository>();
        builder.Services.AddScoped<IRoleRepository,RoleRepository>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        else
        {
            app.UseDeveloperExceptionPage();
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
