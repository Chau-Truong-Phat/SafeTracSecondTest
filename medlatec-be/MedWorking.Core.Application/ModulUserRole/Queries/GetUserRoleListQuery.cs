using MediatR;
using MedWorking.Core.Common.UnitOfWork.Collections;
using MedWorking.Core.EntityFramework.Models;

namespace MedWorking.Core.Application.ModulUserRole.Queries;

public class GetUserRoleListQuery : PagingQuery, IRequest<IPagedList<ViewGetDetailUserRole>>
{
    public List<long>? ListDepartment { get; set; } 
    public List<long>? ListPosition { get; set; }
    public List<string>? ListRole { get; set; }
}
