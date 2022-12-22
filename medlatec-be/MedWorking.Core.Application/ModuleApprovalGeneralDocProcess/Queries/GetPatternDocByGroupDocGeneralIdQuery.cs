using MediatR;
using MedWorking.Core.Application.ModulePatternDocument.Models;

namespace MedWorking.Core.Application.ModuleApprovalGeneralDocProcess.Queries
{
    public class GetPatternDocByGroupDocGeneralIdQuery : IRequest<List<PatternDocumentModel>>
    {
        public Guid GroupDocumentId { get; set; }
    }
}
