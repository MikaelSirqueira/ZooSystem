using FluentValidation.Results;
using ZooSystem.Communication.Requests;
using ZooSystem.Communication.Responses;
using ZooSystem.Domain.Entities;
using ZooSystem.Exceptions;
using ZooSystem.Infrastructure.DataAcess;
using ZooSystem.UseCases.Animals.Register;

public class RegisterAnimalUseCase
{
    private readonly ZooSystemDbContext _repository;

    public RegisterAnimalUseCase(ZooSystemDbContext repository)
    {
        _repository = repository;
    }

    public ResponseAnimalJson Execute(RequestAnimalJson request)
    {
        Validate(request);

        var entity = new Animal
        {
            Nome = request.Nome,
            Descricao = request.Descricao,
            DataNascimento = request.DataNascimento,
            Especie = request.Especie,
            Habitat = request.Habitat,
            PaisOrigem = request.PaisOrigem
        };

        _repository.Animais.Add(entity);
        _repository.SaveChanges();

        return new ResponseAnimalJson
        {
            Nome = entity.Nome,
            Descricao = entity.Descricao,
        };
    }

    private void Validate(RequestAnimalJson request)
    {
        var validator = new RegisterCareValidator();
        var result = validator.Validate(request);

        var existAnimalWithSameName = _repository.Animais.Any(animal => animal.Nome.Equals(request.Nome));
        if (existAnimalWithSameName)
        {
            result.Errors.Add(new ValidationFailure("Name", "Esse nome já está cadastrado."));
        }

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
