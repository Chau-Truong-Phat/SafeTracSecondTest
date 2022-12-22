using System;
using System.Collections.Generic;

namespace MedWorking.Core.EntityFramework.Models
{
    public partial class PatternDocOffice
    {
        public Guid Id { get; set; }
        public Guid? PatternDocId { get; set; }
        public long? OfficeId { get; set; }
        public long? ParrentId { get; set; }
    }
}
