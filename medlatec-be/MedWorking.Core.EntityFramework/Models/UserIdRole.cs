using System;
using System.Collections.Generic;

namespace MedWorking.Core.EntityFramework.Models
{
    public partial class UserIdRole
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}
