using FluentValidation.Results;
using MedWorking.Core.Application.ModuleGroupDocument.Models;
using MedWorking.Core.Common.Response;
using Newtonsoft.Json;

namespace MedWorking.Core.Application.ModuleGroupDocument.Commands;

[JsonObject(Title = "GroupDocumentResponse")]
public class GroupDocumentCommandResponse : BaseResponse
{
    public  GroupDocumentCommandResponse() 
        : base()
    {

    }

    public GroupDocumentCommandResponse(IList<ValidationFailure> failures)
    : base(failures)
         {

         }

    public GroupDocumentModel Result { get; set; }
}
