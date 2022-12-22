using MediatR;
using MedWorking.Core.Common.UnitOfWork.Collections;
using MedWorking.Core.EntityFramework.Models;

namespace MedWorking.Core.Application.ApprovalGeneralDocumentProcess.Queries;

public class GetApprovalGeneralDocumentProcessUnitPagingQuery : PagingQuery, IRequest<IPagedList<ViewApprovalGeneralDocumentProcessUnit>>
{
   public List<long>? ListOfficeId { get; set; }
   public List<string>? ListGroupDocumentId { get; set; }
   public List<string>? ListPatternDocumentId { get; set; }
}
