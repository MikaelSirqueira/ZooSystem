using FluentValidation;
using ZooSystem.Communication.Requests;

namespace ZooSystem.UseCases.Animals.Register;

public class RegisterCareValidator : AbstractValidator<RequestAnimalJson>
{
    public RegisterCareValidator()
    {
        RuleFor(animal => animal.Nome)
            .NotEmpty()
            .WithMessage("O nome do animal é obrigatório.");

        RuleFor(animal => animal.Descricao)
           .NotEmpty()
           .WithMessage("A descrição do animal é obrigatória.");

        RuleFor(animal => animal.Habitat)
            .NotEmpty()
            .WithMessage("O habitat do animal é obrigatório.");

        RuleFor(animal => animal.Especie)
            .NotEmpty()
            .WithMessage("A espécie do animal é obrigatória.");

        RuleFor(animal => animal.DataNascimento)
            .NotEmpty()
            .WithMessage("A data de nascimento é obrigatória.")
            .LessThanOrEqualTo(DateTime.Today)
            .WithMessage("A data de nascimento não pode ser no futuro.");

        RuleFor(animal => animal.PaisOrigem)
            .NotEmpty()
            .WithMessage("O país de origem do animal é obrigatório.");
    }
}
