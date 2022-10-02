namespace SafeTracSecondTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public User()
        {
            UserPermissions = new HashSet<UserPermission>();
        }

        public int Id { get; set; }

        [StringLength(255)]
        public string First_Name { get; set; }

        [StringLength(255)]
        public string Last_Name { get; set; }

        [StringLength(255)]
        public string User_Password { get; set; }

        [StringLength(255)]
        public string Email_Address { get; set; }

        public DateTime? Date_Created { get; set; }

        public DateTime? Date_Modified { get; set; }

        public virtual ICollection<UserPermission> UserPermissions { get; set; }
    }
}
