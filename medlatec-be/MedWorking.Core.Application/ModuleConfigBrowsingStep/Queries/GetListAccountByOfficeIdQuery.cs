using MediatR;
using MedWorking.Core.Application.ModuleConfigBrowsingStep.Models;
using MedWorking.Core.EntityFramework.Models;

namespace MedWorking.Core.Application.ModuleConfigBrowsingStep.Queries;

public class GetListAccountByOfficeIdQuery : IRequest<List<AccountDetailByOfficeIdModel>>
{
    public List<long>? ListOfficeIds { get; set; }
}
