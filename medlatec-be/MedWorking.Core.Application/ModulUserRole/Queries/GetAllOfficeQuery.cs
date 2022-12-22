using MediatR;
using MedWorking.Core.Application.ModulUserRole.Models;

namespace MedWorking.Core.Application.ModulUserRole.Queries;

public class GetAllOfficeQuery : IRequest<List<DepartmentModel>>
{
}
