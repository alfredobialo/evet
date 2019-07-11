using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wkn.Evet.WebApi.Model;
using wkn.Evet.WebApi.Model.Abstraction;
using wkn.Evet.WebApi.Model.CrmModule;

namespace wkn.Evet.WebApi.Controllers
{
    [Route("/")]
    [ApiController]
    public class RootApiController : BaseController
    {
        // GET api/values
        [HttpGet(Name=nameof(Get))]
        public IActionResult Get()
        {
            
            var res = new
            {
                crm  = Url.Link(nameof(CustomersController.GetCustomers), null),
                auth = Url.Link(nameof(AuthController.GetUrls), null),
                appName ="Business Application"
            };

            return Ok(res);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}