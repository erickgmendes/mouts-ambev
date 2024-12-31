using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales;

/// <summary>
/// Contains unit tests for the <see cref="CreateSaleHandler"/> class.
/// </summary>
public class CreateSaleHandlerTests
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly ICustomerRepository _customerRepository;
    private readonly IBranchRepository _branchRepository;
    private readonly CreateSaleHandler _handler;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateUserHandlerTests"/> class.
    /// Sets up the test dependencies and creates fake data generators.
    /// </summary>
    public CreateSaleHandlerTests()
    {
        _saleRepository = Substitute.For<ISaleRepository>();
        _customerRepository = Substitute.For<ICustomerRepository>();
        _branchRepository = Substitute.For<IBranchRepository>();
        _mapper = Substitute.For<IMapper>();
        _handler = new CreateSaleHandler(_saleRepository, _customerRepository, _branchRepository, _mapper);
    }

    [Fact]
    public async Task Handle_ShouldThrowValidationException_WhenCommandIsNull()
    {
        // Arrange
        CreateSaleCommand command = null;

        // Act & Assert
        await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(command, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_ShouldThrowValidationException_WhenCommandIsInvalid()
    {
        // Arrange
        var command = new CreateSaleCommand(); 
        var validator = Substitute.For<IValidator<CreateSaleCommand>>();
        validator.ValidateAsync(command, CancellationToken.None).Returns(new FluentValidation.Results.ValidationResult
        {
            Errors = { new FluentValidation.Results.ValidationFailure("Property", "Error") }
        });

        _ = _handler.Handle(command, CancellationToken.None);

        // Act & Assert
        await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(command, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_ShouldThrowInvalidOperationException_WhenSaleAlreadyExists() 
    {
        // Arrange
        var command = new CreateSaleCommand { Number = "12345" };
        _saleRepository.GetByNumberAsync(command.Number, CancellationToken.None).Returns(new Sale());

        // Act & Assert
        await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(command, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_ShouldThrowArgumentException_WhenCustomerIdIsNull()
    {
        // Arrange
        var command = new CreateSaleCommand { CustomerId = null };

        // Act & Assert
        await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(command, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_ShouldThrowNullReferenceException_WhenCustomerNotFound()
    {
        // Arrange
        var command = new CreateSaleCommand { CustomerId = Guid.NewGuid() };
        _customerRepository.GetByIdAsync(command.CustomerId.Value, CancellationToken.None).Returns((Customer)null);

        // Act & Assert
        await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(command, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_ShouldThrowArgumentException_WhenBranchIdIsNull()
    {
        // Arrange
        var command = new CreateSaleCommand { BranchId = null };

        // Act & Assert
        await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(command, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_ShouldThrowNullReferenceException_WhenBranchNotFound()
    {
        // Arrange
        var command = new CreateSaleCommand { BranchId = Guid.NewGuid() };
        _branchRepository.GetByIdAsync(command.BranchId.Value, CancellationToken.None).Returns((Branch)null);

        // Act & Assert
        await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(command, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_ShouldReturnCreateSaleResult_WhenSaleIsSuccessfullyCreated()
    {
        // Arrange
        var command = new CreateSaleCommand
        {
            Number = "12345",
            CustomerId = Guid.NewGuid(),
            BranchId = Guid.NewGuid(),
            Date = DateTime.Now
        };

        var sale = new Sale();
        var customer = new Customer();
        var branch = new Branch();
        var createdSale = new Sale();

        _saleRepository.GetByNumberAsync(command.Number, CancellationToken.None).Returns((Sale)null);
        _customerRepository.GetByIdAsync(command.CustomerId.Value, CancellationToken.None).Returns(customer);
        _branchRepository.GetByIdAsync(command.BranchId.Value, CancellationToken.None).Returns(branch);
        _mapper.Map<Sale>(command).Returns(sale);
        _saleRepository.CreateAsync(sale, CancellationToken.None).Returns(createdSale);
        _mapper.Map<CreateSaleResult>(createdSale).Returns(new CreateSaleResult());

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        await _saleRepository.Received(1).CreateAsync(Arg.Any<Sale>(), CancellationToken.None);
    }
}