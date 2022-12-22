using System;
using System.Collections.Generic;

namespace MedWorking.Core.EntityFramework.Models
{
    public partial class PatternDocDetailByGroupDocGeneral
    {
        public Guid Id { get; set; }
        public Guid? GroupDocumentId { get; set; }
        public Guid? PatternDocumentId { get; set; }
        public Guid? ApprovalGeneralDocumentProcessId { get; set; }
    }
}
