using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeMicroservice.Repository;
using EmployeeMicroservice.DbContexts;
using EmployeeMicroservice.Models;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeMicroservice.Controllers
{
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            var employees = _employeeRepository.ListEmployees();
            return new OkObjectResult(employees);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var employee = _employeeRepository.Get(id);
            return new OkObjectResult(employee);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Employee employee)
        {
            using (var scope = new TransactionScope())
            {
                _employeeRepository.Insert(employee);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = employee.ID }, employee);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]Employee employee)
        {
            if (employee != null)
            {
                using (var scope = new TransactionScope())
                {
                    _employeeRepository.Update(employee);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _employeeRepository.Delete(id);
            return new OkResult();
        }
    }
}
