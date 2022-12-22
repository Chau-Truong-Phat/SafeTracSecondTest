using System;
using System.Collections.Generic;

namespace MedWorking.Core.EntityFramework.Models
{
    public partial class ViewAccountDetail
    {
        public string? EmployeeId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public bool? Auto { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? AvatarUrl { get; set; }
        public int? Level { get; set; }
        public bool? Online { get; set; }
        public string? PhoneNumber { get; set; }
        public string? SerialNumber { get; set; }
        public string? SignatureUrl { get; set; }
        public Guid? UserId { get; set; }
        public string? UserName { get; set; }
        public long? Positionid { get; set; }
        public string? PositionName { get; set; }
        public long? Officeid { get; set; }
        public string? OfficeName { get; set; }
    }
}
