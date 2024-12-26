using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
{
    private readonly ISaleRepository _repository;
    private readonly IMapper _mapper;

    public UpdateSaleHandler(ISaleRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<UpdateSaleResult> Handle(UpdateSaleCommand command, CancellationToken cancellationToken)
    {
        var sale = await _repository.GetByIdAsync(command.Id);
        
        if (sale == null)
            throw new Exception("Sale not found");

        sale.Update(
            command.Number,
            command.Date,
            command.TotalAmount,
            (SaleStatus)command.Status
        );

        await _repository.UpdateAsync(sale);

        return _mapper.Map<UpdateSaleResult>(sale);
    }
}