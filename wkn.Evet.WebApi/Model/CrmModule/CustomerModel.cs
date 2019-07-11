using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using wkn.Evet.WebApi.Controllers;
using wkn.Evet.WebApi.Model.Abstraction;

namespace wkn.Evet.WebApi.Model.CrmModule
{
    public class CustomerModel  : RestFulResource
    {
        
       
        public CustomerModel()
        {
           
        }

        public string FirstName { get; set; }
        public string  LastName { get; set; }
        public string Address { get; set; }

        public static Task<ApiResponse<IEnumerable<CustomerModel>>> GetCustomers(IUrlHelper linkGen)
        {
            ((List<CustomerModel>)FakeCustomerRepository.GetCustomerInfo()).ForEach((x) =>
                {
                    x.Urls["details"].Href = linkGen.Link(nameof(CustomersController.GetCustomer), new {id = x.Id});
                });
            ApiResponse<IEnumerable<CustomerModel>> res = new ApiResponse<IEnumerable<CustomerModel>>(FakeCustomerRepository.GetCustomerInfo());
            res.Message = "All Fake Customer Record loaded";
            res.Success = true;
            res.StatusCode = 200;
            return Task.FromResult(res);
        }

        public static Task<ApiResponse<CustomerDetailsModel>> GetCustomer(string id)
        {
            var res = new ApiResponse<CustomerDetailsModel>();
            res.Data = FakeCustomerRepository.GetCustomer(id);
            res.Success = res.Data != null;
            res.Message = "Customer Record Loaded";
            // Customer record should come with it's own specific Urls and deeper model representation
            return Task.FromResult(res);
        }
        
    }
}