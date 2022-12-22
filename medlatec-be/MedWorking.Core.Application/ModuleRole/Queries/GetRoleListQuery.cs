using MediatR;
using MedWorking.Core.Application.ModuleRole.Models;
using MedWorking.Core.Common.UnitOfWork.Collections;
using MedWorking.Core.EntityFramework.Models;

namespace MedWorking.Core.Application.ModuleRole.Queries
{
    public class GetRoleListQuery : PagingQuery, IRequest<IPagedList<Role>>
    {
    }
}
