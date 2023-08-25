using EmployeeManagementSystemProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystemProject.Repositiry
{
    public class QualificationRepository : IQualificationRepository
    {
        private readonly EmployeeDbContext _dbContext;
        public QualificationRepository(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Qualification>> GetQualification()
        {
            var q = await _dbContext.Qualifications.ToListAsync();
            return q;
        }

        public async Task<Qualification> GetQualificationByID(int ID)
        {
            var quliFind = await _dbContext.Qualifications.FindAsync(ID);
            return quliFind;
        }

        public async Task<Qualification> InsertQualification(Qualification model)
        {
            _dbContext.Qualifications.Add(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }

        public async Task<Qualification> UpdateQualification(Qualification model)
        {
            _dbContext.Entry(model).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return model;
        }

        public bool DeleteQualification(int ID)
        {
            bool result = false;
            var qulifica = _dbContext.Designations.Find(ID);
            if (qulifica != null)
            {
                _dbContext.Entry(qulifica).State = EntityState.Deleted;
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
