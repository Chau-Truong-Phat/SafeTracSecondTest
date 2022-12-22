using MediatR;
using MedWorking.Core.EntityFramework.Models;

namespace MedWorking.Core.Application.ModulUserRole.Queries;

public class GetEmployeeIdQuery:  IRequest<ViewInfoAccountDetail>
{
    public string EmployeeId { get; set; }  
}
