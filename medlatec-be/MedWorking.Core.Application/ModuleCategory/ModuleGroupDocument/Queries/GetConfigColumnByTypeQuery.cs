using MediatR;
using MedWorking.Core.Application.ModuleCategory.ModuleGroupDocument.Models;

namespace MedWorking.Core.Application.ModuleCategory.ModuleGroupDocument.Queries;

public class GetConfigColumnByTypeQuery : IRequest<ConfigColumnModel>
{
    public int ViewType { get; set; }
}
