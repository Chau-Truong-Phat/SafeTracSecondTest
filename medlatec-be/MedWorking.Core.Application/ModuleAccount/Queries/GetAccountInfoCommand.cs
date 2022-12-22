using MediatR;
using MedWorking.Core.Application.ModuleAccount.Models;

namespace MedWorking.Core.Application.ModuleAccount.Queries;

public class GetAccountInfoCommand : IRequest<ViewAccountDetailModel>
{
    public string UserName { get; set; } 
}
