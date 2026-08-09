using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.UseCase.Task.GetAll;
using TaskManager.Application.UseCase.Task.Register;
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
        var respose = useCase.Execute();

        if(respose.Tasks.Any()) return Ok();

        return NoContent();
    }
}
