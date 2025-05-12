using FluentValidation;
using ZooSystem.Communication.Requests;

namespace ZooSystem.UseCases.Cares.Register;

public class RegisterCareValidator : AbstractValidator<RequestCareJson>
{
    public RegisterCareValidator()
    {
        RuleFor(cuidado => cuidado.Nome)
            .NotEmpty()
            .WithMessage("O nome do 'Cuidado' é obrigatório.");


        RuleFor(cuidado => cuidado.Frequencia)
           .NotEmpty()
           .WithMessage("A descrição do 'cuidado' é obrigatória.");
    }
}
