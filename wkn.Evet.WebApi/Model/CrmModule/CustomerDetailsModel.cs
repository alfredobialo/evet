using System.Collections.Generic;
using wkn.Evet.WebApi.Model.SalesModule;

namespace wkn.Evet.WebApi.Model.CrmModule
{
    public class CustomerDetailsModel : CustomerModel
    {
        public CustomerCompany  CustomerCompany { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; } = "";
        public IList<SalesTransactionHistory> TransactionHistory { get; set; }


        public static CustomerDetailsModel From(CustomerModel cus)
        {
            CustomerDetailsModel res  =  new CustomerDetailsModel()
            {
                 Address = cus.Address,
                 Id = cus.Id,
                 FirstName = cus.FirstName,
                 LastName = cus.LastName,
                 Urls = cus.Urls
            };
            return res;
        }
    }
}