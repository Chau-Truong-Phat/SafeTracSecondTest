
using FluentValidation.Results;
using MedWorking.Core.Application.ModuleLogin.Models;
using MedWorking.Core.Common.Response;
using Newtonsoft.Json;

namespace MedWorking.Core.Application.ModuleLogin.Commands;

[JsonObject(Title = "LoginResponse")]
public class LoginCommandResponse : BaseResponse
{

    public LoginCommandResponse()
    : base()
    {

    }

    public LoginCommandResponse(IList<ValidationFailure> failures)
        : base(failures)
    {

    }

    public AccountLoginModel Result { get; set; }

}