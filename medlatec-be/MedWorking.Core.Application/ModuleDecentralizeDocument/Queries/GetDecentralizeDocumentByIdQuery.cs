using MediatR;
using MedWorking.Core.Application.ModuleDecentralizeDocument.Models;

namespace MedWorking.Core.Application.ModuleDecentralizeDocument.Queries;

public class GetDecentralizeDocumentByIdQuery : IRequest<DecentralizeDocumentDetailModel>
{
    public Guid DecentralizeDocId { get; set; }    
}
