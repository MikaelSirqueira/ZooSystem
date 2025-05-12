using ZooSystem.Infrastructure.DataAcess;

namespace ZooSystem.UseCases.Cares.Delete;

public class DeleteCareUseCase
{
    private readonly ZooSystemDbContext _repository;
    public DeleteCareUseCase(ZooSystemDbContext repository)
    {
        _repository = repository;
    }

    public void Execute(Guid id)
    {
        var care = _repository.Cuidados.FirstOrDefault(a => a.Id == id);

        if (care == null)
        {
            throw new Exception("Cuidado não encontrado.");
        }

        _repository.Cuidados.Remove(care);
        _repository.SaveChanges();
    }
}
