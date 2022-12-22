using System;
using System.Collections.Generic;

namespace MedWorking.Core.EntityFramework.Models
{
    public partial class Role
    {
        public Guid Id { get; set; }
        public string? RoleCode { get; set; }
        public string? RoleName { get; set; }
        public string? Description { get; set; }
        public string? CreateUser { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
