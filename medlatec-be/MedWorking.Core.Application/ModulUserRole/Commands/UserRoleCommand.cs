using MediatR;
using MedWorking.Core.Application.ModulUserRole.Models;

namespace MedWorking.Core.Application.ModulUserRole.Commands;

public class UserRoleCommand : UserRoleModel, IRequest<UserRoleCommandResponse> { }

