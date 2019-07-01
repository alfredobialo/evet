using System;
using Autofac;
using wkn.Evet.Abstractions.Core;
using wkn.Evet.Core;
using Xunit;
using Xunit.Abstractions;

namespace wkn.Evet.Test
{
    public class CustomerCoreDomainTest
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public CustomerCoreDomainTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void Test1()
        {
            //sut
            //arrange
            IContainer container = DiSetup.InitDI();
            Customer c = container.Resolve<Customer>(); //new Customer(new CustomerRepo());
            c.FirstName = "Alfred";
            c.LastName = "Obialo";
            c.Address = "Nekede Owerri!";
            c.Id = "alfredObialo";
            // act
            var res = c.CreateCustomer();
            _testOutputHelper.WriteLine(res.Message);
            _testOutputHelper.WriteLine(res.ExtraData.FirstName);
            // assert
            Assert.IsAssignableFrom<ICommandResult>(res);
            Assert.NotNull(res.ExtraData);
            Assert.IsAssignableFrom<IPersistableObj<Customer>>(c);
            Assert.IsType<Customer>(res.ExtraData);
            Assert.NotNull(c.DataSource);
            Assert.IsAssignableFrom<ICommandRepository<Customer>>( c.DataSource.CommandRepository);
            Assert.Equal(c , res.ExtraData);
            Assert.True(res.Success);

        }
    }
}