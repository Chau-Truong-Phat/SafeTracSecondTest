using MediatR;
using MedWorking.Core.Application.ModuleRole.Models;
using MedWorking.Core.EntityFramework.Models;

namespace MedWorking.Core.Application.ModuleRole.Queries;

public class GetRoleAllListQuery : IRequest<List<RoleModel>> 
{ 
}
