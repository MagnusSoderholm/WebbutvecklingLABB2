using Microsoft.EntityFrameworkCore;
using WebbutvecklingLABB2.Models;

namespace WebbutvecklingLABB2.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
}