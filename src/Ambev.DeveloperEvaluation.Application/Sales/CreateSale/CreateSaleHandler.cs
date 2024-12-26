using Ambev.DeveloperEvaluation.Domain.Entities;
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
        var validator = new CreateSaleCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var existingSale = await _saleRepository.GetByNumberAsync(command.Number, cancellationToken);
        if (existingSale != null)
            throw new InvalidOperationException($"Sale with external Id {command.Number} already exists");

        var sale = _mapper.Map<Sale>(command);
        
        var customer = _customerRepository.GetByIdAsync(command.CustomerId.Value, cancellationToken);
        sale.SetCustomer(customer.Result);
        
        var branch = _branchRepository.GetByIdAsync(command.BranchId.Value, cancellationToken);
        sale.SetBranch(branch.Result);
        
        var createdSale = await _saleRepository.CreateAsync(sale, cancellationToken);
        var result = _mapper.Map<CreateSaleResult>(createdSale);
        return result;
    }
}