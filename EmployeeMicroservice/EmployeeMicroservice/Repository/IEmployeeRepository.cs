using EmployeeMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMicroservice.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> ListEmployees();
        Employee Get(int id);
        void Insert(Employee employee);
        void Update(Employee employee);
        void Delete(int id);
        void Save();
    }
}
