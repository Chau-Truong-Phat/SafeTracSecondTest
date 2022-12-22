using MediatR;
using MedWorking.Core.Application.ApprovalGeneralDocumentProcess.Models;

namespace MedWorking.Core.Application.ApprovalGeneralDocumentProcess.Queries;

public class GetApprovalGeneralDocumentProcessUnitByIdQuery : IRequest<ApprovalGeneralDocumentProcessUnitModel>
{
    public Guid Id { get; set; }
}
