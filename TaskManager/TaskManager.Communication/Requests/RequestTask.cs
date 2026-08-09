using TaskManager.Communication.Enum;

namespace TaskManager.Communication.Requests;

public class RequestTask
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TaskPriorityType Priority { get; set; }
    public DateTime DueDate { get; set; }
    public TaskStatusType Status { get; set; }
}
