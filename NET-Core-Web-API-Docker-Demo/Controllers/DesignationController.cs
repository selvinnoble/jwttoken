using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace nijapmsapi
{
    [Route("api/[controller]")]
    
    [ApiController]
    public class DesignationController : Controller
    {
        private readonly IDesignationRepository _designation;
        public DesignationController(IDesignationRepository Designation)
        {
            this._designation =Designation;
        }
        
        [HttpGet]
        [Route("GetDesignation")]
        public async Task<IEnumerable<Designation>> GetDesignation()
        {
            return await _designation.Get();
        }

        [HttpGet]
        [Route("GetDesignationId")]
        public async Task<IActionResult> GetDesignationId(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var Designation = await _designation.Find(id);

            if (Designation == null)
            {
                return NotFound();
            }

            return Ok(Designation);
        }

        [HttpPost]
        [Route("AddDesignation")]
        public async Task<IActionResult> AddDesignation(Designation activeDesignation)
        {
            var result = await _designation.Add(activeDesignation);
            return Ok();
        }

        [HttpPost]
        [Route("UpdateDesignation")]
        public async Task<IActionResult> PutDesignation(Designation activeDesignation)
        {
            if (activeDesignation == null || activeDesignation.Id == 0)
            {
                return BadRequest();
            }

            await _designation.Update(activeDesignation);
            return Ok();
        }

        [HttpPost]
        [Route("DeleteDesignation")]
        public async Task<IActionResult> DeleteDesignation(int id, bool isDelete)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            await _designation.Remove(id, isDelete);
            return Ok();
        }
    }
}
