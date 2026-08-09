using TaskManager.Communication.Response;

namespace TaskManager.Application.UseCase.Task.GetAll;

public class GetAllTasksUseCase
{
    public ResponseAllTask Execute()
    {
        return new ResponseAllTask
        {
            Tasks = new List<ResponseShortTask>
            {
                new ResponseShortTask
                {
                    Id = Guid.NewGuid(),
                    Name = "Enxugar gelo",
                    Priority = Communication.Enum.TaskPriorityType.high,
                    DueDate = DateTime.Now.AddDays(1),
                    Status = Communication.Enum.TaskStatusType.pending,
                }
            }

        };
    }
}
