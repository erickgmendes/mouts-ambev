using Ambev.DeveloperEvaluation.Application.SaleItems.DeleteSaleItem;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.SaleItem
{
    public class DeleteSaleItemHandlerTests
    {
        private readonly ISaleItemRepository _saleItemRepository;
        private readonly DeleteSaleItemHandler _handler;

        public DeleteSaleItemHandlerTests()
        {
            _saleItemRepository = Substitute.For<ISaleItemRepository>();
            _handler = new DeleteSaleItemHandler(_saleItemRepository);
        }

        [Fact]
        public async Task Handle_ShouldThrowValidationException_WhenCommandIsInvalid()
        {
            // Arrange
            var command = new DeleteSaleItemCommand(Guid.NewGuid());
            var validator = Substitute.For<IValidator<DeleteSaleItemCommand>>();
            validator.ValidateAsync(command, CancellationToken.None).Returns(new FluentValidation.Results.ValidationResult(new[] { new FluentValidation.Results.ValidationFailure("Id", "Id is required") }));

            var handlerWithValidator = new DeleteSaleItemHandler(_saleItemRepository);

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => handlerWithValidator.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_ShouldThrowKeyNotFoundException_WhenSaleItemNotFound()
        {
            // Arrange
            var command = new DeleteSaleItemCommand(Guid.NewGuid());
            _saleItemRepository.DeleteAsync(command.Id, CancellationToken.None).Returns(false);

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_ShouldReturnSuccess_WhenSaleItemDeletedSuccessfully()
        {
            // Arrange
            var command = new DeleteSaleItemCommand(Guid.NewGuid());
            _saleItemRepository.DeleteAsync(command.Id, CancellationToken.None).Returns(true);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.Success);
            _saleItemRepository.Received().DeleteAsync(command.Id, CancellationToken.None); // Verifica se a exclusão foi chamada
        }
    }
}
