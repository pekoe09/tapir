using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Tapir.Core;

namespace Tapir.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmploymentsController : ControllerBase
    {
        private IEmploymentService employmentService;

        public EmploymentsController(IEmploymentService employmentService)
        {
            this.employmentService = employmentService;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<List<EmploymentDTO>> GetAll()
        {
            List<EmploymentDTO> employments = employmentService.GetEmployments();
            return employments;
        }

        [HttpGet("{id}", Name = "GetEmployment")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<EmploymentDTO> GetById(int id)
        {
            EmploymentDTO employment = employmentService.GetEmployment(id);
            if (employment == null)
            {
                return NotFound();
            }
            return employment;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<EmploymentDTO> Create(EmploymentDTO employment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            EmploymentDTO newEmployment = employmentService.SaveEmployment(employment);
            return CreatedAtRoute(routeName: "GetEmployment", routeValues: new { id = newEmployment.Id }, value: newEmployment);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<EmploymentDTO> Update(int id, EmploymentDTO employment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            EmploymentDTO updatedEmployment = employmentService.SaveEmployment(employment);
            if (updatedEmployment == null)
            {
                return NotFound();
            }
            return Ok(updatedEmployment);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<EmploymentDTO> Delete(int id)
        {
            EmploymentDTO deletedEmployment = employmentService.RemoveEmployment(id);
            if (deletedEmployment == null)
            {
                return NotFound();
            }
            return Ok(deletedEmployment);
        }
    }
}
