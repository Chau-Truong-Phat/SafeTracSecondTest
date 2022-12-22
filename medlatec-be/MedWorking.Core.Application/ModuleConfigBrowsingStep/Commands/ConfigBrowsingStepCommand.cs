using MediatR;
using MedWorking.Core.Application.ModuleConfigBrowsingStep.Models;

namespace MedWorking.Core.Application.ModuleConfigBrowsingStep.Commands;

public class ConfigBrowsingStepCommand : ConfigBrowsingStepModel, IRequest<ConfigBrowsingStepCommandResponse>
{
}
