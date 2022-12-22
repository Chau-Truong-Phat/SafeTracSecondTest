using MediatR;
using MedWorking.Core.Application.ModuleDecentralizeDocument.Models;

namespace MedWorking.Core.Application.ModuleDecentralizeDocument.Commands;

public class DecentralizeDocumentCommand : DecentralizeDocumentModel, IRequest<DecentralizeDocumentCommandResponse>
{
}
