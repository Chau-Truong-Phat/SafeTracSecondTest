using MediatR;
using MedWorking.Core.Application.ModuleDecentralizeDocument.Models;
using MedWorking.Core.EntityFramework.Models;

namespace MedWorking.Core.Application.ModuleDecentralizeDocument.Queries;

public class GetUserByOfficeIdQuery : IRequest<List<UserDetailByOfficeIdModel>>
{
    public long OfficeId { get; set; }
}
