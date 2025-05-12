namespace ZooSystem.Communication.Responses;

public class ResponseAnimalsJson
{
    public ResponsePaginationJson Pagination { get; set; } = default!;
    public List<ResponseAnimalJson> Animals { get; set; } = [];
}
