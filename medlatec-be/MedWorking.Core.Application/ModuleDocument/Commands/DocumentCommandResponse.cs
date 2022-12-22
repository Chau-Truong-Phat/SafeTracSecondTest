using MedWorking.Core.Common.Response;
using Newtonsoft.Json;
using FluentValidation.Results;
using MedWorking.Core.Application.ModuleDocument.Models;

namespace MedWorking.Core.Application.ModuleDocument.Commands;
[JsonObject(Title = "DocumentCommandResponse")]
public class DocumentCommandResponse : BaseResponse
{
    public DocumentCommandResponse() 
        : base() {}
    
    public DocumentCommandResponse(IList<ValidationFailure> failures)
        : base(failures) {}
    
    public DocumentModel Result { get; set; }
}