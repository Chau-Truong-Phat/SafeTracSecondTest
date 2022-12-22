using System;
using System.Collections.Generic;

namespace MedWorking.Core.EntityFramework.Models
{
    public partial class DocumentAdvisory
    {
        public Guid Id { get; set; }
        public Guid? DocId { get; set; }
        public long? OfficeId { get; set; }
    }
}
