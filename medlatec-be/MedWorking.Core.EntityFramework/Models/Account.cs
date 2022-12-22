using System;
using System.Collections.Generic;

namespace MedWorking.Core.EntityFramework.Models
{
    public partial class Account
    {
        public Guid UserId { get; set; }
        public string? UserName { get; set; }
        public string? PasswordHash { get; set; }
        public string? EmployeeId { get; set; }
        public long? Office { get; set; }
        public long? Unit { get; set; }
        public long? Position { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? SignatureUrl { get; set; }
        public string? PhoneNumber { get; set; }
        public bool? Auto { get; set; }
        public TimeOnly? TimeLogin { get; set; }
        public bool? Online { get; set; }
        public int? Level { get; set; }
        public bool? Hc { get; set; }
        public bool? Active { get; set; }
        public string? AvatarUrl { get; set; }
        public string? SerialNumber { get; set; }
        public string? CreateUser { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
