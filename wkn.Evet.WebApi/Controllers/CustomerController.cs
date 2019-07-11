using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using wkn.Evet.WebApi.Model;
using wkn.Evet.WebApi.Model.CrmModule;

namespace wkn.Evet.WebApi.Controllers
{
    [ApiController]
    [Produces(typeof(CustomerModel))]
    [ProducesResponseType(typeof(CustomerModel),200)]
    [Route("api/[controller]")]
    public class CustomersController   :BaseController
    {
        [HttpGet(Name = nameof(GetCustomers))]
        public async Task<IActionResult> GetCustomers()
        {
            // return all customers
            // for demo purposes we will return a collection of fake customer record
            // Pass in  a Link Generator Test 1 : to the get Customer record
            
            // we need a delegate that accepts a Url.Link generator and return a string
            //Func<UrlHelper, string> linkGen = helper => { return helper.Link(nameof(GetCustomer), new {id = "abcd"}); }; 
            ApiResponse<IEnumerable<CustomerModel>> res = await CustomerModel.GetCustomers(Url);
            res.RootHref = Url.Link(nameof(RootApiController.Get), null);
            return Ok(res);
        }

        [HttpGet("{id}", Name = nameof(GetCustomer))]
        public async Task<IActionResult> GetCustomer(string id)
        {
            var res = await CustomerModel.GetCustomer(id);
            res.RootHref = Url.Link(nameof(GetCustomers), null);
            if (res.Success)
            {
                return Ok(res);
            }
            return NotFoundMessage(values:new {id});
        }

        
        [HttpPost(Name=nameof(CreateCustomer))]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerModel customer)
        {
            return Ok(customer);
        }
        
        
        
    }
}