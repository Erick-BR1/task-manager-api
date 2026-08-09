using TaskManager.Communication.Requests;
using TaskManager.Communication.Response;

namespace TaskManager.Application.UseCase.Task.Register;

public class RegisterTaskUseCase
{
    public ResponseRegisterTask Execute(RequestTask request)
    {
        return new ResponseRegisterTask
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
        }
    }
}
