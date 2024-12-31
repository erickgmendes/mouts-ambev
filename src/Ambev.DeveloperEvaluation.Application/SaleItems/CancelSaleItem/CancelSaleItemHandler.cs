using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.CancelSaleItem;

public class UpdateSaleItemHandler : IRequestHandler<CancelSaleItemCommand, CancelSaleItemResult>
{
    private readonly ISaleItemRepository _saleItemRepository;
    private readonly IMapper _mapper;

    public UpdateSaleItemHandler(
        ISaleItemRepository saleItemRepository,
        IMapper mapper)
    {
        _saleItemRepository = saleItemRepository;
        _mapper = mapper;
    }

    public async Task<CancelSaleItemResult> Handle(CancelSaleItemCommand command, CancellationToken cancellationToken)
    {
        var validator = new CancelSaleItemValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var saleItem = await _saleItemRepository.GetByIdAsync(command.Id, cancellationToken);
        
        if (saleItem == null)
            throw new KeyNotFoundException($"Sale Item with ID {command.Id} not found");
        
        if (saleItem.IsCancelled())
            throw new KeyNotFoundException($"Sale Item with ID {command.Id} has already been cancelled");
        
        saleItem.Cancel();
        var canceledSale = await _saleItemRepository.UpdateAsync(saleItem, cancellationToken);
        if (canceledSale == null)
            throw new KeyNotFoundException($"Sale Item with ID {command.Id} not found");

        return new CancelSaleItemResult { Success = true };
    }
}