namespace ZooSystem.Communication.Responses;

public class ResponseCaresJson
{
    public ResponsePaginationJson Pagination { get; set; } = default!;
    public List<ResponseCareJson> Cares { get; set; } = [];
}
