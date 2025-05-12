using Microsoft.EntityFrameworkCore;
using ZooSystem.Infrastructure.DataAcess;

namespace ZooSystem.UseCases.Animals.Delete;

public class DeleteAnimalUseCase
{
    private readonly ZooSystemDbContext _context;
    public DeleteAnimalUseCase(ZooSystemDbContext context)
    {
        _context = context;
    }

    public void Execute(Guid id)
    {
        var animal = _context.Animais.FirstOrDefault(a => a.Id == id);

        if (animal == null)
        {
            throw new Exception("Animal não encontrado.");
        }

        _context.Animais.Remove(animal);
        _context.SaveChanges();
    }

}
