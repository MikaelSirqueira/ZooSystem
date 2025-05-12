using ZooSystem.Communication.Requests;
using ZooSystem.Communication.Responses;
using ZooSystem.Domain.Entities;
using ZooSystem.Infrastructure.DataAcess;

namespace ZooSystem.UseCases.Animals.Get;

public class GetAnimalsUseCase
{
    private const int PAGE_SIZE = 10;

    private readonly ZooSystemDbContext _repository;

    public GetAnimalsUseCase(ZooSystemDbContext repository)
    {
        _repository = repository;
    }

    public ResponseAnimalsJson Execute(RequestFilterAnimalJson request)
    {
        if (request.PageNumber <= 0)
        {
            request.PageNumber = 1;
        }

        var objAnimals = _repository.Animais.AsQueryable();

        objAnimals = ApplyFilters(objAnimals, request);

        var total = objAnimals.Count();

        var animals = objAnimals
            .OrderBy(animal => animal.Nome)
            .Skip(PAGE_SIZE * (request.PageNumber - 1))
            .Take(PAGE_SIZE)
            .ToList();

        return new ResponseAnimalsJson
        {
            Pagination = new ResponsePaginationJson
            {
                PageNumber = request.PageNumber,
                TotalCount = total
            },
            Animals = animals.Select(animal => new ResponseAnimalJson
            {
                Id = animal.Id,
                Nome = animal.Nome,
                Descricao = animal.Descricao,
                Habitat = animal.Habitat,
                Especie = animal.Especie,
                PaisOrigem = animal.PaisOrigem,
                DataNascimento = animal.DataNascimento.ToString("dd/MM/yyyy")
            }).ToList()
        };
    }

    private IQueryable<Animal> ApplyFilters(IQueryable<Animal> objAnimals, RequestFilterAnimalJson request)
    {
        return objAnimals
            .Where(animal => string.IsNullOrWhiteSpace(request.Nome) || animal.Nome.Contains(request.Nome))
            .Where(animal => string.IsNullOrWhiteSpace(request.Descricao) || animal.Descricao.Contains(request.Descricao))
            .Where(animal => string.IsNullOrWhiteSpace(request.Especie) || animal.Especie.Contains(request.Especie))
            .Where(animal => string.IsNullOrWhiteSpace(request.Habitat) || animal.Habitat.Contains(request.Habitat))
            .Where(animal => string.IsNullOrWhiteSpace(request.PaisOrigem) || animal.PaisOrigem.Contains(request.PaisOrigem))
            .Where(animal => request.DataNascimento == null || animal.DataNascimento.Equals(request.DataNascimento));
    }
}

