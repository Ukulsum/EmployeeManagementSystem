using EmployeeManagementSystemProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystemProject.Repositiry
{
    public class ReligionRepository : IReligionRepository
    {
        private readonly EmployeeDbContext _dbContext;
        public ReligionRepository(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        

        public async Task<IEnumerable<Religion>> GetReligion()
        {
            var rel = await _dbContext.Religions.ToListAsync();
            return rel;
        }

        public async Task<Religion> GetReligionByID(int ID)
        {
            return await _dbContext.Religions.FindAsync(ID);
        }

        public async Task<Religion> InsertReligion(Religion model)
        {
            _dbContext.Religions.Add(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }

        public async Task<Religion> UpdateReligion(Religion model)
        {
            _dbContext.Entry(model).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return model;
        }

        public bool DeleteReligion(int ID)
        {
            bool result = false;
            var religion = _dbContext.Designations.Find(ID);
            if (religion != null)
            {
                _dbContext.Entry(religion).State = EntityState.Deleted;
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
