using MediatR;
using MedWorking.Core.Application.ModuleDocument.Models;

namespace MedWorking.Core.Application.ModuleDocument.Queries
{
    public class GetAdvisoryOfficeByIdQuery : IRequest<List<long?>>
    {
        public Guid PatternDocId { get; set; }
    }
}