using EmployeeManagementSystemProject.Models;

namespace EmployeeManagementSystemProject.Repositiry
{
    public interface IEmployeeRepository
    {
        Task <IEnumerable<Employee>> GetEmployee();
        Task<Employee> GetEmployeeByID(int ID);
        Task<Employee> InsertEmployee(Employee model);
        Task<Employee> UpdateEmployee(Employee model);
        bool DeleteEmployee(int ID);
    }
}
