using Microsoft.EntityFrameworkCore;
using MyWeatherJournal.API.Extensions;
using MyWeatherJournal.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationServices();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// SwashBuckle is a Nuget Package that integrates Swagger/OpenAPI with ASP.NET Core Apps
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// The Vue Client App runs on a different Port, need to configure CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .WithOrigins(
                "http://localhost:5173",    // dev
                "http://localhost:3000"     // production
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Register DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();       // Serves the OpenAPI JSON
    app.UseSwaggerUI();     // Serves the Swagger UI (web page)
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
