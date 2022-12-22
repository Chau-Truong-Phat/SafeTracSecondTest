using System;
using System.Collections.Generic;

namespace MedWorking.Core.EntityFramework.Models
{
    public partial class DocumentComment
    {
        public Guid Id { get; set; }
        public long? OfficeId { get; set; }
        public string? UserId { get; set; }
        public string? MsgComment { get; set; }
        public int? Type { get; set; }
        public string? CreateUser { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? OfficeName { get; set; }
    }
}
