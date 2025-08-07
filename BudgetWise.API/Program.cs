using Microsoft.EntityFrameworkCore;
using BudgetWise.Infrastructure.Data;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi; // Add this using directive

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BudgetWise API", Version = "v1" }); // Use OpenApiInfo type explicitly
});
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BudgetWise API V1");
    c.RoutePrefix = ""; // Optional: makes Swagger the root page
});

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

// Ensure you have the following NuGet package installed in your project:
// Swashbuckle.AspNetCore
// You can install it using the following command in the Package Manager Console:
// Install-Package Swashbuckle.AspNetCore
app.UseAuthorization();

app.MapControllers();

app.Run();
