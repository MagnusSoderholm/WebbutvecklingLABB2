using Microsoft.EntityFrameworkCore;
using WebbutvecklingLABB2.Data;
using WebbutvecklingLABB2.Repositories;
using WebbutvecklingLABB2.Models;

var builder = WebApplication.CreateBuilder(args);

// F�r backend - SQL Server och EF Core
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// F�r att registrera repositories
builder.Services.AddScoped<IRepository<Product>, ProductRepository>();
builder.Services.AddScoped<IRepository<Customer>, CustomerRepository>();

// F�r API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// L�gg till HttpClient f�r Blazor WebAssembly-klienten
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiBaseUrl")) });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
