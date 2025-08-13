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
        public DbSet<Tutor> Tutores { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Crianca>()
                .Property(c => c.Sexo)
                .HasConversion<string>()
                .HasMaxLength(20)
                .IsRequired();

            modelBuilder.Entity<Crianca>(entity =>
            {
                entity.ToTable("criancas");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Nome).HasMaxLength(100).IsRequired();
                entity.Property(c => c.Observacoes).HasMaxLength(1000);
            });

            modelBuilder.Entity<Tutor>(entity =>
            {
                entity.ToTable("tutores");
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Nome).HasMaxLength(100).IsRequired();
                entity.Property(t => t.Profissao).HasMaxLength(100);
                entity.Property(t => t.Observacao).HasMaxLength(1000);
                entity.Property(t => t.Instituicao).HasMaxLength(100);
                entity.Property(t => t.Email).HasMaxLength(100);
                entity.Property(t => t.Usuario).HasMaxLength(50);
                entity.Property(t => t.Senha).HasMaxLength(100);
                entity.Property(t => t.FotoBase64).HasColumnType("text");
                entity.Property(t => t.Telefone).HasMaxLength(20);
            });

            modelBuilder.Entity<Crianca>()
                .HasMany(c => c.Tutores)
                .WithMany(t => t.Criancas)
                .UsingEntity<Dictionary<string, object>>(
                    "CriancaTutor",
                    j => j.HasOne<Tutor>().WithMany().HasForeignKey("TutorId").HasConstraintName("FK_CriancaTutor_TutorId").OnDelete(DeleteBehavior.Cascade),
                    j => j.HasOne<Crianca>().WithMany().HasForeignKey("CriancaId").HasConstraintName("FK_CriancaTutor_CriancaId").OnDelete(DeleteBehavior.Cascade),
                    j =>
                    {
                        j.HasKey("CriancaId", "TutorId");
                        j.ToTable("crianca_tutor");
                    });
        }

    }
}