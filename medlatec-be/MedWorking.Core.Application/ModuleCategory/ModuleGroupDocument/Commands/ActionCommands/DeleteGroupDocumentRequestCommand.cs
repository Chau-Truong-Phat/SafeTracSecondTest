using MediatR;

namespace MedWorking.Core.Application.ModuleGroupDocument.Commands.ActionCommands;

public class DeleteGroupDocumentRequestCommand : IRequest<GroupDocumentCommandResponse>
{
    public string? GroupDocId { get; set; }
}
