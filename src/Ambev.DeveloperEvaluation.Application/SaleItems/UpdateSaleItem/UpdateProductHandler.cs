using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.UpdateSaleItem;

public class UpdateSaleItemHandler : IRequestHandler<UpdateSaleItemCommand, UpdateSaleItemResult>
{
    private readonly ISaleItemRepository _repository;
    private readonly IMapper _mapper;

    public UpdateSaleItemHandler(
        ISaleItemRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<UpdateSaleItemResult> Handle(UpdateSaleItemCommand command, CancellationToken cancellationToken)
    {
        var saleItem = await _repository.GetByIdAsync(command.Id);
        
        if (saleItem == null)
            throw new Exception($"Sale Item with ID {command.Id} not found");

        saleItem.Update(
            command.Quantity,
            command.UnitPrice,
            command.Discount,
            command.TotalAmount,
            (SaleItemStatus)command.Status
        );

        await _repository.UpdateAsync(saleItem);

        return _mapper.Map<UpdateSaleItemResult>(saleItem);
    }
}