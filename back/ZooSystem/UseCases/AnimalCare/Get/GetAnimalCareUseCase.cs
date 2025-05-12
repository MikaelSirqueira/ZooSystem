using ZooSystem.Communication.Responses;
using ZooSystem.Infrastructure.DataAcess;

namespace ZooSystem.UseCases.AnimalCare.Get;

public class GetAnimalCareUseCase
{
    private readonly ZooSystemDbContext _context;

    public GetAnimalCareUseCase(ZooSystemDbContext context)
    {
        _context = context;
    }    
}
