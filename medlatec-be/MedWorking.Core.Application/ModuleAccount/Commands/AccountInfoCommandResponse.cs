using FluentValidation.Results;
using MedWorking.Core.Application.ModuleAccount.Models;
using MedWorking.Core.Common.Response;
using Newtonsoft.Json;

namespace MedWorking.Core.Application.ModuleAccount.Commands;

[JsonObject(Title = "AccountInfoResponse")]

public class AccountInfoCommandResponse : BaseResponse
{
    public AccountInfoCommandResponse()
        : base()
    {

    }

    public AccountInfoCommandResponse(IList<ValidationFailure> failures)
    : base(failures)
    {

    }

    public AccountInfoModel Result { get; set; }
}
