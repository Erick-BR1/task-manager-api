using System.ComponentModel.DataAnnotations;
using TaskManager.Communication.Enum;
using TaskManager.Communication.Requests;
using TaskManager.Communication.Response;

namespace TaskManager.Application.UseCase.Task.Register;

public class RegisterTaskUseCase
{
    public ResponseRegisterTask Execute(RequestTask request)
    {
        ValidateRequest(request);

        return new ResponseRegisterTask
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
        };
    }

    private void ValidateRequest(RequestTask request)
    {
        var nameIsEmpty = string.IsNullOrWhiteSpace(request.Name);
        if (nameIsEmpty)
            throw new ArgumentException("Name is required.");

        var nameLengthIsInvalid = request.Name.Trim().Length > 100;
        if (nameLengthIsInvalid)
            throw new ArgumentException("Name must be lower than 100 characters.");

        var descriptionLengthIsInvalid = !string.IsNullOrWhiteSpace(request.Description)
            && request.Description.Trim().Length > 500;
        if (descriptionLengthIsInvalid)
            throw new ArgumentException("Description must be lower than 500 characters.");

        if (request.DueDate.CompareTo(DateTime.UtcNow) < 0)
            throw new ValidationException("Data limite não pode ser no passado.");

        if (!Enum.IsDefined(typeof(TaskPriorityType), request.Priority))
            throw new ArgumentException("Prioridade inválida.");

        if (!Enum.IsDefined(typeof(TaskStatusType), request.Status))
            throw new ArgumentException("Status inválido.");
    }
}