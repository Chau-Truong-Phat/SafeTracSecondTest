using MediatR;

namespace MedWorking.Core.Application.ModuleApprovalGeneralDocProcess.Commands.ActionCommands;

public class DeleteApprovalGeneralDocProcessRequestCommand : IRequest<ApprovalGeneralDocProcessCommandResponse>
{
    public Guid Id { get; set; }
}