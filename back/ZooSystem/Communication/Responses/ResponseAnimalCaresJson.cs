namespace ZooSystem.Communication.Responses;

public class ResponseAnimalCaresJson
{
    public ResponsePaginationJson Pagination { get; set; } = default!;
    public List<ResponseAnimalCaresJson> AnimalCares { get; set; } = [];
}
