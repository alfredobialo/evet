using System.Collections.Generic;
using wkn.Evet.Abstractions.Core;

namespace wkn.Evet.Core
{
    public class FakeCustomerCommandRepo : ICommandRepository<Customer>
    {
       
        //Event raised
        public ICommandResult CreateObject(Customer obj)
        {
            // if create command was successful then raise the customer Created Event
            var res = new CommandResult(){Message = "Customer Created!", ExtraData = obj, Success = true};
            return res;
        }

        public ICommandResult DeleteObject(Customer obj)
        {
            throw new System.NotImplementedException();
        }

        public ICommandResult UpdateObject(Customer obj, ICriteria criteria)
        {
            throw new System.NotImplementedException();
        }

        public ICommandResult UpdateObject(Customer obj)
        {
            throw new System.NotImplementedException();
        }
    }

    public class CommandResult : ICommandResult
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public dynamic ExtraData { get; set; }
    }
}