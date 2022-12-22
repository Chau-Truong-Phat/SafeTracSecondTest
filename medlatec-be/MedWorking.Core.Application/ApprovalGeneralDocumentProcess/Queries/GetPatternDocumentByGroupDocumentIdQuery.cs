using MediatR;
using MedWorking.Core.Application.ModulePatternDocument.Models;

namespace MedWorking.Core.Application.ApprovalGeneralDocumentProcess.Queries;

public class GetPatternDocumentByGroupDocumentIdQuery :IRequest<List<PatternDocumentModel>>
{
    public Guid GroupDocumentId { get; set; }
}
