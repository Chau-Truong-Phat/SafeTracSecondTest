using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedWorking.Core.Application.ModuleDocument.Models
{
    public class DocumentProcessModel
    {
        public string StepName { get; set; }
        public BrowsingProcess BrowsingProcess { get; set; }
    }

    public class BrowsingProcess
    {
        public List<ImplementOffice> ImplementOffices { get; set; }
    }

    public class ImplementOffice
    {
        public string OfficeName { get; set; }
        public List<ImplementUser> ImplementUsers { get; set; }
    }

    public class ImplementUser
    {
        public string UserName { get; set; }
        public string StatusApproval { get; set; }
    }
}
