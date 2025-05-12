using Microsoft.AspNetCore.Mvc;
using System;
using ZooSystem.Communication.Requests;
using ZooSystem.Communication.Responses;
using ZooSystem.UseCases.Animals.Delete;
using ZooSystem.UseCases.Animals.Get;
using ZooSystem.UseCases.Animals.Register;
using ZooSystem.UseCases.Animals.Update;

namespace ZooSystem.Controllers;

[Route("[controller]")]
[ApiController]
public class AnimalController : ControllerBase
{
    private readonly RegisterAnimalUseCase _registerAnimalUseCase;
    private readonly GetAnimalsUseCase _getAnimalsUseCase;
    private readonly UpdateAnimalUseCase _updateAnimalUseCase;
    private readonly DeleteAnimalUseCase _deleteAnimalUseCase;

    public AnimalController(
        RegisterAnimalUseCase registerAnimalUseCase,
        GetAnimalsUseCase getAnimalsUseCase,
        UpdateAnimalUseCase updateAnimalUseCase,
        DeleteAnimalUseCase deleteAnimalUseCase)
    {
        _registerAnimalUseCase = registerAnimalUseCase;
        _getAnimalsUseCase = getAnimalsUseCase;
        _updateAnimalUseCase = updateAnimalUseCase;
        _deleteAnimalUseCase = deleteAnimalUseCase;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredAnimalJson), StatusCodes.Status201Created)]
    public ActionResult<ResponseRegisteredAnimalJson> CadastrarAnimal([FromBody] RequestAnimalJson request)
    {
        var response = _registerAnimalUseCase.Execute(request);
        return Ok(response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseAnimalsJson), StatusCodes.Status200OK)]
    public ActionResult<ResponseAnimalsJson> ListarAnimais([FromQuery] RequestFilterAnimalJson request)
    {
        var response = _getAnimalsUseCase.Execute(request);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult AtualizarAnimal([FromBody] RequestUpdateAnimalJson request)
    {
        _updateAnimalUseCase.Execute(request);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult DeletarAnimal([FromRoute] Guid id)
    {
        _deleteAnimalUseCase.Execute(id);
        return NoContent();
    }
}
