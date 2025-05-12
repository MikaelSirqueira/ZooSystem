namespace ZooSystem.Communication.Requests;

public class RequestFilterCareJson
{
    public string? Nome { get; set; } = string.Empty;
    public string? Descricao { get; set; } = string.Empty;
    public string? Frequencia { get; set; } = string.Empty;
    public int PageNumber { get; set; } = 1;
}
