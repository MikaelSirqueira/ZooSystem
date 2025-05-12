using ZooSystem.Communication.Requests;
using ZooSystem.Infrastructure.DataAcess;

namespace ZooSystem.UseCases.Animals.Update;

public class UpdateAnimalUseCase
{
    private readonly ZooSystemDbContext _repository;
    public UpdateAnimalUseCase(ZooSystemDbContext repository)
    {
        _repository = repository;
    }

    public void Execute(RequestUpdateAnimalJson request)
    {
        var animal = _repository.Animais.FirstOrDefault(a => a.Id == request.Id);

        if (animal == null)
        {
            throw new Exception("Animal não encontrado.");
        }

        if (!string.IsNullOrWhiteSpace(request.Nome))
            animal.Nome = request.Nome;

        if (!string.IsNullOrWhiteSpace(request.Descricao))
            animal.Descricao = request.Descricao;

        if (request.DataNascimento.HasValue)
            animal.DataNascimento = request.DataNascimento.Value;

        if (!string.IsNullOrWhiteSpace(request.Especie))
            animal.Especie = request.Especie;

        if (!string.IsNullOrWhiteSpace(request.Habitat))
            animal.Habitat = request.Habitat;

        if (!string.IsNullOrWhiteSpace(request.PaisOrigem))
            animal.PaisOrigem = request.PaisOrigem;

        _repository.SaveChanges();
    }

}
