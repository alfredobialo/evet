using Autofac;
using Autofac.Core;
using wkn.Evet.Abstractions.Core;

namespace wkn.Evet.Core
{
    public class DiSetup
    {
        public static IContainer InitDI()
        {
            ContainerBuilder builder  = new ContainerBuilder();
            builder.RegisterType<FakeCustomerCommandRepo>().As<ICommandRepository<Customer>>();
            builder.RegisterType<CustomerRepo>().As<IRepository<Customer>>();
            builder.RegisterType<Customer>();
            return builder.Build();
        }
    }
}