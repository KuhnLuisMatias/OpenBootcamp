using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using OpenBootcamp.Entities;

namespace OpenBootcamp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly IStringLocalizer<PostController> _stringLocalizer;
        private readonly IStringLocalizer<SharedResource> _sharedResourceLocalizer;

        public PostController(IStringLocalizer<PostController> stringLocalizer, IStringLocalizer<SharedResource> sharedResourceLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _sharedResourceLocalizer = sharedResourceLocalizer;
        }

        [HttpGet]
        [Route("PostControllerResource")]
        public IActionResult GetUsingPostControllerResource()
        {
            var article = _stringLocalizer["Article"];
            var postName = _stringLocalizer.GetString("Welcome").Value ?? string.Empty;

            return Ok(new
            {
                PostType = article.Value,
                PostName = postName,
            });
        }

        [HttpGet]
        [Route("SharedResource")]
        public IActionResult GetUsingSharedResource()
        {
            var article = _stringLocalizer["Article"];
            var postName = _stringLocalizer.GetString("Welcome").Value ?? String.Empty;
            var message = _sharedResourceLocalizer.GetString("TodayIs");
            var todayIs = string.Format(message, DateTime.Now.ToLongDateString());
            return Ok(new
            {
                PostType = article.Value,
                PostName = postName,
                TodayIs = todayIs,
            });
        }
    }
}
