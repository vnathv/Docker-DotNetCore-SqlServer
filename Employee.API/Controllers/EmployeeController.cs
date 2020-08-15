using Employee.Provider.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Employee.API.Controllers
{
    [ApiController]
    [Route("api/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeProvider employeeProvider;

        public EmployeeController(IEmployeeProvider employeeProvider)
        {
            this.employeeProvider = employeeProvider;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<DataAccessLayer.Employee>> GetEmployees()
        {
            return employeeProvider.GetEmployees().ToList();
        }

        [HttpGet("{employeeId}")]
        public ActionResult<DataAccessLayer.Employee> GetEmployee(string employeeId)
        {
            return employeeProvider.GetEmployee(employeeId);
        }

        [HttpPost]
        public void AddEmployee(DataAccessLayer.Employee employee)
        {
            employeeProvider.AddEmployee(employee);
        }
    }
}
