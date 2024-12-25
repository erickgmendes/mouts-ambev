using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customers.CreateCustomers;

public class CreateCustomerHandler: IRequestHandler<CreateCustomerCommand, CreateCustomerResult>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of CreateCustomerHandler
    /// </summary>
    /// <param name="customerRepository">The customer repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for CreateCustomerCommand</param>
    public CreateCustomerHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the CreateCustomerCommand request
    /// </summary>
    /// <param name="command">The CreateCustomer command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created customer details</returns>
    public async Task<CreateCustomerResult> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateCustomerCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var existingCustomer = await _customerRepository.GetByExternalIdAsync(command.ExternalId, cancellationToken);
        if (existingCustomer != null)
            throw new InvalidOperationException($"Customer with external Id {command.ExternalId} already exists");

        var customer = _mapper.Map<Customer>(command);
        var createdCustomer = await _customerRepository.CreateAsync(customer, cancellationToken);
        var result = _mapper.Map<CreateCustomerResult>(createdCustomer);
        return result;
    }
}