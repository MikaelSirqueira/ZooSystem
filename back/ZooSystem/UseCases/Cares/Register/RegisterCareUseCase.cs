using ZooSystem.Communication.Requests;
using ZooSystem.Communication.Responses;
using ZooSystem.Domain.Entities;
using ZooSystem.Exceptions;
using ZooSystem.Infrastructure.DataAcess;

namespace ZooSystem.UseCases.Cares.Register;

public class RegisterCareUseCase
{
    private readonly ZooSystemDbContext _repository;
    public RegisterCareUseCase(ZooSystemDbContext context) => _repository = context;

    public ResponseCareJson Execute(RequestCareJson request)
    {
        Validate(request);

        var care = new Cuidado { Id = Guid.NewGuid(), Nome = request.Nome, Descricao = request.Descricao, Frequencia = request.Frequencia };
        _repository.Cuidados.Add(care);
        _repository.SaveChanges();

        return new ResponseCareJson { Nome = care.Nome, Descricao = care.Descricao, Frequencia = request.Frequencia };
    }

    private void Validate(RequestCareJson request)
    {
        var validator = new RegisterCareValidator();
        var result = validator.Validate(request);

        var existAnimalWithSameName = _repository.Animais.Any(animal => animal.Nome.Equals(request.Nome));
        if (existAnimalWithSameName)
        {
            result.Errors.Add(new FluentValidation.Results.ValidationFailure("Name", "Esse nome já está cadastrado."));
        }

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
