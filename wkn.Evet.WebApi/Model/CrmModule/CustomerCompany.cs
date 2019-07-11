

using wkn.Evet.WebApi.Model.Abstraction;

namespace wkn.Evet.WebApi.Model.CrmModule
{
    public class CustomerCompany : RestFulResource
    {
        public CustomerCompany()
        {
            
        }

        public string Name { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string  ContactAddress { get; set; }
        
    }
}