
using Microsoft.AspNetCore.Mvc;
using Scalar.AspNetCore;

namespace AspireScalarSample.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.MapScalarApiReference(opts =>
                opts.WithTitle("App Scalar Dashboard")
                    .WithTheme(ScalarTheme.BluePlanet)
                    .WithDefaultHttpClient(ScalarTarget.Shell, ScalarClient.Curl)
            );

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapPost("/upload", ([FromForm] IFormFile file) => file.Length > 0)
                .WithName("Upload")
                .AllowAnonymous();

            app.Run();
        }
    }
}
