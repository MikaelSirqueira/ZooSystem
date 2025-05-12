using Microsoft.AspNetCore.Mvc;
using ZooSystem.Communication.Requests;
using ZooSystem.Communication.Responses;
using ZooSystem.UseCases.Cares.Delete;
using ZooSystem.UseCases.Cares.Get;
using ZooSystem.UseCases.Cares.Register;
using ZooSystem.UseCases.Cares.Update;

namespace ZooSystem.Controllers;

[Route("[controller]")]
[ApiController]
public class CareController : ControllerBase
{
    private readonly RegisterCareUseCase _registerCareUseCase;
    private readonly GetCaresUseCase _getCaresUseCase;
    private readonly UpdateCareUseCase _updateCareUseCase;
    private readonly DeleteCareUseCase _deleteCareUseCase;

    public CareController(RegisterCareUseCase registerCareUseCase, GetCaresUseCase getAllCaresUseCase, UpdateCareUseCase updateCareUseCase, DeleteCareUseCase deleteCareUseCase)
    {
        _registerCareUseCase = registerCareUseCase;
        _getCaresUseCase = getAllCaresUseCase;
        _updateCareUseCase = updateCareUseCase;
        _deleteCareUseCase = deleteCareUseCase;
    }

    [HttpPost]
    public IActionResult CadastrarCuidado([FromBody] RequestCareJson request)
    {
        var response = _registerCareUseCase.Execute(request);
        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseCaresJson), StatusCodes.Status200OK)]
    public IActionResult ListarCuidados([FromQuery] RequestFilterCareJson request)
    {
        var response = _getCaresUseCase.Execute(request);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult AtualizarCuidado([FromBody] RequestUpdateCareJson request)
    {
        _updateCareUseCase.Execute(request);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult DeletarCuidado([FromRoute] Guid id)
    {
        _deleteCareUseCase.Execute(id);
        return NoContent();
    }
}