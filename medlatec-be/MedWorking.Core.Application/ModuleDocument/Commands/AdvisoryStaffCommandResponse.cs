using FluentValidation.Results;
using MedWorking.Core.Application.ModuleDocument.Models;
using MedWorking.Core.Common.Response;
using Newtonsoft.Json;

namespace MedWorking.Core.Application.ModuleDocument.Commands;
[JsonObject(Title = "AdvisoryStaffCommandResponse")]
public class AdvisoryStaffCommandResponse : BaseResponse
{
    public AdvisoryStaffCommandResponse()
        : base() { }

    public AdvisoryStaffCommandResponse(IList<ValidationFailure> failures)
        : base(failures) { }

    public AdvisoryStaffModel Result { get; set; }
}
