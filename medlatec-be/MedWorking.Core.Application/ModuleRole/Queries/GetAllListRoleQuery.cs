using MediatR;
using MedWorking.Core.Application.ModuleRole.Models;

namespace MedWorking.Core.Application.ModuleRole.Queries
{
    public class GetAllListRoleQuery : IRequest<List<ListDecentralizeModel>>
    {
    }
}
