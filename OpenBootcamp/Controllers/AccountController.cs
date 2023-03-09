using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenBootcamp.DataAccess;
using OpenBootcamp.Helpers;
using OpenBootcamp.Models.DataModels;

namespace OpenBootcamp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;
        private readonly UniversityDBContext _context;

        public AccountController(UniversityDBContext context, JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
            _context = context;
        }

        private IEnumerable<User> Logins = new List<User>()
        {
            new User()
            {
                Id = 1,
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

                var searchUser = (from user in _context.Users
                                  where user.Name == userLogin.UserName
                                  && user.Password == userLogin.Password
                                  select user).FirstOrDefault();

                //var Valid = Logins.Any(user => user.Name.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));
                //if (Valid)
                if(searchUser != null)
                {
                   // var user = Logins.FirstOrDefault(user => user.Name.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));

                    Token = JwtHelpers.GenTokenKey(new UserTokens()
                    {
                        UserName = searchUser.Name,
                        EmailId = searchUser.Email,
                        Id = searchUser.Id,
                        GuidId = Guid.NewGuid(),
                        rol = searchUser.rol
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

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador,User")]
        public IActionResult GetUserList()
        {
            return Ok(Logins);
        }

    }
}
