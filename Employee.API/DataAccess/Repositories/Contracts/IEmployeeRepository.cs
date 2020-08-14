using System.Collections.Generic;

namespace Employee.DataAccessLayer.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployee(int employeeId);
        void AddEmployee(Employee employee);
        bool Save();
    }
}
