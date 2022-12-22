using MediatR;
using MedWorking.Core.Application.ModuleGroupDocument.Models;

namespace MedWorking.Core.Application.ModuleGroupDocument.Queries;

public class GetGroupDocumentByIdQuery : IRequest<GroupDocumentModel>
{
    public string GroupDocId { get; set; } = string.Empty!;
}
