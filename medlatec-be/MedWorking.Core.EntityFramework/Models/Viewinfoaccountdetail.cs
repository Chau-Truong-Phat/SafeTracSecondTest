using System;
using System.Collections.Generic;

namespace MedWorking.Core.EntityFramework.Models
{
    public partial class ViewInfoAccountDetail
    {
        public string? UserName { get; set; }
        public string? EmployeeId { get; set; }
        public string? FullName { get; set; }
        public long? Officeid { get; set; }
        public string? OfficeName { get; set; }
        public long? Positionid { get; set; }
        public string? PositionName { get; set; }
    }
}
