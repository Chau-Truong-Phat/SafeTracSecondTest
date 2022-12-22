using MediatR;
using MedWorking.Core.Common.UnitOfWork.Collections;
using MedWorking.Core.EntityFramework.Models;

namespace MedWorking.Core.Application.ModulePatternDocument.Queries;

public class GetAllListPatternDocQuery : PagingQuery, IRequest<IPagedList<ViewSampleDocument>>
{
    public List<int>? ListDocType { get; set; }
    public List<string>? ListGroupDocumentId { get; set; }
}
