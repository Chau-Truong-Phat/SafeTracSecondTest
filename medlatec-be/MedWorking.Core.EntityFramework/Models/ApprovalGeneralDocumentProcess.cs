using System;
using System.Collections.Generic;

namespace MedWorking.Core.EntityFramework.Models
{
    public partial class ApprovalGeneralDocumentProcess
    {
        public Guid Id { get; set; }
        public Guid? GroupDocumentId { get; set; }
        public DateTime? TimeApplication { get; set; }
        public string? Description { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateUser { get; set; }
    }
}
