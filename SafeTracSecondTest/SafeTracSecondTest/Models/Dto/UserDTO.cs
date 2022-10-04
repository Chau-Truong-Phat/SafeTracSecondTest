using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafeTracSecondTest.Models.Dto
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string User_Password { get; set; }
        public string Email_Address { get; set; }
        public DateTime Date_Created { get; set; }
        public string Date_Created_AU_Format { get; set; }
        public DateTime Date_Modified { get; set; }
        public string Date_Modified_AU_Format { get; set; }
    }

    public class UserFilterDTO
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email_Address { get; set; }
        public DateTime Date_Created { get; set; }
        public List<UserDTO> UserDTOs { get; set; } = new List<UserDTO>();
    }
}