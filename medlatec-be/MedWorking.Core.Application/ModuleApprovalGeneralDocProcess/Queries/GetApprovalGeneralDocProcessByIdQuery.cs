using MediatR;
using MedWorking.Core.Application.ModuleApprovalGeneralDocProcess.Models;

namespace MedWorking.Core.Application.ModuleApprovalGeneralDocProcess.Queries;

public class GetApprovalGeneralDocProcessByIdQuery : IRequest<ApprovalGeneralDocumentProcessModel>
{
    public Guid Id { get; set; }
}