using wkn.Evet.Abstractions.Core;

namespace wkn.Evet.Core
{
    public class CustomerRepo : IRepository<Customer>
    {
        public CustomerRepo(ICommandRepository<Customer> customerCmd)
        {
            // should be injected thru a DI framework
            CommandRepository = customerCmd; //  FakeCustomerCommandRepo();
        }
        public ICommandRepository<Customer> CommandRepository { get; }
        public IQueryRepository<Customer> QueryRepository { get; }
    }
}