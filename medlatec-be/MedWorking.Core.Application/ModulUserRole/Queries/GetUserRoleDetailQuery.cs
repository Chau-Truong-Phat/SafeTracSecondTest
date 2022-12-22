using MediatR;
using MedWorking.Core.EntityFramework.Models;

namespace MedWorking.Core.Application.ModulUserRole.Queries
{
    public class GetUserRoleDetailQuery : IRequest<ViewGetDetailUserRole>
    {
        public Guid UserRoleId { get; set; }
    }
}
