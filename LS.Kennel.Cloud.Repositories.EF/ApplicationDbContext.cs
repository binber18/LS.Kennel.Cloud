using LS.Kennel.Cloud.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LS.Kennel.Cloud.Repositories.EF;

public class ApplicationDbContext : IdentityDbContext<AppUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Models.Kennel> Kennels => Set<Models.Kennel>();
    public DbSet<KennelOwnership> KennelOwnerships => Set<KennelOwnership>();
    public DbSet<Dog> Dogs => Set<Dog>();
    public DbSet<Heat> Heats => Set<Heat>();
    public DbSet<ProgesteroneTest> ProgesteroneTests => Set<ProgesteroneTest>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Dog>()
               .HasOne(d => d.Heat)
               .WithMany(h => h.Puppies);

        base.OnModelCreating(builder);
    }
}