var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// SwashBuckle is a Nuget Package that integrates Swagger/OpenAPI with ASP.NET Core Apps
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();       // Serves the OpenAPI JSON
    app.UseSwaggerUI();     // Serves the Swagger UI (web page)
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
