using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace nijapmsapi
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : Controller
    {
        private readonly IRoleRepository _role;
        public RoleController(IRoleRepository role)
        {
            this._role = role;
        }
       

        [HttpGet]
        [Route("GetRole")]
        public async Task<IEnumerable<Role>> GetRole()
        {
            return await _role.Get();
        }

       
    }
}
