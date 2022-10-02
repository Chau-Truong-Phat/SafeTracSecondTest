namespace SafeTracSecondTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserPermission
    {
        public int Id { get; set; }

        public int User_Id { get; set; }

        public int Permission { get; set; }

        public virtual User User { get; set; }
    }
}
