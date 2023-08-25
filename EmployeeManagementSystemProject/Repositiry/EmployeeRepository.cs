

using EmployeeManagementSystemProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystemProject.Repositiry
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _db;
        public EmployeeRepository(EmployeeDbContext db)
        {
            _db = db;
            throw new ArgumentNullException(nameof(db));
        }


        public async Task<IEnumerable<Employee>> GetEmployee()
        {
            var emp = await _db.Employees.ToListAsync();
            return emp;
        }

        public async Task<Employee> GetEmployeeByID(int ID)
        {
            return await _db.Employees.FindAsync(ID);
        }

        public async Task<Employee> InsertEmployee(Employee model)
        {
            _db.Employees.Add(model);
            await _db.SaveChangesAsync();
            return model;
        }

        public async Task<Employee> UpdateEmployee(Employee model)
        {
            _db.Entry(model).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return model;
        }

        public bool DeleteEmployee(int ID)
        {
            bool result = false;
            var employee = _db.Employees.Find(ID);
            if(employee != null)
            {
                _db.Entry(employee).State = EntityState.Deleted;
                _db.SaveChanges();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}
