using System;
using wkn.Evet.Abstractions;
using wkn.Evet.Abstractions.Core;

namespace wkn.Evet.Core
{
    public class Customer : DefPersistableObj<Customer>
    {
        public Customer(IRepository<Customer> cusRepo)
        {
            SetRepo(cusRepo);
        }

        public ICommandResult CreateCustomer()
        {
            return SaveState(this);
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
}