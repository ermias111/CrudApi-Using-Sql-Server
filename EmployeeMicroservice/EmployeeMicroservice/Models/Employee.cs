using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMicroservice.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Office { get; set; }
        public int Salary { get; set; }
    }
}
