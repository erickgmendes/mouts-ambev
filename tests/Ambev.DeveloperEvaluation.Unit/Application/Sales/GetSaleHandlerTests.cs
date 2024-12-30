using Ambev.DeveloperEvaluation.Application.SaleItems.GetSaleItem;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales
{
    public class GetSaleHandlerTests
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;
        private readonly GetSaleHandler _handler;

        public GetSaleHandlerTests()
        {
            _saleRepository = Substitute.For<ISaleRepository>();
            _mapper = Substitute.For<IMapper>();
            _handler = new GetSaleHandler(_saleRepository, _mapper);
        }

        [Fact]
        public async Task Handle_ShouldThrowValidationException_WhenCommandIsInvalid()
        {
            // Arrange
            var command = new GetSaleCommand(Guid.NewGuid());
            var validator = Substitute.For<IValidator<GetSaleCommand>>();
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
            var command = new GetSaleCommand(Guid.NewGuid());
            _saleRepository.GetByIdAsync(command.Id, CancellationToken.None).Returns((Sale)null); // Simulando venda não encontrada

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_ShouldReturnSaleDetails_WhenSaleIsFound()
        {
            // Arrange
            var command = new GetSaleCommand(Guid.NewGuid());
            var sale = new Sale
            {
                Id = (Guid.NewGuid()),
                Items = new List<SaleItem>
                {
                    new SaleItem { Product = new Product(){Id = Guid.NewGuid()}, Quantity = 5 },
                    new SaleItem { Product = new Product(){Id = Guid.NewGuid()}, Quantity = 15 },
                    new SaleItem { Product = new Product(){Id = Guid.NewGuid()}, Quantity = 10 }
                }
            };
            _saleRepository.GetByIdAsync(command.Id, CancellationToken.None).Returns(sale);

            var saleResult = new GetSaleResult
            {
                Items = sale.Items.Select(item => new GetSaleItemResult
                {
                    ProductId = item.Product.Id,
                    Quantity = item.Quantity,
                    TotalAmount = item.TotalAmount
                }).ToList()
            };
            _mapper.Map<GetSaleResult>(sale).Returns(saleResult);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Items.Count);
        }
        
    }
}
