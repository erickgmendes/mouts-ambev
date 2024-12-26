using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, UpdateProductResult>
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public UpdateProductHandler(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(command.Id);
        
        if (product == null)
            throw new Exception("Product not found");

        product.Update(
            command.ExternalId,
            command.Name,
            command.Description,
            command.Price
        );

        await _repository.UpdateAsync(product);

        return _mapper.Map<UpdateProductResult>(product);
    }
}