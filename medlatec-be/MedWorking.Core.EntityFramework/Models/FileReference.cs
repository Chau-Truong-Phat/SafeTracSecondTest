using System;
using System.Collections.Generic;

namespace MedWorking.Core.EntityFramework.Models
{
    public partial class FileReference
    {
        public Guid Id { get; set; }
        public string? Path { get; set; }
        public long? Size { get; set; }
        public Guid? DocId { get; set; }
        public string? FileName { get; set; }
        public string? Extension { get; set; }
        public string? OriginalFileName { get; set; }
        public string? CreateUser { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
