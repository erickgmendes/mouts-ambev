using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleHandler: IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IBranchRepository _branchRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of CreateSaleHandler
    /// </summary>
    /// <param name="saleRepository">The sale repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for CreateSaleCommand</param>
    public CreateSaleHandler(
        ISaleRepository saleRepository,
        ICustomerRepository customerRepository,
        IBranchRepository branchRepository,
        IMapper mapper)
    {
        _saleRepository = saleRepository;
        _customerRepository = customerRepository;
        _branchRepository = branchRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the CreateSaleCommand request
    /// </summary>
    /// <param name="command">The CreateSale command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sale details</returns>
    public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        if (command == null)
            throw new ValidationException("Command cannot be null.");
        
        var validator = new CreateSaleCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var existingSale = await _saleRepository.GetByNumberAsync(command.Number, cancellationToken);
        if (existingSale != null)
            throw new InvalidOperationException($"Sale with external Id {command.Number} already exists");

        var sale = _mapper.Map<Sale>(command);

        if (!command.CustomerId.HasValue) 
            throw new ArgumentException("CustomerId cannot be null");
        sale.SetCustomer(_customerRepository.GetByIdAsync(command.CustomerId.Value, cancellationToken).Result);
        
        if (!command.BranchId.HasValue) 
            throw new ArgumentException("BranchId cannot be null");
        sale.SetBranch(_branchRepository.GetByIdAsync(command.BranchId.Value, cancellationToken).Result);

        if (!command.Status.HasValue) 
            throw new ArgumentException("Status cannot be null");
        sale.SetStatus(command.Status);
        
        var createdSale = await _saleRepository.CreateAsync(sale, cancellationToken);
        return _mapper.Map<CreateSaleResult>(createdSale);
    }
}