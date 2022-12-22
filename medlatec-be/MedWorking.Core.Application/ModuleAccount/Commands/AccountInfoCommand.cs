using MediatR;
using MedWorking.Core.Application.ModuleAccount.Models;

namespace MedWorking.Core.Application.ModuleAccount.Commands;

public class AccountInfoCommand : AccountInfoModel, IRequest<AccountInfoCommandResponse>
{
}
