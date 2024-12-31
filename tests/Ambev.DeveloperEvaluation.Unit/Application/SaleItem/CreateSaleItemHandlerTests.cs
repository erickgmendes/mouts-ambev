using System.Collections;
using Ambev.DeveloperEvaluation.Application.SaleItems.CreateSaleItem;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.SaleItem
{
    public class CreateSaleItemHandlerTests
    {
        private readonly ISaleItemRepository _saleItemRepository;
        private readonly ISaleRepository _saleRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly CreateSaleItemHandler _handler;

        public CreateSaleItemHandlerTests()
        {
            _saleItemRepository = Substitute.For<ISaleItemRepository>();
            _saleRepository = Substitute.For<ISaleRepository>();
            _productRepository = Substitute.For<IProductRepository>();
            _mapper = Substitute.For<IMapper>();
            _handler = new CreateSaleItemHandler(_saleItemRepository, _saleRepository, _productRepository, _mapper);
        }

        [Fact]
        public async Task Handle_ShouldThrowException_WhenSaleNotFound()
        {
            // Arrange
            var command = new CreateSaleItemCommand { SaleId = Guid.NewGuid(), ProductId = Guid.NewGuid(), Quantity = 5 };
            _saleRepository.GetByIdAsync(command.SaleId, CancellationToken.None).Returns((Sale)null);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_ShouldThrowException_WhenProductNotFound()
        {
            // Arrange
            var command = new CreateSaleItemCommand { SaleId = Guid.NewGuid(), ProductId = Guid.NewGuid(), Quantity = 5 };
            var sale = new Sale { Id = command.SaleId };
            _saleRepository.GetByIdAsync(command.SaleId, CancellationToken.None).Returns(sale);
            _productRepository.GetByIdAsync(command.ProductId, CancellationToken.None).Returns((Product)null);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_ShouldThrowValidationException_WhenCommandIsInvalid()
        {
            // Arrange
            var command = new CreateSaleItemCommand(); // Comando inválido
            var validator = Substitute.For<IValidator<CreateSaleItemCommand>>();
            validator.ValidateAsync(command, CancellationToken.None).Returns(new FluentValidation.Results.ValidationResult(new[] { new FluentValidation.Results.ValidationFailure("ProductId", "ProductId is required") }));

            var handlerWithValidator = new CreateSaleItemHandler(_saleItemRepository, _saleRepository, _productRepository, _mapper);

            // Act & Assert
            await Assert.ThrowsAsync<ValidationException>(() => handlerWithValidator.Handle(command, CancellationToken.None));
        }
    }
}
