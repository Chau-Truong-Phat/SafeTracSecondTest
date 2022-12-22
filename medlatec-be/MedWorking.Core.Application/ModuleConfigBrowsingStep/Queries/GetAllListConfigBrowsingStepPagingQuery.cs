using MediatR;
using MedWorking.Core.Common.UnitOfWork.Collections;
using MedWorking.Core.EntityFramework.Models;

namespace MedWorking.Core.Application.ModuleConfigBrowsingStep.Queries;

public class GetAllListConfigBrowsingStepPagingQuery : PagingQuery, IRequest<IPagedList<ViewConfigureBrowsingStep>>
{
    public int ScopeApplication { get; set; }
    public List<string>? ListOfficeId { get; set; }
}
