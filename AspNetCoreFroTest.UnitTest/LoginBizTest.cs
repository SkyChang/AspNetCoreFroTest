using AspNetCoreFroTest.Web.Bll;
using AspNetCoreFroTest.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace AspNetCoreFroTest.UnitTest
{
    public class LoginBiz_Test
    {
        [Fact]
        public void Login_Test_Success()
        {
            var options = new DbContextOptionsBuilder<TestContext>()
               .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
               .Options;

            // Run the test against one instance of the context
            using (var context = new TestContext(options))
            {
                context.Customers.Add(new Customer(){ Name="sky", PW="123" });
                context.SaveChanges();

                var service = new LoginBiz(context);
                var result = service.Login("sky","123");
                Assert.True(result);
            }
        }

        [Fact]
        public void Login_Test_False()
        {
            var options = new DbContextOptionsBuilder<TestContext>()
               .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
               .Options;

            // Run the test against one instance of the context
            using (var context = new TestContext(options))
            {
                context.Customers.Add(new Customer() { Name = "sky", PW = "12345" });
                context.SaveChanges();

                var service = new LoginBiz(context);
                var result = service.Login("sky", "123");
                Assert.False(result);
            }
        }
    }
}
