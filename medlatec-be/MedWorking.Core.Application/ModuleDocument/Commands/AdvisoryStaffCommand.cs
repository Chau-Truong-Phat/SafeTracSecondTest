using MediatR;
using MedWorking.Core.Application.ModuleDocument.Models;

namespace MedWorking.Core.Application.ModuleDocument.Commands;

public class AdvisoryStaffCommand : AdvisoryStaffModel, IRequest<AdvisoryStaffCommandResponse>
{
}
