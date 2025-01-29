using Microsoft.Extensions.FileProviders;

namespace RecoilMagnetWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            var app = builder.Build();

            // Serve static files from the 'Frontend' folder
            app.UseStaticFiles();  // This serves files from the wwwroot folder by default

            // If you want to use a custom folder like 'Frontend', specify its path
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Frontend")),
                RequestPath = "/frontend"
            });

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                // Enable Developer Exception Page or other dev tools here if necessary
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            // Set up default route for the Index.html
            app.MapGet("/", async context =>
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "Frontend", "Index.html");
                await context.Response.SendFileAsync(path);
            });
            // Set up a route for pricing.html
            app.MapGet("/pricing", async context =>
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "Frontend", "pricing.html");
                await context.Response.SendFileAsync(path);
            });

            app.MapControllers();

            app.Run();
        }
    }
}
