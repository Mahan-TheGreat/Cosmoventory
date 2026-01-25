using Microsoft.EntityFrameworkCore;

namespace Cosmoventory.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
}
