using System.ComponentModel.DataAnnotations;

namespace ZooSystem.Domain.Entities;

public class Animal
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public DateTime DataNascimento { get; set; }
    public string Especie { get; set; } = string.Empty;
    public string Habitat { get; set; } = string.Empty;
    public string PaisOrigem { get; set; } = string.Empty;
    public ICollection<AnimalCuidado> AnimaisCuidados { get; set; } = new List<AnimalCuidado>();
}
