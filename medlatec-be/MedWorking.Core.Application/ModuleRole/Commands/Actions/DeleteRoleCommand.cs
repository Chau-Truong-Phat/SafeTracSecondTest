using MediatR;

namespace MedWorking.Core.Application.ModuleRole.Commands.ActionCommands;


public class DeleteRoleCommand :IRequest<RoleCommandResponse>
{
    public Guid Id { get; set; }
}
