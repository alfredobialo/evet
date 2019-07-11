using Microsoft.AspNetCore.Mvc;
using wkn.Evet.WebApi.Model.Abstraction;
using wkn.Evet.WebApi.Model.Auth;

namespace wkn.Evet.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : BaseController
    {
        [HttpPost("/login", Name = nameof(Login))]
        // Represent Authentication Features : Login , Password recorvery, Registration
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                return Ok(loginModel);
            }
            else
            {
                return UnprocessableEntity(ModelState);
            }
            
        }

        [HttpGet( Name = nameof(GetUrls))]
        public IActionResult GetUrls()
        {
            var urls = new
            {
                login = new
                {
                    url = new Link()
                    {
                        Href = Url.Link(nameof(Login), null),
                        Method = "POST",
                        Rel = "form"
                    },
                    model = new
                    {
                        UserId  = new  { required = true, type = nameof(System.String), name=nameof(LoginModel.UserId)},
                        Password  = new  { secret=true ,required = true, type = nameof(System.String), name=nameof(LoginModel.Password)},
                        Remember  = new  { required = false, type = nameof(System.Boolean), name=nameof(LoginModel.RememberPassword)}
                    }
                },
                rootApi = Url.Link(nameof(RootApiController.Get), null)
            };
            return Ok(urls);
        }
    }
}