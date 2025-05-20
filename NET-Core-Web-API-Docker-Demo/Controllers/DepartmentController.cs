using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace nijapmsapi
{
    [Route("api/[controller]")]
    
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _department;
        public DepartmentController(IDepartmentRepository Department)
        {
            this._department = Department;
        }
        
        [HttpGet]
        [Route("GetDepartment")]
        public async Task<IEnumerable<Department>> GetDepartment()
        {
            return await _department.Get();
        }

        [HttpGet]
        [Route("GetDepartmentId")]
        public async Task<IActionResult> GetDepartmentId(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var Department = await _department.Find(id);

            if (Department == null)
            {
                return NotFound();
            }

            return Ok(Department);
        }

        [HttpPost]
        [Route("AddDepartment")]
        public async Task<IActionResult> AddDepartment(Department activeDepartment)
        {
            var result = await _department.Add(activeDepartment);
            return Ok();
        }

        [HttpPost]
        [Route("UpdateDepartment")]
        public async Task<IActionResult> PutDepartment(Department activeDepartment)
        {
            if (activeDepartment == null || activeDepartment.Id == 0)
            {
                return BadRequest();
            }

            await _department.Update(activeDepartment);
            return Ok();
        }

        [HttpPost]
        [Route("DeleteDepartment")]
        public async Task<IActionResult> DeleteDepartment(int id, bool isDelete)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            await _department.Remove(id, isDelete);
            return Ok();
        }
    }
}
