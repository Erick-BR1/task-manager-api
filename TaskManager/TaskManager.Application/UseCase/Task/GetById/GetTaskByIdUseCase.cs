using TaskManager.Communication.Response;

namespace TaskManager.Application.UseCase.Task.GetById;

public class GetTaskByIdUseCase
{
    public ResponseTask Execute(Guid Id)
    {
        return new ResponseTask
        {
            Id = Id,
            Name = "Teste 01",
            DueDate = DateTime.Now.AddDays(3),
            Priority = Communication.Enum.TaskPriorityType.Medium,
            Status = Communication.Enum.TaskStatusType.Pending,
        };
    }
}
