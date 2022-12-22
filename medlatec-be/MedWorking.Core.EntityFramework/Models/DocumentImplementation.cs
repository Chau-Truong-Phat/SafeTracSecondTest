using System;
using System.Collections.Generic;

namespace MedWorking.Core.EntityFramework.Models
{
    public partial class DocumentImplementation
    {
        public Guid Id { get; set; }
        public Guid? DocId { get; set; }
        public long? OfficeId { get; set; }
    }
}
