using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customers.UpdateCustomer;

public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, UpdateCustomerResult>
{
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;

    public UpdateCustomerHandler(ICustomerRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<UpdateCustomerResult> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
    {
        var customer = await _repository.GetByIdAsync(command.Id);
        
        if (customer == null)
            throw new Exception($"Customer with ID {command.Id} not found");

        customer.Update(
            command.Name,
            command.Document,
            command.Email,
            command.Phone
        );

        await _repository.UpdateAsync(customer);

        return _mapper.Map<UpdateCustomerResult>(customer);
    }
}