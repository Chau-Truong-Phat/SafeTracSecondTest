using MediatR;
using MedWorking.Core.Common.UnitOfWork.Collections;
using MedWorking.Core.EntityFramework.Models;

namespace MedWorking.Core.Application.ModuleDecentralizeDocument.Queries;

public class GetAllListDecentralizeDocQuery : PagingQuery, IRequest<IPagedList<ViewDecentralizeDocument>>
{
}
