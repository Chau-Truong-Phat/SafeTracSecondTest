using FluentValidation.Results;
using MedWorking.Core.Application.ModulUserRole.Models;
using MedWorking.Core.Common.Response;
using Newtonsoft.Json;

namespace MedWorking.Core.Application.ModulUserRole.Commands;

[JsonObject(Title = "UserRoleCommandResponse")]
public class UserRoleCommandResponse : BaseResponse
{
    public UserRoleCommandResponse()
        : base()
    {

    }

    public UserRoleCommandResponse(IList<ValidationFailure> failures)
    : base(failures)
    {

    }

    public UserRoleModel Result { get; set; } 
}
