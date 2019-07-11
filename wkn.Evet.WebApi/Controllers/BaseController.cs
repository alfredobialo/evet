using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace wkn.Evet.WebApi.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        public IActionResult NotFoundMessage(string msg = "The record you are looking for could not be found.", object values = null)
        {
            return NotFound(new
            {
                Message = msg,
                StatusCode = HttpStatusCode.NotFound,
                Params = values

            });
        }
    }
}