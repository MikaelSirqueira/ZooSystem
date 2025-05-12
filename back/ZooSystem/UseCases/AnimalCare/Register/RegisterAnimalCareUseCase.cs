using System;
using ZooSystem.Communication.Requests;
using ZooSystem.Domain.Entities;
using ZooSystem.Infrastructure.DataAcess;

namespace ZooSystem.UseCases.AnimalCare.Register;

public class RegisterAnimalCareUseCase
{
    private readonly ZooSystemDbContext _context;
    public RegisterAnimalCareUseCase(ZooSystemDbContext context)
    {
        _context = context;
    }

    public async Task Execute(RequestAnimalCare request)
    {
        var objAnimal = _context.Animais.FirstOrDefault(ani => ani.Id == request.AnimalId);
        var objCare = _context.Cuidados.FirstOrDefault(care => care.Id == request.CuidadoId);

        if(objAnimal == null || objCare == null)
        {
            throw new Exception("Entidades não encontradas!");
        }

        var entity = new AnimalCuidado
        {
            AnimalId = request.AnimalId,
            Animal = objAnimal,
            CuidadoId = request.CuidadoId,
            Cuidado = objCare
        };

        _context.AnimaisCuidados.Add(entity);
        await _context.SaveChangesAsync();
    }
}
