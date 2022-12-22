using System;
using System.Collections.Generic;

namespace MedWorking.Core.EntityFramework.Models
{
    public partial class ConfigColumn
    {
        public Guid Id { get; set; }
        public int ViewType { get; set; }
        public string? InfoJson { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateUser { get; set; }
        public string? UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
