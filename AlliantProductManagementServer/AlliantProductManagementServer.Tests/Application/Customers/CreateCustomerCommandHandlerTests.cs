using AlliantProductManagementServer.Application.Features.Clients.Handlers;
using AlliantProductManagementServer.Domain.Entities.Customers;
using AlliantProductManagementServer.Domain.Exceptions;
using AlliantProductManagementServer.Domain.Repositories.Customers;
using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AlliantProductManagementServer.Tests.Application.Customers
{
    public class CreateCustomerCommandHandlerTests
    {
        private readonly Mock<ICustomerRepository> _customerRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly CreateCustomerHandler _handler;

        public CreateCustomerCommandHandlerTests()
        {
            _customerRepositoryMock = new Mock<ICustomerRepository>();
            _mapperMock = new Mock<IMapper>();
            _handler = new CreateCustomerHandler(_customerRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldThrowDomainException_WhenIdentificationAlreadyExists()
        {
            // Arrange
            var command = new CreateCustomerCommand
            {
                Name = "John Doe",
                PhoneNumber = "829990",
                Identification = "12345"
            };

            var existingCustomer = new Customer { Name = "Jane Doe", Identification = "12345" };

            _customerRepositoryMock.Setup(r => r.GetCustomerByIdentificationAsync(command.Identification))
                .ReturnsAsync(existingCustomer);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<DomainException>(() =>
                _handler.Handle(command, CancellationToken.None));

            Assert.Equal("The identification number is already registered", exception.Message);
            Assert.Equal((int)HttpStatusCode.Conflict, exception.ErrorCode);

            _customerRepositoryMock.Verify(r => r.GetCustomerByIdentificationAsync(command.Identification), Times.Once);
            _customerRepositoryMock.Verify(r => r.AddAsync(It.IsAny<Customer>()), Times.Never);
        }
    }
}
