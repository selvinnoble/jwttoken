using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace nijapmsapi
{

    [Route("api/[controller]")]
    [ApiController]

    public class UserController : Controller
    {
        public IConfiguration _configuration;
        private readonly DatabaseContext _context;

        private readonly IUserRepository _user;
        public UserController(IUserRepository user, IConfiguration config, DatabaseContext context)
        {
            this._user = user;
            this._configuration = config;
            this._context = context;
        }
       
        [HttpGet]
        public async Task<IActionResult> UserGetUNPASS(string username, string password)
        {
            if (username == string.Empty && password == string.Empty)
            {
                return BadRequest();
            }

            User user = await _user.UserGetUNPASS(username, password);

            if (user == null)
            {
                return NotFound();
            }
            else
            {
                user.Status = "Success";
                user.StatusCode = 200;
            }

            return Ok(user);
        }

        [HttpGet]
        [Route("GetUser")]
        public async Task<IEnumerable<User>> GetUser()
        {
            return await _user.Get();
        }

        [HttpGet]
        [Route("GetUserId")]
        public async Task<IActionResult> GetUserId(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var user = await _user.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }



        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser(User activeUser)
        {
            var result = await _user.Add(activeUser);
            return Ok();
        }

        [HttpPost]
        [Route("GenerateToken")]
        public async Task<IActionResult> LoginAction(User activeUser)
        {

            User user = await _user.LoginAction(activeUser);

            if (user == null)
            {
                return Unauthorized();
            }
            else
            {
                var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            new Claim("UserId", user.Id.ToString()),
            new Claim("DisplayName", user.Name),
            new Claim("UserName", user.Username),
            //new Claim("Email", user.Ema)
            };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: signIn);


                login activeLogin = new login();
                activeLogin.Id = user.Id;
                activeLogin.EmpId = user.EmployeeId;
                activeLogin.email = user.Username;
                activeLogin.RoleId = user.RoleId;
                activeLogin.displayName = "";
                activeLogin.expireDate = DateTime.Now;
                activeLogin.expiresIn = 3600;
                activeLogin.idToken = new JwtSecurityTokenHandler().WriteToken(token);
                activeLogin.kind = "identitytoolkit#VerifyPasswordResponse";
                activeLogin.localId = "qmt6dRyipIad8UCc0QpMV2MENSy1";
                activeLogin.refreshToken = "AMf-vBwy2wjTcg4ag7aw6fAA_lIALeaZwNM1Se71nGnnJcBcLGIWqSN6tq94mCh5Ep2osHmXjaB_Zzv_Gc2zScbha6A-AwhHysJ5x1KRBAv6h2bzIT3-7qek9EakEGKwCZb-ZhP5OY4qis6mXh8L1Wjzf747inl85clZfwYYIpiRzAQLNJ64QrAD7cB-WuVm7hMYrrgSm_qcsNPgF1MNZf3fS8xWKzbKYQ";
                activeLogin.registered = true;
                activeLogin.rolename = user.Rolename;
                activeLogin.name = user.Name;
                return Ok(activeLogin);
                //return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }

        }

        [HttpPost]
        [Route("UpdateUser")]
        public async Task<IActionResult> PutUser(User activeUser)
        {
            if (activeUser == null || activeUser.Id == 0)
            {
                return BadRequest();
            }

            await _user.Update(activeUser);
            return Ok();
        }

        [HttpPost]
        [Route("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int id, bool isDelete)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            await _user.Remove(id, isDelete);
            return Ok();
        }
    }
}
