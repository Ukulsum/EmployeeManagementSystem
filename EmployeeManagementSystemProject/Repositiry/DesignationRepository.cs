using EmployeeManagementSystemProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystemProject.Repositiry
{
    public class DesignationRepository : IDesignationRepository
    {
        private readonly EmployeeDbContext _dbContext;
        public DesignationRepository(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Designation>> GetDesignation()
        {
            var designation = await _dbContext.Designations.ToListAsync();
            return designation;
        }

        public async Task<Designation> GetDesignationByID(int ID)
        {
            return await _dbContext.Designations.FindAsync(ID);
        }


        public async Task<Designation> InsertDesignation(Designation model)
        {
            _dbContext.Designations.Add(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }

        public async Task<Designation> UpdateDesignation(Designation model)
        {
            _dbContext.Entry(model).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return model;
        }
        public bool DeleteDesignationt(int ID)
        {
            bool result = false;
            var designations = _dbContext.Designations.Find(ID);
            if(designations != null)
            {
                _dbContext.Entry(designations).State = EntityState.Deleted;
                _dbContext.SaveChanges();
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
