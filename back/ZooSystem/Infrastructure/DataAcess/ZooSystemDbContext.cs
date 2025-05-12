using Microsoft.EntityFrameworkCore;
using ZooSystem.Domain.Entities;

namespace ZooSystem.Infrastructure.DataAcess;

public class ZooSystemDbContext : DbContext
{
    public ZooSystemDbContext(DbContextOptions<ZooSystemDbContext> options) : base(options) { }

    public DbSet<Animal> Animais { get; set; }
    public DbSet<Cuidado> Cuidados { get; set; }
    public DbSet<AnimalCuidado> AnimaisCuidados { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AnimalCuidado>()
            .HasKey(ac => new { ac.AnimalId, ac.CuidadoId });

        modelBuilder.Entity<AnimalCuidado>()
            .HasOne(ac => ac.Animal)
            .WithMany(a => a.AnimaisCuidados)
            .HasForeignKey(ac => ac.AnimalId);

        modelBuilder.Entity<AnimalCuidado>()
            .HasOne(ac => ac.Cuidado)
            .WithMany(c => c.AnimaisCuidados)
            .HasForeignKey(ac => ac.CuidadoId);

        modelBuilder.Entity<Animal>()
            .Property(a => a.DataNascimento)
            .HasColumnType("date");

        modelBuilder.Entity<Animal>().HasData(
            new Animal
            {
                Id = Guid.NewGuid(),
                Nome = "Leão",
                Descricao = "Leão africano",
                DataNascimento = new DateTime(2015, 5, 12),
                Especie = "Panthera leo",
                Habitat = "Savana",
                PaisOrigem = "África do Sul"
            },
            new Animal
            {
                Id = Guid.NewGuid(),
                Nome = "Girafa",
                Descricao = "Girafa macho adulto",
                DataNascimento = new DateTime(2017, 9, 3),
                Especie = "Giraffa camelopardalis",
                Habitat = "Savana",
                PaisOrigem = "Quênia"
            }
        );

        modelBuilder.Entity<Cuidado>().HasData(
            new Cuidado
            {
                Id = Guid.NewGuid(),
                Nome = "Alimentação",
                Descricao = "Fornecimento de alimento",
                Frequencia = "Diária"
            },
            new Cuidado
            {
                Id = Guid.NewGuid(),
                Nome = "Vacinação",
                Descricao = "Aplicação de vacinas",
                Frequencia = "Anual"
            }
        );
    }
}
