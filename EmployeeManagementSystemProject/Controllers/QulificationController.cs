using EmployeeManagementSystemProject.Models;
using EmployeeManagementSystemProject.Repositiry;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystemProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QulificationController : ControllerBase
    {
        private readonly IQualificationRepository _qualification;
        public QulificationController(IQualificationRepository qualification)
        {
            _qualification = qualification ??
                throw new ArgumentNullException(nameof(qualification));
        }

        [HttpGet]
        [Route("GetQualification")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _qualification.GetQualification());
        }

        [HttpGet]
        [Route("GetQualificationByID/{Id}")]
        public async Task<IActionResult> GetDesigById(int Id)
        {
            return Ok(await _qualification.GetQualificationByID(Id));
        }

        [HttpPost]
        [Route("AddQualification")]
        public async Task<IActionResult> Post(Qualification model)
        {
            var result = await _qualification.InsertQualification(model);
            if (result.QualiId == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }

            return Ok("Added Successfully");
        }

        [HttpPut]
        [Route("UpdateQualification")]
        public async Task<IActionResult> Put(Qualification model)
        {
            await _qualification.UpdateQualification(model);
            return Ok("Updated Successfully");
        }

        [HttpDelete]
        [Route("DeleteQualification")]
        //[HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            _qualification.DeleteQualification(id);
            return new JsonResult("Deleted Successfully");
        }
    }
}
