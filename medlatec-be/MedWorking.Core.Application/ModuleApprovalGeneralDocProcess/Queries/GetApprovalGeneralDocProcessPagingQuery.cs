using MediatR;
using MedWorking.Core.Common.UnitOfWork.Collections;
using MedWorking.Core.EntityFramework.Models;

namespace MedWorking.Core.Application.ModuleApprovalGeneralDocProcess.Queries;

public class GetApprovalGeneralDocProcessPagingQuery : PagingQuery, IRequest<IPagedList<ViewApprovalGeneralDocumentProcess>>
{
    public List<string>? ListGroupDocumentId { get; set; }
    public List<string>? ListPatternDocumentId { get; set; }
}
