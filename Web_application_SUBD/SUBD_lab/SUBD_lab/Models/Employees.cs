using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SUBD_lab.Models
{
    public class Employees
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Department { get; set; }
        public string DateOfJoining { get; set; }
        public string PhotoFileName { get; set; }
    }
}
