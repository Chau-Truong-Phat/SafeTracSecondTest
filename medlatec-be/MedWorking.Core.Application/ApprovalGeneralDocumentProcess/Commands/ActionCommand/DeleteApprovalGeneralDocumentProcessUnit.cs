using MediatR;

namespace MedWorking.Core.Application.ApprovalGeneralDocumentProcess.Commands.ActionCommand;

public class DeleteApprovalGeneralDocumentProcessUnit : IRequest<ApprovalGeneralDocumentProcessUnitCommandRespone>
{
    public Guid Id { get; set; }
}
