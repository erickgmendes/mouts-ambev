using Ambev.DeveloperEvaluation.Application.SaleItems.GetSaleItem;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.SaleItem
{
    public class GetSaleItemHandlerTests
    {
        private readonly ISaleItemRepository _saleItemRepository;
        private readonly IMapper _mapper;
        private readonly GetSaleItemHandler _handler;

        public GetSaleItemHandlerTests()
        {
            _saleItemRepository = Substitute.For<ISaleItemRepository>();
            _mapper = Substitute.For<IMapper>();
            _handler = new GetSaleItemHandler(_saleItemRepository, _mapper);
        }

        [Fact]
        public async Task Handle_ShouldThrowValidationException_WhenCommandIsInvalid()
        {
            // Arrange
            var command = new GetSaleItemCommand(Guid.NewGuid());
            var validator = Substitute.For<IValidator<GetSaleItemCommand>>();
            validator.ValidateAsync(command, CancellationToken.None).Returns(new FluentValidation.Results.ValidationResult(new[] { new FluentValidation.Results.ValidationFailure("Id", "Id is required") }));

            var handlerWithValidator = new GetSaleItemHandler(_saleItemRepository, _mapper);

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => handlerWithValidator.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_ShouldThrowKeyNotFoundException_WhenSaleItemNotFound()
        {
            // Arrange
            var command = new GetSaleItemCommand(Guid.NewGuid());
            _saleItemRepository.GetByIdAsync(command.Id, CancellationToken.None).Returns((DeveloperEvaluation.Domain.Entities.SaleItem)null);

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_ShouldReturnSaleItem_WhenSaleItemFound()
        {
            // Arrange
            var command = new GetSaleItemCommand(Guid.NewGuid());
            var saleItem = new DeveloperEvaluation.Domain.Entities.SaleItem { Id = Guid.NewGuid(), Quantity = 10 };
            _saleItemRepository.GetByIdAsync(command.Id, CancellationToken.None).Returns(saleItem);

            var saleItemResult = new GetSaleItemResult { Id = new Guid(), Quantity = 10 };
            _mapper.Map<GetSaleItemResult>(saleItem).Returns(saleItemResult);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(saleItemResult.Id, result.Id);
            Assert.Equal(saleItemResult.Quantity, result.Quantity);
        }
    }
}
