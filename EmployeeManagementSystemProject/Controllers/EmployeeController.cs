using EmployeeManagementSystemProject.Models;
using EmployeeManagementSystemProject.Repositiry;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystemProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employee;
        private readonly IDesignationRepository _designation;
        private readonly IQualificationRepository _qualification;
        private readonly IReligionRepository _religion;
        private readonly IWebHostEnvironment _env;

        public EmployeeController(IEmployeeRepository employee, IDesignationRepository designation,IQualificationRepository qualification,IReligionRepository religion, IWebHostEnvironment env)
        {
            _employee = employee ??
                throw new ArgumentNullException(nameof(employee));
            _designation = designation ??
                throw new ArgumentNullException(nameof(designation));
            _qualification = qualification ??
                throw new ArgumentNullException(nameof(qualification));
            _religion = religion ??
                 throw new ArgumentNullException(nameof(religion));
            this._env = env;
        }

        [HttpGet]
        [Route("GetEmployee")]
        public async Task <IActionResult> Get()
        {
            return Ok(await _employee.GetEmployee());
        }

        [HttpGet]
        [Route("GetEmployeeByID/{Id}")]
        public async Task <IActionResult> GetEmployeeByID(int Id)
        {
            return Ok(await _employee.GetEmployeeByID(Id));
        }

        [HttpPost]
        [Route("AddEmployee")]
        public async Task <IActionResult> Post(Employee emp)
        {
            var result = await _employee.InsertEmployee(emp);
            if(result.EmpId == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Added Successfully");
        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task <IActionResult> Put(Employee emp)
        {
            await _employee.UpdateEmployee(emp);
            return Ok("Updated Successfully");
        }

        [HttpDelete]
        [Route("")]
        //[HttpDelete("{id}")]
        public JsonResult Delete (int id)
        {
            var result = _employee.DeleteEmployee(id);
            return new JsonResult("Deleted Successfully");
        }

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos" + filename;
                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    stream.CopyTo(stream);
                }
                return new JsonResult(filename);

            }
            catch (Exception)
            {
                return new JsonResult("anonymous.png");
            }
        }

        [HttpGet]
        [Route("GetDesignation")]
        public async Task<IActionResult> GetAllDesignationNames()
        {
            return Ok(await _designation.GetDesignation());
        }
    }
}
