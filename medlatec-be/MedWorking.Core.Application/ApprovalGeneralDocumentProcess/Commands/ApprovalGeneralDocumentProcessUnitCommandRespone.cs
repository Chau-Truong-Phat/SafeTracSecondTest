using FluentValidation.Results;
using MedWorking.Core.Application.ApprovalGeneralDocumentProcess.Models;
using MedWorking.Core.Common.Response;
using Newtonsoft.Json;

namespace MedWorking.Core.Application.ApprovalGeneralDocumentProcess.Commands;
[JsonObject(Title = "ApprovalGeneralDocumentProcessUnitCommandRespone")]
public class ApprovalGeneralDocumentProcessUnitCommandRespone : BaseResponse
{
    public ApprovalGeneralDocumentProcessUnitCommandRespone()
        : base() { }

    public ApprovalGeneralDocumentProcessUnitCommandRespone(IList<ValidationFailure> failures)
        : base(failures) { }

    public ApprovalGeneralDocumentProcessUnitModel Result { get; set; }
}
