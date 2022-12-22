using MediatR;
using MedWorking.Core.Application.ModuleDocument.Models;

namespace MedWorking.Core.Application.ModuleDocument.Queries;

public class GetDocumentByIdQuery : IRequest<DocumentDetailModel>
{
    public Guid Id { get; set; }
}
