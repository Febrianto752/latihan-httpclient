using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class TestDbContext : DbContext
{
    public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
    {

    }

    public DbSet<Product> Products { get; set; }
}


