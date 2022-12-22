using FluentValidation.Results;
using MedWorking.Core.Application.ModuleApprovation.Models;
using MedWorking.Core.Common.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedWorking.Core.Application.ModuleApprovation.Commands;
[JsonObject(Title = "DocumentCommandResponse")]
public class ApprovationCommandResponse : BaseResponse
{
    public ApprovationCommandResponse()
    : base() { }

    public ApprovationCommandResponse(IList<ValidationFailure> failures)
        : base(failures) { }

    public ApprovationModel Result { get; set; }
}