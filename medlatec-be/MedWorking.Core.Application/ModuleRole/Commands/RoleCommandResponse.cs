using FluentValidation.Results;
using MedWorking.Core.Application.ModuleRole.Models;
using MedWorking.Core.Common.Response;
using Newtonsoft.Json;

namespace MedWorking.Core.Application.ModuleRole.Commands;

[JsonObject(Title = "RoleResponse")]
public class RoleCommandResponse : BaseResponse
{
    public RoleCommandResponse()
    : base()
    {

    }

    public RoleCommandResponse(IList<ValidationFailure> failures)
        : base(failures)
    {

    }

    public RoleModel Result { get; set; }

}
