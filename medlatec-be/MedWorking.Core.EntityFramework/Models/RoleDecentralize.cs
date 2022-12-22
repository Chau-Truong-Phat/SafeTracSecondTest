using System;
using System.Collections.Generic;

namespace MedWorking.Core.EntityFramework.Models
{
    public partial class RoleDecentralize
    {
        public Guid Id { get; set; }
        public long? DecentralizeId { get; set; }
        public Guid? RoleId { get; set; }
        public long? ParentId { get; set; }
    }
}
