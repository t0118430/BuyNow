using BuyNow.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BuyNow.Services.ProductAPI.DbContexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }

    public DbSet<Product> Products { get; set; }
}