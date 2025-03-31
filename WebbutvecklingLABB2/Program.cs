//using Microsoft.EntityFrameworkCore;
//using WebbutvecklingLABB2.Data;
//using WebbutvecklingLABB2.Repositories;
//using WebbutvecklingLABB2.Models;

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddScoped<IRepository<Product>, ProductRepository>();
//builder.Services.AddScoped<IRepository<Customer>, CustomerRepository>();
//builder.Services.AddScoped<IRepository<Order>, OrderRepository>();

//builder.Services.AddControllers();

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();


//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}


//app.UseHttpsRedirection();

//app.MapControllers();

//app.Run();


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Lägg till CORS om det behövs
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();

app.UseHttpsRedirection();

// Lägg till CORS
app.UseCors("AllowAll");

app.UseAuthorization();

// Viktigt! Gör så att API-kontrollers fungerar
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();


