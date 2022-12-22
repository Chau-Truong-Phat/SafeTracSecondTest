using MediatR;
using MedWorking.Core.EntityFramework.Models;

namespace MedWorking.Core.Application.ModulUserRole.Queries;

public class GetAllPositionQuery: IRequest<List<Position>>
{
}
