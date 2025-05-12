namespace ZooSystem.Communication.Responses;

public class ResponseAnimalCare
{
    public Guid AnimalId { get; set; }
    public string? AnimalNome { get; set; }
    public string? DescricaoAnimal { get; set; }
    public string? Especie { get; set; }
    public Guid CuidadoId { get; set; }
    public string? CuidadoNome { get; set; }
    public string? DescricaoCuidado { get; set; }
    public string Frequencia { get; set; } = string.Empty;
}
