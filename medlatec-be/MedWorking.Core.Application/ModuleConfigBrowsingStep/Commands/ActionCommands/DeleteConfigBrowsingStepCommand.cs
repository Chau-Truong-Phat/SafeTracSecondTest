using MediatR;

namespace MedWorking.Core.Application.ModuleConfigBrowsingStep.Commands.ActionCommands;

public class DeleteConfigBrowsingStepCommand : IRequest<ConfigBrowsingStepCommandResponse>
{
    public Guid Id { get; set; }
}
