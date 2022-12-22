using FluentValidation.Results;
using MedWorking.Core.Application.ModulePatternDocument.Models;
using MedWorking.Core.Common.Response;
using Newtonsoft.Json;

namespace MedWorking.Core.Application.ModulePatternDocument.Commands;

[JsonObject(Title = "PatternDocumentCommandResponse")]
public class PatternDocumentCommandResponse : BaseResponse
{
    public PatternDocumentCommandResponse()
        : base(){}

    public PatternDocumentCommandResponse(IList<ValidationFailure> failures)
        : base(failures){}

    public PatternDocumentModel Result { get; set; }
}