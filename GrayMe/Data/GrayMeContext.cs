using Microsoft.EntityFrameworkCore;
using GrayMe.Models;

namespace GrayMe.Data
{
    public class GrayMeContext : DbContext
    {
        public GrayMeContext(DbContextOptions<GrayMeContext> options) : base(options)
        {
        }

        public DbSet<Crianca> Criancas { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Crianca>(entity =>
            {
                entity.ToTable("criancas");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Observacoes).HasMaxLength(1000);

                entity.Property(e => e.Sexo)
                    .HasConversion<string>()
                    .HasMaxLength(20)
                    .IsRequired();
            });
        }
    }
}