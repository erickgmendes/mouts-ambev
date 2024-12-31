using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales
{
    public class DeleteSaleHandlerTests
    {
        private readonly ISaleRepository _saleRepository;
        private readonly DeleteSaleHandler _handler;

        public DeleteSaleHandlerTests()
        {
            _saleRepository = Substitute.For<ISaleRepository>();
            _handler = new DeleteSaleHandler(_saleRepository);
        }

        [Fact]
        public async Task Handle_ShouldThrowValidationException_WhenCommandIsInvalid()
        {
            // Arrange
            var command = new DeleteSaleCommand(Guid.NewGuid()); 
            var validator = Substitute.For<IValidator<DeleteSaleCommand>>();
            validator.ValidateAsync(command, CancellationToken.None).Returns(new FluentValidation.Results.ValidationResult
            {
                Errors = { new FluentValidation.Results.ValidationFailure("Property", "Error") }
            });

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_ShouldThrowKeyNotFoundException_WhenSaleNotFound()
        {
            // Arrange
            var command = new DeleteSaleCommand(Guid.NewGuid());
            _saleRepository.DeleteAsync(command.Id, CancellationToken.None).Returns(false);

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_ShouldReturnDeleteSaleResponse_WhenSaleIsDeletedSuccessfully()
        {
            // Arrange
            var command = new DeleteSaleCommand(Guid.NewGuid());
            _saleRepository.DeleteAsync(command.Id, CancellationToken.None).Returns(true);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Success);
            await _saleRepository.Received(1).DeleteAsync(command.Id, CancellationToken.None);
        }

        [Fact]
        public async Task Handle_ShouldThrowKeyNotFoundException_WhenDeleteFails()
        {
            // Arrange
            var command = new DeleteSaleCommand(Guid.NewGuid());
            _saleRepository.DeleteAsync(command.Id, CancellationToken.None).Returns(false);

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}
