using MediatR;
using MedWorking.Core.Application.ModuleConfigBrowsingStep.Models;

namespace MedWorking.Core.Application.ModuleConfigBrowsingStep.Queries;

public class GetConfigBrowsingStepByIdQuery : IRequest<ConfigBrowsingStepModel>
{
    public Guid Id { get; set; }
}
