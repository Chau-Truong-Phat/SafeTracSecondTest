using MediatR;
using MedWorking.Core.Application.ModulePatternDocument.Models;
using MedWorking.Core.EntityFramework.Models;

namespace MedWorking.Core.Application.ModulePatternDocument.Queries;

public class GetPatternDocumentByIdQuery : IRequest<PatternDocumentDetailModel>
{
    public Guid Id { get; set; }    
}
