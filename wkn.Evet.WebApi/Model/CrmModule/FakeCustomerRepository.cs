using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using wkn.Evet.WebApi.Model.Abstraction;
using wkn.Evet.WebApi.Model.SalesModule;

namespace wkn.Evet.WebApi.Model.CrmModule
{
    public class FakeCustomerRepository
    {
        private static List<CustomerModel> fakeCustomerDb = new List<CustomerModel>()
        {
            new CustomerModel()
            {
                Id = "crm-001", Address = "12 Main street lagos",
                FirstName = "James",
                LastName = "Chadwick",
                Urls = new Dictionary<string, Link>()
                {
                    {
                        "details",
                        new Link()
                        {
                            Href = "not assigned yet",
                            Rel = "self",
                            Method = "customer-details"
                        }
                    }
                }
            },
            new CustomerModel()
            {
                Id = "crm-002", Address = "12B Yaba street lagos",
                FirstName = "Felicia",
                LastName = "James",
                Urls = new Dictionary<string, Link>()
                {
                    {
                        "details",
                        new Link()
                        {
                            Href = $"not assigned yet",
                            Rel = "self",
                            Method = "customer-details"
                        }
                    }
                }
            },
        };

        public static IEnumerable<CustomerModel> GetCustomerInfo()
        {
            return fakeCustomerDb;
        }

        public static CustomerDetailsModel GetCustomer(string id)
        {
            var cus = GetCustomerInfo().FirstOrDefault(x => x.Id == id);
            CustomerDetailsModel res = CustomerDetailsModel.From(cus);
            res.CustomerCompany =  new CustomerCompany()
            {
                Email = $"cus{new Random().Next(1,10)}@company.com",
                Id = $"company{id}",
                Name = $"{res.FirstName} Company",
                Urls = new Dictionary<string, Link>
                {
                    {"details" , new Link
                    {
                        Href = "Route Link here" , 
                         Rel = "self"
                    }}
                }
            };
            res.Gender = new Random().Next(1,3) > 2 ? "MALE" : "FEMALE";
            res.TransactionHistory  = new List<SalesTransactionHistory>()
            {
                new SalesTransactionHistory()
                {
                    Status = "APPROVED",
                    Total = 4500,
                    InvoiceDate = DateTime.UtcNow.AddDays(-8),
                    InvoiceNo = "INV-0023",
                    PaymentStatus = "INCOMPLETE"
                }
            };
            return res;
        }
    }
}