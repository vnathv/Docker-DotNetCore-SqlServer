using Employee.DataAccessLayer.Repositories;
using Employee.Provider.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Provider
{
    public class EmployeeProvider : IEmployeeProvider
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeProvider(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public void AddEmployee(DataAccessLayer.Employee employee)
        {
            employeeRepository.AddEmployee(employee);
        }

        public DataAccessLayer.Employee GetEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DataAccessLayer.Employee> GetEmployees()
        {
            throw new NotImplementedException();
        }
    }
}
