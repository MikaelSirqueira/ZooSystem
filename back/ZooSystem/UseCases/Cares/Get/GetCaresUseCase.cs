using ZooSystem.Communication.Requests;
using ZooSystem.Communication.Responses;
using ZooSystem.Domain.Entities;
using ZooSystem.Infrastructure.DataAcess;

namespace ZooSystem.UseCases.Cares.Get;

public class GetCaresUseCase
{
    private const int PAGE_SIZE = 10;
    private readonly ZooSystemDbContext _repository;
    public GetCaresUseCase(ZooSystemDbContext repository) => _repository = repository;

    public ResponseCaresJson Execute(RequestFilterCareJson request)
    {
        if (request.PageNumber <= 0)
        {
            request.PageNumber = 1;
        }

        var objCares = _repository.Cuidados.AsQueryable();

        objCares = ApplyFilters(objCares, request);

        var total = objCares.Count();

        var cares = objCares
            .OrderBy(care => care.Nome)
            .Skip(PAGE_SIZE * (request.PageNumber - 1))
            .Take(PAGE_SIZE)
            .ToList();

        return new ResponseCaresJson
        {
            Pagination = new ResponsePaginationJson
            {
                PageNumber = request.PageNumber,
                TotalCount = total
            },
            Cares = cares.Select(care => new ResponseCareJson
            {
                Id = care.Id,
                Nome = care.Nome,
                Descricao = string.IsNullOrWhiteSpace(care.Descricao) ? "" : care.Descricao,
                Frequencia = care.Frequencia
            }).ToList()
        };
    }

    private IQueryable<Cuidado> ApplyFilters(IQueryable<Cuidado> objCuidados, RequestFilterCareJson request)
    {
        return objCuidados
            .Where(care => string.IsNullOrWhiteSpace(request.Nome) || care.Nome.Contains(request.Nome))
            .Where(care => string.IsNullOrWhiteSpace(request.Descricao) || care.Descricao.Contains(request.Descricao))
            .Where(care => string.IsNullOrWhiteSpace(request.Frequencia) || care.Frequencia.Contains(request.Frequencia));
    }
}
