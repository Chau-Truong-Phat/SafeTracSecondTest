using MediatR;
using MedWorking.Core.Application.ModuleGroupDocument.Commands;

namespace MedWorking.Core.Application.ModulUserRole.Commands.ActionCommands;

public class DeleteUserRoleRequestCommand : IRequest<UserRoleCommandResponse>
{
    public Guid UserId { get; set; }
}
