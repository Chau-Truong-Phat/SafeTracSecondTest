using MediatR;
using MedWorking.Core.Application.ModulePatternDocument.Models;

namespace MedWorking.Core.Application.ModulePatternDocument.Commands;

public class PatternDocumentCommand : PatternDocumentModel, IRequest<PatternDocumentCommandResponse>
{
}
