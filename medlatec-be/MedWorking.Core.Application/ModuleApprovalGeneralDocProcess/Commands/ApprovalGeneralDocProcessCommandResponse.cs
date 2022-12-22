using FluentValidation.Results;
using MedWorking.Core.Application.ModuleApprovalGeneralDocProcess.Models;
using MedWorking.Core.Common.Response;
using Newtonsoft.Json;

namespace MedWorking.Core.Application.ModuleApprovalGeneralDocProcess.Commands;
[JsonObject(Title = "ApprovalGeneralDocProcessCommandResponse")]
public class ApprovalGeneralDocProcessCommandResponse : BaseResponse
{
    public ApprovalGeneralDocProcessCommandResponse() 
        : base() {}

    public ApprovalGeneralDocProcessCommandResponse(IList<ValidationFailure> failures)
        : base() {}

    public ApprovalGeneralDocumentProcessModel Result { get; set; }
}