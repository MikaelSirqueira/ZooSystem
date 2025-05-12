namespace ZooSystem.Communication.Responses;

public class ResponseAnimalJson
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Especie { get; set; } = string.Empty;
    public string Habitat { get; set; } = string.Empty;
    public string PaisOrigem { get; set; } = string.Empty;
    public string DataNascimento { get; set; } = string.Empty;
}
