using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales
{
    public class UpdateSaleHandlerTests
    {
        private readonly ISaleRepository _saleRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IBranchRepository _branchRepository;
        private readonly IMapper _mapper;
        private readonly UpdateSaleHandler _handler;

        public UpdateSaleHandlerTests()
        {
            _saleRepository = Substitute.For<ISaleRepository>();
            _customerRepository = Substitute.For<ICustomerRepository>();
            _branchRepository = Substitute.For<IBranchRepository>();
            _mapper = Substitute.For<IMapper>();
            _handler = new UpdateSaleHandler(_saleRepository, _customerRepository, _branchRepository, _mapper);
        }

        [Fact]
        public async Task Handle_ShouldThrowException_WhenSaleNotFound()
        {
            // Arrange
            var command = new UpdateSaleCommand { Id = Guid.NewGuid() };
            _saleRepository.GetByIdAsync(command.Id, CancellationToken.None).Returns((Sale)null);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_ShouldThrowArgumentException_WhenCustomerIdIsNull()
        {
            // Arrange
            var command = new UpdateSaleCommand { Id = Guid.NewGuid(), CustomerId = null };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_ShouldThrowNullReferenceException_WhenCustomerNotFound()
        {
            // Arrange
            var command = new UpdateSaleCommand { Id = Guid.NewGuid(), CustomerId = Guid.NewGuid() };
            _saleRepository.GetByIdAsync(command.Id, CancellationToken.None).Returns(new Sale());
            _customerRepository.GetByIdAsync(command.CustomerId.Value, CancellationToken.None).Returns((Customer)null);

            // Act & Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_ShouldThrowArgumentException_WhenBranchIdIsNull()
        {
            // Arrange
            var command = new UpdateSaleCommand { Id = Guid.NewGuid(), BranchId = null };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_ShouldThrowNullReferenceException_WhenBranchNotFound()
        {
            // Arrange
            var command = new UpdateSaleCommand { Id = Guid.NewGuid(), BranchId = Guid.NewGuid() };
            _saleRepository.GetByIdAsync(command.Id, CancellationToken.None).Returns(new Sale());
            _branchRepository.GetByIdAsync(command.BranchId.Value, CancellationToken.None).Returns((Branch)null);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _handler.Handle(command, CancellationToken.None));
        }

    }
}
