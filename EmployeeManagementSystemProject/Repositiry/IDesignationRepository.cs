using EmployeeManagementSystemProject.Models;
using System.Collections.Generic;

namespace EmployeeManagementSystemProject.Repositiry
{
    public interface IDesignationRepository
    {
        Task<IEnumerable<Designation>> GetDesignation();
        Task<Designation> GetDesignationByID(int ID);
        Task<Designation> InsertDesignation(Designation model);
        Task<Designation> UpdateDesignation(Designation model);
        bool DeleteDesignationt(int ID);
    }
}
