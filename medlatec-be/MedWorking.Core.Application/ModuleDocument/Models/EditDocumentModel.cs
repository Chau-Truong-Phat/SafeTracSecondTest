using MediatR;
using MedWorking.Core.Application.ModuleDocument.Commands;
using MedWorking.Core.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedWorking.Core.Application.ModuleDocument.Models
{
    public class EditDocumentModel : IRequest<DocumentCommandResponse>
    {
        public Guid Id { get; set; }

        public string DocName { get; set; } 
        public int Priority { get; set; } 
        public DateTime ExpirationDate { get; set; } 

        public string Explaination { get; set; } 
        public string Notes { get; set; } 
        public string Description { get; set; } 

        public List<DocumentAdvisory> ListAdvisoryUnit { get; set; } 
        public List<DocumentImplementation> ListImplementUnit { get; set; } 
        public List<DocumentReference> ListRelatedDocument { get; set; } 
    }
}
