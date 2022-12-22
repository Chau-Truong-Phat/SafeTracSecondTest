using System;
using System.Collections.Generic;

namespace MedWorking.Core.EntityFramework.Models
{
    public partial class DocumentReference
    {
        public Guid Id { get; set; }
        public Guid? DocId { get; set; }
        public string? DocName { get; set; }
        public Guid? DocRefId { get; set; }
        public string? DocRefName { get; set; }
        public string? CreateUser { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
