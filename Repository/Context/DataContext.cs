using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Repository.Context
{
    [ExcludeFromCodeCoverage]
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<PrimeNumberEntity> PrimeNumber { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrimeNumberEntity>(
                entity =>
                {
                    entity.Property(e => e.Id)
                          .IsRequired();
                });
        }
    }
}
