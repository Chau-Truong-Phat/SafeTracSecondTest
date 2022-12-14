using MediatR;
using MedWorking.Core.Application.ModuleRole.Models;

namespace MedWorking.Core.Application.ModuleRole.Queries
{
    public class GetRoleByIdQuery : IRequest<ViewDetailRole>
    {
        public Guid RoleId { get; set; }
    }
}
