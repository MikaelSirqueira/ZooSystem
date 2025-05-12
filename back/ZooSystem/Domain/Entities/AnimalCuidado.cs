using System;

namespace ZooSystem.Domain.Entities;

public class AnimalCuidado
{
    public Guid AnimalId { get; set; }
    public Animal Animal { get; set; } = null!;

    public Guid CuidadoId { get; set; }
    public Cuidado Cuidado { get; set; } = null!;
}
