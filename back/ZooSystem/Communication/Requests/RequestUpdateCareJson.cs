namespace ZooSystem.Communication.Requests;

public class RequestUpdateCareJson
{
    public Guid Id { get; set; }
    public string? Nome { get; set; } = string.Empty;
    public string? Descricao { get; set; } = string.Empty;
    public string? Frequencia { get; set; } = string.Empty;
}
