using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedWorking.Core.Application.ModuleApprovation.Models
{
    public class ApprovationModel 
    {
        public Guid DocId { get; set; }
        public Guid ApprovalStaffLevelId { get; set; }
    }
}
