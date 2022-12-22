using System;
using System.Collections.Generic;

namespace MedWorking.Core.EntityFramework.Models
{
    public partial class PatternDocumentDetailByGroupDocument
    {
        public Guid Id { get; set; }
        public Guid? GroupDocumentId { get; set; }
        public Guid? PatternDocumentId { get; set; }
        public Guid? ApprovalGeneralDocumentProcessUnitId { get; set; }
    }
}
