using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITTP_Task.Models
{
    public class User
    {
        Guid Guid;
        public string login;
        public string password;
        public string name;
        public int gender;
        public DateTime birthday;
        public bool admin;
        public DateTime createdOn;
        public string createdBy;
        public DateTime modifiedOn;
        public string modifiedBy;
        public DateTime revokedOn;
        public string revokedBy;
    }
}
