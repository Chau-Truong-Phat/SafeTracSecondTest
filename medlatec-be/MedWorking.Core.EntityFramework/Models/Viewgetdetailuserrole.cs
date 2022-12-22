using System;
using System.Collections.Generic;

namespace MedWorking.Core.EntityFramework.Models
{
    public partial class ViewGetDetailUserRole
    {
        public Guid? UserId { get; set; }
        public string? EmployeeCode { get; set; }
        public string? EmployeeName { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? Description { get; set; }
        public string? Roleid { get; set; }
        public string? Rolename { get; set; }
        public long? Officeid { get; set; }
        public string? OfficeName { get; set; }
        public long? Positionid { get; set; }
        public string? PositionName { get; set; }
    }
}
