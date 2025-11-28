using HealthCalculator.Interfaces;
using HealthCalculator.Models;
using HealthCalculator.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddOpenApi();
builder.Services.AddRazorPages();

// Register application services
builder.Services.AddScoped<IBmiService, BmiService>();
builder.Services.AddScoped<IBmrService, BmrService>();
builder.Services.AddScoped<ITdeeService, TdeeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();

app.MapPost("/health/bmi", ([FromServices] IBmiService service, [FromBody] BmiRequest request) =>
{
    return Results.Ok(service.CalculateBmi(request));
})
.WithName("CalculateBmi");

app.MapPost("/health/bmr", ([FromServices] IBmrService service, [FromBody] BmrRequest request) =>
{
    return Results.Ok(service.CalculateBmr(request));
})
.WithName("CalculateBmr");

app.MapPost("/health/tdee", ([FromServices] ITdeeService service, [FromBody] TdeeRequest request) =>
{
    return Results.Ok(service.CalculateTdee(request));
})
.WithName("CalculateTdee");

app.Run();

public partial class Program { }
