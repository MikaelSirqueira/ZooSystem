namespace ZooSystem.Communication.Requests;

public class RequestFilterAnimalJson
{
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public DateTime? DataNascimento { get; set; }
    public string? Especie { get; set; }
    public string? Habitat { get; set; }
    public string? PaisOrigem { get; set; }
    public int PageNumber { get; set; } = 1;
}
