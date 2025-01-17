using AlliantProductManagementServer.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlliantProductManagementServer.Tests.Persitence.Context
{
    public class DbContextTests
    {
        [Fact]
        public async Task DbContext_CanConnectToDatabase()
        {
            // Arrange: Configure DbContext options
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseNpgsql("Host=localhost;Port=5436;Database=alliant-db;Username=admin;Password=passowrd001")
                .Options;

            // Create the DbContext
            await using var context = new ApplicationContext(options);

            // Act & Assert: Check if the database can be connected
            var canConnect = await context.Database.CanConnectAsync();
            Assert.True(canConnect, "DbContext failed to connect to the database.");

        }
    }
}
