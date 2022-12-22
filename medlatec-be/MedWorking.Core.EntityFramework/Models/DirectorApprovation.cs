using System;
using System.Collections.Generic;

namespace MedWorking.Core.EntityFramework.Models
{
    public partial class DirectorApprovation
    {
        public Guid Id { get; set; }
        public Guid? DocId { get; set; }
        public string? ApprovalUserId { get; set; }
        public Guid? CreateUser { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
