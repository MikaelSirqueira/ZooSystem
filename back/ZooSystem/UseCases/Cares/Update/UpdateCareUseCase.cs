using ZooSystem.Communication.Requests;
using ZooSystem.Infrastructure.DataAcess;

namespace ZooSystem.UseCases.Cares.Update;

public class UpdateCareUseCase
{
    private readonly ZooSystemDbContext _repository;
    public UpdateCareUseCase(ZooSystemDbContext repository)
    {
        _repository = repository;
    }

    public void Execute(RequestUpdateCareJson request)
    {
        var care = _repository.Cuidados.FirstOrDefault(a => a.Id == request.Id);

        if (care == null)
        {
            throw new Exception("Animal não encontrado.");
        }

        if (!string.IsNullOrWhiteSpace(request.Nome))
            care.Nome = request.Nome;

        if (!string.IsNullOrWhiteSpace(request.Descricao))
            care.Descricao = request.Descricao;
        
        if (!string.IsNullOrWhiteSpace(request.Frequencia))
            care.Frequencia = request.Frequencia;        

        _repository.SaveChanges();
    }
}
