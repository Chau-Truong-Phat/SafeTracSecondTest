using FluentValidation.Results;
using MedWorking.Core.Application.ModuleDecentralizeDocument.Models;
using MedWorking.Core.Common.Response;
using Newtonsoft.Json;

namespace MedWorking.Core.Application.ModuleDecentralizeDocument.Commands;

[JsonObject(Title = "PatternDocumentCommandResponse")]
public class DecentralizeDocumentCommandResponse : BaseResponse
{
    public DecentralizeDocumentCommandResponse()
        : base(){}

    public DecentralizeDocumentCommandResponse(IList<ValidationFailure> failures)
        : base(failures){}

    public DecentralizeDocumentModel Result { get; set; }
}