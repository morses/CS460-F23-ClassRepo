using HW4.Services;
using System.Net.Http.Headers;

namespace HW4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Retrieve our secrets from the user secrets store
            string bearerToken = builder.Configuration["TmdbBearerToken"];
            string tmdbBaseUrl = "https://api.themoviedb.org/3/";       // move this to the secrets store if you might need to change it without re-compiling

            // Register our service and give it an HttpClient.  See: https://learn.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests
            // We need to customize its creation in order to set the starting URL and secret bearer token
            builder.Services.AddHttpClient<IShowService, TmdbShowService>((httpClient,services) =>
            {
                httpClient.BaseAddress = new Uri(tmdbBaseUrl);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                return new TmdbShowService(httpClient, services.GetRequiredService<ILogger<TmdbShowService>>());
            });

            // Add Swagger for REST API live documentation and testing
            // Needs packages Swashbuckle.AspNetCore.SwaggerGen and Swashbuckle.AspNetCore.SwaggerUI
            builder.Services.AddSwaggerGen();

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
                app.UseSwagger();
                app.UseSwaggerUI();
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