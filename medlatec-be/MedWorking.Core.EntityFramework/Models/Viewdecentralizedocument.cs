using System;
using System.Collections.Generic;

namespace MedWorking.Core.EntityFramework.Models
{
    public partial class ViewDecentralizeDocument
    {
        public Guid? Id { get; set; }
        public string? OfficeName { get; set; }
        public long? Level { get; set; }
        public bool? DecentralizeDocState { get; set; }
        public string? Description { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
