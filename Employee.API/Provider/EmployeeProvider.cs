using Employee.DataAccessLayer.Repositories;
using Employee.Provider.Contracts;
using System.Collections.Generic;

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

        public DataAccessLayer.Employee GetEmployee(string employeeId)
        {
            return employeeRepository.GetEmployee(employeeId);
        }

        public IEnumerable<DataAccessLayer.Employee> GetEmployees()
        {
            return employeeRepository.GetEmployees();
        }
    }
}
