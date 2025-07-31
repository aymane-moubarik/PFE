var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Simulation d'une liste de produits en mémoire
using BackendApi.Models;
using BackendApi.Services;
var products = new List<Product>
{
    new Product { Id = 1, Nom = "Produit A", CodeBarres = "123456", DateProduction = DateTime.UtcNow.AddMonths(-1), DateExpiration = DateTime.UtcNow.AddDays(6) },
    new Product { Id = 2, Nom = "Produit B", CodeBarres = "789012", DateProduction = DateTime.UtcNow.AddMonths(-2), DateExpiration = DateTime.UtcNow.AddDays(10) }
};
var alertService = new ProductAlertService(products);
alertService.Start();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
