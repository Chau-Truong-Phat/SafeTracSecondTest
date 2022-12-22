using MediatR;
using MedWorking.Core.Common.UnitOfWork.Collections;
using MedWorking.Core.EntityFramework.Models;

namespace MedWorking.Core.Application.ModuleGroupDocument.Queries;

public class GetGroupDocumentListQuery : PagingQuery, IRequest<IPagedList<GroupDocument>>
{
    public List<int>? ListDocType { get; set; } 
}
