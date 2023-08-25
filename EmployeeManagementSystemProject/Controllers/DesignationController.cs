using EmployeeManagementSystemProject.Models;
using EmployeeManagementSystemProject.Repositiry;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystemProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly IDesignationRepository _designation;
        public DesignationController(IDesignationRepository designation)
        {
            _designation = designation ??
                throw new ArgumentNullException(nameof(designation));
        }

        [HttpGet]
        [Route("GetDesignation")]
        public async Task < IActionResult > Get()
        {
            return Ok(await _designation.GetDesignation());
        }

        [HttpGet]
        [Route("GetDesignationByID/{Id}")]
        public async Task < IActionResult > GetDesigById(int Id)
        {
            return Ok(await _designation.GetDesignationByID(Id));
        }

        [HttpPost]
        [Route("AddDesignation")]
        public async Task < IActionResult > Post (Designation desig)
        {
            var result = await _designation.InsertDesignation(desig);
            if(result.DesignationId == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            
            return Ok("Added Successfully");
        }

        [HttpPut]
        [Route("UpdateDesignation")]
        public async Task <IActionResult> Put (Designation desig)
        {
            await _designation.UpdateDesignation(desig);
            return Ok("Updated Successfully");
        }

        [HttpDelete]
        [Route("DeleteDesignationt")]
        //[HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            _designation.DeleteDesignationt(id);
            return new JsonResult("Deleted Successfully");
        }
        
    }
}
