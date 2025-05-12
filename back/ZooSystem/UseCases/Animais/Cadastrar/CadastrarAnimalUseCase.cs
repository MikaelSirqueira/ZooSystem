using ZooSystem.Communication.Requests;
using ZooSystem.Communication.Responses;
using ZooSystem.Domain.Entities;
using ZooSystem.Infrastructure.DataAcess;

namespace ZooSystem.UseCases.Animais.Cadastrar;

public class CadastrarAnimalUseCase
{
    public ResponseAnimalCadastradoJson Execute(RequestAnimalJson request)
    {
        var repository = new ZooSystemDbContext();

        Validate(request, repository);

        var entity = new Animal
        {
            Nome = request.Nome,
            Descricao = request.Descricao,
            Especie = request.Especie,
            PaisOrigem = request.PaisOrigem,
            DataNascimento = request.DataNascimento,
            Habitat = request.Habitat
        };

        repository.Animais.Add(entity);
        repository.SaveChanges();

        return new ResponseAnimalCadastradoJson

        {
            Nome = entity.Nome,
            Especie = entity.Especie
        };
    }

    private void Validate(RequestAnimalJson request, ZooSystemDbContext repository)
    {
       

        var result = validator.Validate(request);

       
    }


}
