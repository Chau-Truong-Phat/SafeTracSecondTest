using MediatR;
using MedWorking.Core.Application.ModuleLogin.Models;

namespace MedWorking.Core.Application.ModuleLogin.Commands;

public class LoginCommand : AccountRequest, IRequest<LoginCommandResponse>
{
}
