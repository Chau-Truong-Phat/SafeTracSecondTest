using MediatR;

namespace MedWorking.Core.Application.ModuleDecentralizeDocument.Commands.ActionCommands;

public class DeleteDecentralizeDocumentRequestCommand : IRequest<DecentralizeDocumentCommandResponse>
{
    public Guid Id { get; set; }
}
