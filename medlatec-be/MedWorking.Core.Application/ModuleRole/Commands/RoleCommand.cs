using MediatR;
using MedWorking.Core.Application.ModuleRole.Models;

namespace MedWorking.Core.Application.ModuleRole.Commands;

public class RoleCommand : RoleModel, IRequest<RoleCommandResponse>
{
}
