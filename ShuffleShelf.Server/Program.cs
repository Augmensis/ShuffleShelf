using ShuffleShelf.Server.Services;

namespace ShuffleShelf.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // NOTE: The MS User Secrets facility is a pain for anyone not using 
            // Visual Studio (e.g. Rider, VS Code, etc). Using the appsettings.local
            // allows for greater portability and easier local testing.
            builder.Configuration.AddJsonFile(x =>
            {
                x.Path = "appsettings.Local.json";
                x.Optional = true;
                x.ReloadOnChange = true;
            });

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<HttpClient>();
            builder.Services.AddScoped<AlgoliaService>();

            var app = builder.Build();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseCors(opt =>
                {
                    opt.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
                });
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.MapFallbackToFile("/index.html");
            app.Run();
        }
    }
}
