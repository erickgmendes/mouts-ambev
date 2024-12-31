using Ambev.DeveloperEvaluation.Application.SaleItems.CancelSaleItem;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.SaleItem
{
    public class UpdateSaleItemHandlerTests
    {
        private readonly ISaleItemRepository _saleItemRepository;
        private readonly IMapper _mapper;
        private readonly UpdateSaleItemHandler _handler;

        public UpdateSaleItemHandlerTests()
        {
            _saleItemRepository = Substitute.For<ISaleItemRepository>();
            _mapper = Substitute.For<IMapper>();
            _handler = new UpdateSaleItemHandler(_saleItemRepository, _mapper);
        }

        [Fact]
        public async Task Handle_ShouldThrowException_WhenSaleItemNotFound()
        {
            // Arrange
            var command = new CancelSaleItemCommand(Guid.NewGuid());
            _saleItemRepository.GetByIdAsync(command.Id, CancellationToken.None).Returns((DeveloperEvaluation.Domain.Entities.SaleItem)null);

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_ShouldThrowException_WhenSaleItemAlreadyCancelled()
        {
            // Arrange
            var command = new CancelSaleItemCommand(Guid.NewGuid());
            var saleItem = new DeveloperEvaluation.Domain.Entities.SaleItem { Id = Guid.NewGuid() };
            saleItem.Cancel();
            _saleItemRepository.GetByIdAsync(command.Id, CancellationToken.None).Returns(saleItem);

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_ShouldReturnSuccess_WhenSaleItemIsCancelledSuccessfully()
        {
            // Arrange
            var command = new CancelSaleItemCommand(Guid.NewGuid());
            var saleItem = new DeveloperEvaluation.Domain.Entities.SaleItem { Id = Guid.NewGuid() };
            _saleItemRepository.GetByIdAsync(command.Id, CancellationToken.None).Returns(saleItem);

            _saleItemRepository.UpdateAsync(Arg.Any<DeveloperEvaluation.Domain.Entities.SaleItem>(), CancellationToken.None).Returns(saleItem);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.Success);
            _saleItemRepository.Received().UpdateAsync(saleItem, CancellationToken.None); // Verifica se o repositório foi chamado para atualizar o item de venda
        }

        [Fact]
        public async Task Handle_ShouldThrowValidationException_WhenCommandIsInvalid()
        {
            // Arrange
            var command = new CancelSaleItemCommand(Guid.NewGuid());
            var validator = Substitute.For<IValidator<CancelSaleItemCommand>>();
            validator.ValidateAsync(command, CancellationToken.None).Returns(new FluentValidation.Results.ValidationResult(new[] { new FluentValidation.Results.ValidationFailure("Id", "Id is required") }));

            var handlerWithValidator = new UpdateSaleItemHandler(_saleItemRepository, _mapper);

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => handlerWithValidator.Handle(command, CancellationToken.None));
        }
    }
}
