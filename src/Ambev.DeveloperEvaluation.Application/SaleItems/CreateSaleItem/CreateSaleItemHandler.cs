using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.CreateSaleItem;

public class CreateSaleItemHandler: IRequestHandler<CreateSaleItemCommand, CreateSaleItemResult>
{
    private readonly ISaleItemRepository _saleItemRepository;
    private readonly ISaleRepository _saleRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of CreateSaleItemHandler
    /// </summary>
    /// <param name="saleRepository">The sale repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for CreateSaleItemCommand</param>
    public CreateSaleItemHandler(
        ISaleItemRepository saleItemRepository, 
        ISaleRepository saleRepository,
        IProductRepository productRepository,
        IMapper mapper 
        )
    {
        _saleItemRepository = saleItemRepository;
        _saleRepository = saleRepository;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the CreateSaleItemCommand request
    /// </summary>
    /// <param name="command">The CreateSaleItem command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sale details</returns>
    public async Task<CreateSaleItemResult> Handle(CreateSaleItemCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleItemCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var sale = await _saleRepository.GetByIdAsync(command.SaleId, cancellationToken);
        if (sale == null)
            throw new InvalidOperationException($"Sale with ID {command.SaleId} not found");
        
        var product = await _productRepository.GetByIdAsync(command.ProductId, cancellationToken);
        if (product == null)
            throw new InvalidOperationException($"Product with ID {command.ProductId} not found");

        var salesItem = await _saleItemRepository.GetBySaleAndProductAsync(command.SaleId, command.ProductId, cancellationToken);
        if (salesItem?.Any() == true)
        {
            var currentQuantity = salesItem.Sum(x => x.Quantity);
            var newQuantity = currentQuantity + command.Quantity;
            if (newQuantity > 20)
                throw new ValidationException($"The established limit is 20 items per product.");
        }

        var saleItem = _mapper.Map<SaleItem>(command);
        saleItem.Update(sale, product);
        var createdSaleItem = await _saleItemRepository.CreateAsync(saleItem, cancellationToken);
        return _mapper.Map<CreateSaleItemResult>(createdSaleItem);
        
    }
}