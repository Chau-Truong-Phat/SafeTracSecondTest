using FluentValidation.Results;
using MedWorking.Core.Application.ModuleConfigBrowsingStep.Models;
using MedWorking.Core.Common.Response;
using Newtonsoft.Json;

namespace MedWorking.Core.Application.ModuleConfigBrowsingStep.Commands;
[JsonObject(Title = "ConfigBrowsingStepCommandResponse")]
public class ConfigBrowsingStepCommandResponse : BaseResponse
{
    public ConfigBrowsingStepCommandResponse()
        : base() { }

    public ConfigBrowsingStepCommandResponse(IList<ValidationFailure> failures)
        : base(failures) { }

    public ConfigBrowsingStepModel Result { get; set; }
}
