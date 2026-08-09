using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.UseCase.Task.Delete;
using TaskManager.Application.UseCase.Task.GetAll;
using TaskManager.Application.UseCase.Task.GetById;
using TaskManager.Application.UseCase.Task.Register;
using TaskManager.Application.UseCase.Task.Update;
using TaskManager.Communication.Requests;
using TaskManager.Communication.Response;

namespace TaskManager.API.Controllers;

[Route("api/tasks")]
[ApiController]
public class TaskController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisterTask), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrors), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestTask request)
    {
        var useCase = new RegisterTaskUseCase();
        var response = useCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseAllTask), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetAll()
    {
        var useCase = new GetAllTasksUseCase();
        var response = useCase.Execute();

        if (response.Tasks.Any()) return Ok(response);

        return NoContent();
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseTask), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrors), StatusCodes.Status404NotFound)]
    public IActionResult Get(Guid id)
    {
        var useCase = new GetTaskByIdUseCase();
        var response = useCase.Execute(id);

        return Ok(response);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrors), StatusCodes.Status400BadRequest)]
    public IActionResult Put(Guid id, [FromBody] RequestTask request)
    {
        var useCase = new UpdateTaskUseCase();
        useCase.Execute(id, request);

        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrors), StatusCodes.Status404NotFound)]
    public IActionResult Delete(Guid id)
    {
        var useCase = new DeleteTaskByIdUseCase();
        useCase.Execute(id);

        return NoContent();
    }
}
