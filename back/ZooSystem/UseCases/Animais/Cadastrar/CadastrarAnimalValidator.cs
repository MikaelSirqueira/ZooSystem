using FluentValidation;
using ZooSystem.Communication.Requests;

namespace ZooSystem.UseCases.Animais.Cadastrar;

public class CadastrarAnimalValidator : AbstractValidator<RequestAnimalJson>
{
    public CadastrarAnimalValidator()
    {
        RuleFor(animal => animal.Nome).NotEmpty();
        RuleFor(animal => animal.Descricao).NotEmpty();
        RuleFor(animal => animal.Habitat).NotEmpty();
        RuleFor(animal => animal.Especie).NotEmpty();
        RuleFor(animal => animal.DataNascimento).NotEmpty();
        RuleFor(animal => animal.PaisOrigem).NotEmpty();


        RuleFor(animal => animal.Habitat).EmailAddress();
        RuleFor(animal => animal.Password.Length).GreaterThanOrEqualTo(6);
    }
}

