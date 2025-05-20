using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace nijapmsapi
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleRightsController : Controller
    {
        private readonly IRoleRightsRepository _RoleRights;
        public RoleRightsController(IRoleRightsRepository RoleRights)
        {
            this._RoleRights = RoleRights;
        }
       

        [HttpGet]
        [Route("GetRoleRights")]
        public async Task<IEnumerable<RoleRights>> GetRoleRights()
        {
            return await _RoleRights.Get();
        }

        [HttpGet]
        [Route("RoleRightsGetByRoleId")]
        public async Task<IActionResult> GetRoleRightsId(int RoleId)
        {
            if (RoleId == 0)
            {
                return BadRequest();
            }

           List<MenuList> RoleRights = (List<MenuList>) await _RoleRights.Find(RoleId);

            if (RoleRights == null)
            {
                return NotFound();
            }





            List<MenuList> activeList = new List<MenuList>();

            

            foreach (var item in RoleRights)
            {
                List<MenuList> RoleRights1 = (List<MenuList>)await _RoleRights.GetMenuListByLId(item.RoleId, item.Id);
                MenuList data = new MenuList();
                data.content = new List<Content>();
                if (RoleRights1!=null && RoleRights1.Count >0)
                {
                    foreach (var list in RoleRights1)
                    {
                        Content activeContent = new Content();
                        activeContent.title = list.title;
                        activeContent.to = list.to;
                        data.content.Add(activeContent);
                    }
                    
                }
               
                data.title = item.title;
                data.classsChange = item.classsChange;
                data.to = item.to;
                data.iconStyle = item.iconStyle;
                activeList.Add(data);
            }

            
            return Ok(activeList);
        }

       
        [HttpPost]
        [Route("AddRoleRights")]
        public async Task<IActionResult> AddRoleRights(RoleRights activeRoleRights)
        {
            var result = await _RoleRights.Add(activeRoleRights);
            return Ok();
        }

        [HttpPost]
        [Route("UpdateRoleRights")]
        public async Task<IActionResult> PutRoleRights(RoleRights activeRoleRights)
        {
            if (activeRoleRights == null || activeRoleRights.Id == 0)
            {
                return BadRequest();
            }

            await _RoleRights.Update(activeRoleRights);
            return Ok();
        }

        [HttpPost]
        [Route("DeleteRoleRights")]
        public async Task<IActionResult> DeleteRoleRights(int id, bool isDelete)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            await _RoleRights.Remove(id, isDelete);
            return Ok();
        }

    }
}
