using CustomerAPIv1.Controllers;
using CustomerAPIv1.Data;
using CustomerAPIv1.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Moq;


namespace CustomerAPIv1.Test
{
    public class CustomerControllerTests
    {
        private CustomerDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<CustomerDbContext>()
                .UseInMemoryDatabase("TestDatabase")
                .Options;

            return new CustomerDbContext(options);
        }

        [Fact]
        public async Task GetCustomer_Returns_Customer_WhenExists()
        {
            // Arrange
            var context = GetDbContext();
            var customer = new Customer { Id = Guid.NewGuid(), FirstName = "sheethal", LastName = "Lloyd" };
            context.Customers.Add(customer);
            await context.SaveChangesAsync();

            var controller = new CustomerController(context);

            // Act
            var result = await controller.GetCustomer(customer.Id) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.IsType<Customer>(result.Value);
        }

        [Fact]
        public void TestCustomerCreation()
        {
            var customer = new Customer { FirstName = "sheethal", LastName = "Lloyd" };
            Assert.NotNull(customer);
        }
    }
}
