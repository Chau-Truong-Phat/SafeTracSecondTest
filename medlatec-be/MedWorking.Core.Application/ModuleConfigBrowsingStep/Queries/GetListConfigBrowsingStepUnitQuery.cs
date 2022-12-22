using MediatR;
using MedWorking.Core.Application.ModuleConfigBrowsingStep.Models;

namespace MedWorking.Core.Application.ModuleConfigBrowsingStep.Queries;

public class GetListConfigBrowsingStepUnitQuery : IRequest<List<ConfigBrowsingStepModel>>
{
    public long? OfficeId { get; set; }
}

