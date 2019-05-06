using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeMicroservice.DbContexts;
using EmployeeMicroservice.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMicroservice.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _employeeContext;

        public EmployeeRepository(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        public void Insert(Employee employee)
        {
            _employeeContext.Add(employee);
            Save();
        }

        public void Delete(int id)
        {
            var employee = _employeeContext.Employees.Find(id);
            _employeeContext.Employees.Remove(employee);
        }

        public Employee Get(int id)
        {
            return _employeeContext.Employees.Find(id);
        }

        public IEnumerable<Employee> ListEmployees()
        {
            return _employeeContext.Employees.ToList();
        }

        public void Save()
        {
            _employeeContext.SaveChanges();
        }

        public void Update(Employee employee)
        {
            _employeeContext.Entry(employee).State = EntityState.Modified;
            Save();
        }
    }
}
