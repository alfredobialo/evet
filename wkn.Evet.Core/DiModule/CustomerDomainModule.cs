using Autofac;
using wkn.Evet.Abstractions.Core;

namespace wkn.Evet.Core.DiModule
{
    public class CustomerDomainModule  : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Customer>();
            builder.RegisterType<CustomerRepo>().As(typeof(IRepository<Customer>)).AsSelf();
            builder.RegisterType(typeof(FakeCustomerCommandRepo)).As(typeof(ICommandRepository<Customer>)).AsSelf();
        }
    }
}