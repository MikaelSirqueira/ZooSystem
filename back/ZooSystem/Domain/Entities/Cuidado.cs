using System.ComponentModel.DataAnnotations;

namespace ZooSystem.Domain.Entities;

public class Cuidado
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Nome { get; set; } = string.Empty;

    public string? Descricao { get; set; }

    public string Frequencia { get; set; } = string.Empty;

    // Propriedade de navegação
    public virtual ICollection<AnimalCuidado> AnimaisCuidados { get; set; } = new List<AnimalCuidado>();
}
