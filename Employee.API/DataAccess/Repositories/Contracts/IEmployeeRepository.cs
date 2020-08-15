using System.Collections.Generic;

namespace Employee.DataAccessLayer.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployee(string employeeId);
        void AddEmployee(Employee employee);
        bool Save();
    }
}
