using AlliantProductManagementServer.Domain.Entities.Customers;
using AlliantProductManagementServer.Persistence.Contexts;
using AlliantProductManagementServer.Persistence.Repositories.Customers;
using Microsoft.EntityFrameworkCore;

namespace AlliantProductManagementServer.Tests.Persitence.Repositories.Customers
{
    public class CustomersRepositoryTests
    {
        [Fact]
        public async Task TestCustomerCreation()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase("TestDatabase")
                .Options;

            await using var context = new ApplicationContext(options);

            var customerRepository = new CustomerRepository(context);

            var customer = await customerRepository.AddAsync(new Customer
            {
                Name = "Alam",
                LastName = "Mena",
                PhoneNumber = "829-794-8271",
                Identification = "401-1389763-6"
            });

            var entityCount = await context.Customers.CountAsync();

            Assert.Equal(1, entityCount);
        }
    }
}
