using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace nijapmsapi
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employee;
        private readonly IWebHostEnvironment _hostEnvironment;
        public EmployeeController(IEmployeeRepository employee, IWebHostEnvironment hostEnvironment)
        {
            this._employee = employee;
            this._hostEnvironment = hostEnvironment;
        }
       

        [HttpGet]
        [Route("GetEmployee")]
        public async Task<IEnumerable<Employee>> GetEmployee(int id)
        {
            return await _employee.Get(id);
        }

        [HttpGet]
        [Route("GetEmployeeId")]
        public async Task<IActionResult> GetEmployeeId(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var Employee = await _employee.Find(id);

            if (Employee == null)
            {
                return NotFound();
            }

            return Ok(Employee);
        }

        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> AddEmployee(Employee activeEmployee)
        {
            //activeEmployee.ProfilePic = await SaveImage(activeEmployee.ImageFile);
            var result = await _employee.Add(activeEmployee);
            return Ok();
        }

        [HttpPost]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> PutEmployee(Employee activeEmployee)
        {
            if (activeEmployee == null || activeEmployee.EmployeeID == 0)
            {
                return BadRequest();
            }

            //activeEmployee.ProfilePic = await SaveImage(activeEmployee.ImageFile);
            await _employee.Update(activeEmployee);
            return Ok();
        }

        [HttpGet]
        [Route("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int id, bool isDelete)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            await _employee.Remove(id, isDelete);
            return Ok();
        }


        [NonAction]
        public async Task<string> SaveImage(string imageFile)
        {
            string imageName = new string(Path.GetFileNameWithoutExtension(imageFile).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmddssfff") + Path.GetExtension(imageFile);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);
            
            return imageName;
        }


      

    }
}
