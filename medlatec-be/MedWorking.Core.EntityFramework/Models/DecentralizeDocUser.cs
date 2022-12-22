using System;
using System.Collections.Generic;

namespace MedWorking.Core.EntityFramework.Models
{
    public partial class DecentralizeDocUser
    {
        public Guid Id { get; set; }
        public Guid DecentralizeDocId { get; set; }
        public string? EmployeeId { get; set; }
        public long DecentralizeDocumentLevel { get; set; }
        public string? DecentralizeDocumentNote { get; set; }
        public string? CreateUser { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
