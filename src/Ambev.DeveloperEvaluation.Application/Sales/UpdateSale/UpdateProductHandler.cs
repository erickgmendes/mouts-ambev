using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IBranchRepository _branchRepository;
    private readonly IMapper _mapper;

    public UpdateSaleHandler(
        ISaleRepository saleRepository,
        ICustomerRepository customerRepository,
        IBranchRepository branchRepository,
        IMapper mapper
        )
    {
        _saleRepository = saleRepository;
        _customerRepository = customerRepository;
        _branchRepository = branchRepository;
        _mapper = mapper;
    }

    public async Task<UpdateSaleResult> Handle(UpdateSaleCommand command, CancellationToken cancellationToken)
    {
        var sale = await _saleRepository.GetByIdAsync(command.Id, cancellationToken);
        
        if (sale == null)
            throw new Exception($"Sasle with ID {command.Id} not found");

        if (!command.CustomerId.HasValue) 
            throw new ArgumentException("CustomerId cannot be null");
        var customer = await _customerRepository.GetByIdAsync(command.CustomerId.Value, cancellationToken);
        if (customer == null) 
            throw new NullReferenceException($"Customer with ID {command.CustomerId} not found");
        
        if (!command.BranchId.HasValue) 
            throw new ArgumentException("BranchId cannot be null");
        var branch = await _branchRepository.GetByIdAsync(command.BranchId.Value, cancellationToken);
        if (branch == null) 
            throw new NullReferenceException($"Branch with ID {command.BranchId} not found");
        
        sale.Update(command.Number, command.Date, customer, branch, command.Status);

        await _saleRepository.UpdateAsync(sale, cancellationToken);

        return _mapper.Map<UpdateSaleResult>(sale);
    }
}