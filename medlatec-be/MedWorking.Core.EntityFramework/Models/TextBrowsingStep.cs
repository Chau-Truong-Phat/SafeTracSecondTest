using System;
using System.Collections.Generic;

namespace MedWorking.Core.EntityFramework.Models
{
    public partial class TextBrowsingStep
    {
        public Guid Id { get; set; }
        public int? Stt { get; set; }
        public Guid? ConfigureBrowsingStepId { get; set; }
        public Guid? ApprovalGeneralDocumentProcessId { get; set; }
    }
}
