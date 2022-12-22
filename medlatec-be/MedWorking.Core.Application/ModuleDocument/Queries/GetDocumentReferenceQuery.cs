using MediatR;
using MedWorking.Core.EntityFramework.Models;

namespace MedWorking.Core.Application.ModuleDocument.Queries;

public class GetDocumentReferenceQuery : IRequest<List<Document>> { }