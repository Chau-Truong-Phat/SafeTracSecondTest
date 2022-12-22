using MediatR;
using MedWorking.Core.Application.ModuleGroupDocument.Models;

namespace MedWorking.Core.Application.ModuleGroupDocument.Queries;

public class GetGroupDocumentAllListQuery : IRequest<List<GroupDocumentModel>> { }
