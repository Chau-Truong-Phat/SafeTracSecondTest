using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedWorking.Core.Application.ModuleDocument.Models
{
    public class ListDocumentModel
    {
        public string DocumentCode { get; set; }
        public string GroupDocumentName { get; set; }
        public string PatternDocumentName { get; set; }
        public string DocumentName { get; set; }
        public string PriorityName { get; set; }
        public int Status { get; set;}
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public string ProposalOfficeName { get; set; }
        public string Notes { get; set; }
    }
}