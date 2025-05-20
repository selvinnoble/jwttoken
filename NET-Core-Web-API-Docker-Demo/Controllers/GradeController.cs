using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace nijapmsapi
{
    [Route("api/[controller]")]
    
    [ApiController]
    public class GradeController : Controller
    {
        private readonly IGradeRepository _grade;
        public GradeController(IGradeRepository Grade)
        {
            this._grade = Grade;
        }
        
        [HttpGet]
        [Route("GetGrade")]
        public async Task<IEnumerable<Grade>> GetGrade()
        {
            return await _grade.Get();
        }

        [HttpGet]
        [Route("GetGradeId")]
        public async Task<IActionResult> GetGradeId(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var Grade = await _grade.Find(id);

            if (Grade == null)
            {
                return NotFound();
            }

            return Ok(Grade);
        }

        [HttpPost]
        [Route("AddGrade")]
        public async Task<IActionResult> AddGrade(Grade activeGrade)
        {
            var result = await _grade.Add(activeGrade);
            return Ok();
        }

        [HttpPost]
        [Route("UpdateGrade")]
        public async Task<IActionResult> PutGrade(Grade activeGrade)
        {
            if (activeGrade == null || activeGrade.Id == 0)
            {
                return BadRequest();
            }

            await _grade.Update(activeGrade);
            return Ok();
        }

        [HttpPost]
        [Route("DeleteGrade")]
        public async Task<IActionResult> DeleteGrade(int id, bool isDelete)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            await _grade.Remove(id, isDelete);
            return Ok();
        }
    }
}
