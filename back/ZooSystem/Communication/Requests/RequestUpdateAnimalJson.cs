namespace ZooSystem.Communication.Requests;

public class RequestUpdateAnimalJson
{
    public Guid Id { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public DateTime? DataNascimento { get; set; }
    public string? Especie { get; set; }
    public string? Habitat { get; set; }
    public string? PaisOrigem { get; set; }
}
