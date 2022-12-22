using MediatR;
using MedWorking.Core.Application.ModuleGroupDocument.Models;

namespace MedWorking.Core.Application.ModuleGroupDocument.Commands;

public class GroupDocumentCommand : GroupDocumentModel , IRequest<GroupDocumentCommandResponse> { }
