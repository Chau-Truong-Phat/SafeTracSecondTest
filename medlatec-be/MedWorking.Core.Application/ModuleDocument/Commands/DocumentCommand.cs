using MediatR;
using MedWorking.Core.Application.ModuleDocument.Models;

namespace MedWorking.Core.Application.ModuleDocument.Commands;

public class DocumentCommand : DocumentModel, IRequest<DocumentCommandResponse>
{
    
}