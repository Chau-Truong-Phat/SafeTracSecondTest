using MediatR;
using MedWorking.Core.Application.ModulePatternDocument.Models;

namespace MedWorking.Core.Application.ApprovalGeneralDocumentProcess.Queries;

public class GetPatternDocumentByListGroupDocumentIdQuery : IRequest<List<PatternDocumentModel>>
{
    public List<string>? ListGroupDocumentId { get; set; }
}
