using System;
using System.Collections.Generic;

namespace Employee.Provider.Contracts
{
    public interface IEmployeeProvider
    {
        IEnumerable<DataAccessLayer.Employee> GetEmployees();
        DataAccessLayer.Employee GetEmployee(string employeeId);
        void AddEmployee(DataAccessLayer.Employee employee);
    }
}
