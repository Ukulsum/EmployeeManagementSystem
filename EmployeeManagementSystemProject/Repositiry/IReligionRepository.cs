using EmployeeManagementSystemProject.Models;

namespace EmployeeManagementSystemProject.Repositiry
{
    public interface IReligionRepository
    {
        Task<IEnumerable<Religion>> GetReligion();
        Task<Religion> GetReligionByID(int ID);
        Task<Religion> InsertReligion(Religion model);
        Task<Religion> UpdateReligion(Religion model);
        bool DeleteReligion(int ID);
    }
}
