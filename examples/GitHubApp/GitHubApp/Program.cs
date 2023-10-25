using GitHubApp.Services;
using System.Net.Http.Headers;

namespace GitHubApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string gitHubAPIKey = builder.Configuration["GitHubAPIKey"];
            string gitHubAPIUrl = "https://api.github.com/";

            builder.Services.AddHttpClient<IGitHubService, GitHubService>((httpClient,services) =>
            {
                httpClient.BaseAddress = new Uri(gitHubAPIUrl);
                httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github+json");
                httpClient.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");
                httpClient.DefaultRequestHeaders.Add("User-Agent", "CS460-ExampleGitHubApp");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", gitHubAPIKey);
                return new GitHubService(httpClient, services.GetRequiredService<ILogger<GitHubService>>());
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Add Swagger
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
                app.UseSwagger();
                app.UseSwaggerUI();
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
}