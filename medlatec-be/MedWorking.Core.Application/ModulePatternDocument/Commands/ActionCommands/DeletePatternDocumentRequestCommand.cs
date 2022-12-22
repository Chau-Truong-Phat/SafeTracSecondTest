using MediatR;

namespace MedWorking.Core.Application.ModulePatternDocument.Commands.ActionCommands;

public class DeletePatternDocumentRequestCommand : IRequest<PatternDocumentCommandResponse>
{
    public Guid PatternDocId { get; set; }
}
