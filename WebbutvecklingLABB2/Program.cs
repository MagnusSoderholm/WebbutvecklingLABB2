using Microsoft.EntityFrameworkCore;
using WebbutvecklingLABB2.Data;
using WebbutvecklingLABB2.Repositories;
using WebbutvecklingLABB2.Models;

var builder = WebApplication.CreateBuilder(args);

// L�gg till DbContext och konfiguration f�r SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrera repositories i DI container
builder.Services.AddScoped<IRepository<Product>, ProductRepository>();
builder.Services.AddScoped<IRepository<Customer>, CustomerRepository>();

// L�gg till st�d f�r API (controllers)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Anv�nd swagger i utvecklingsl�ge
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
