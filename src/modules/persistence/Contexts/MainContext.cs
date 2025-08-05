using Kaleidocode.Gists.Modules.Persistence.Entities.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Kaleidocode.Gists.Modules.Persistence.Contexts;

public class MainContext(DbContextOptions<MainContext> options, IConfiguration configuration) : DbContext(options)
{
    private readonly IConfiguration _configuration = configuration;

    public DbSet<BaseItemLookupEntity<Guid>> Lookups { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Default")!);
    }
}
