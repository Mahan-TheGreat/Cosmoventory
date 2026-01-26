using Cosmoventory.Models;
using Microsoft.EntityFrameworkCore;

namespace Cosmoventory.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
}
