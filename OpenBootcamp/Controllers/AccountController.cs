using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenBootcamp.Helpers;
using OpenBootcamp.Models.DataModels;

namespace OpenBootcamp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;

        public AccountController(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        private IEnumerable<User> Logins = new List<User>()
        {
            new User()
            {
                Id =1,
                Email= "test@test.com",
                Name= "Admin",
                Password = "Admin"
            },
            new User()
            {
                Id =2,
                Email="test2@test2.com",
                Name="User1",
                Password="pepe"
            }
        };

        [HttpPost]
        public IActionResult GetToken(UserLogins userLogin)
        {
            try
            {
                var Token = new UserTokens();
                var Valid = Logins.Any(user => user.Name.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));
                if (Valid)
                {
                    var user = Logins.FirstOrDefault(user => user.Name.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));

                    Token = JwtHelpers.GenTokenKey(new UserTokens()
                    {
                        UserName = user.Name,
                        EmailId = user.Email,
                        Id = user.Id,
                        GuidId = Guid.NewGuid(),
                    }, _jwtSettings);
                }
                else
                    return BadRequest("Wrong Password");
                return Ok(Token);
            }
            catch (Exception ex)
            {
                throw new Exception("GetToken Error", ex);
            }
        }
    }
}
