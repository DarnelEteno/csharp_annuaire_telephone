using AnnuaireTelephone.Models;
using Microsoft.EntityFrameworkCore;

namespace AnnuaireTelephone.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Telephone> Telephones { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>()
            .HasIndex(c => c.Matricule)
            .IsUnique();

        base.OnModelCreating(modelBuilder);
    }
}