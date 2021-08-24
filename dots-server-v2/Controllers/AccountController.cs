using System.Threading.Tasks;
using dots_server_v2.Data;
using dots_server_v2.RequestModels;
using dots_server_v2.ResponseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dots_server_v2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly DotsContext _context;

        public AccountController(DotsContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginRequest requestModel)
        {
            var passHash = Helpers.GetHash(requestModel.Password);
            var user = await _context.Users.AsNoTracking()
                .FirstOrDefaultAsync(u => u.UserName == requestModel.Username && u.PasswordHash == passHash);
            if (user == null)
            {
                return Unauthorized();
            }

            var token = Helpers.GetJwt(user);
            return Ok(new LoginResponse
            {
                UserName = user.UserName,
                Email = user.Email,
                Token = token
            });
        }

        [HttpGet("test")]
        [Authorize]
        public ActionResult TestAuth()
        {
            return Ok();
        }
    }
}