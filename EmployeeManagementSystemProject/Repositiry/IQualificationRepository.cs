using EmployeeManagementSystemProject.Models;

namespace EmployeeManagementSystemProject.Repositiry
{
    public interface IQualificationRepository
    {
        Task<IEnumerable<Qualification>> GetQualification();
        Task<Qualification> GetQualificationByID(int ID);
        Task<Qualification> InsertQualification(Qualification model);
        Task<Qualification> UpdateQualification(Qualification model);
        bool DeleteQualification(int ID);
    }
}
