using MediatR;
using MedWorking.Core.Application.ModuleApprovalGeneralDocProcess.Models;

namespace MedWorking.Core.Application.ModuleApprovalGeneralDocProcess.Commands
{
    public class ApprovalGeneralDocProcessCommand : ApprovalGeneralDocumentProcessModel, IRequest<ApprovalGeneralDocProcessCommandResponse>
    {
    }
}
