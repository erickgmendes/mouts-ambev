using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of ISaleRepository using Entity Framework Core
/// </summary>
public class SaleRepository: ISaleRepository
{
    private readonly DefaultContext _context;
    private readonly ISaleItemRepository _saleItemRepository;
    private readonly IProductRepository _productRepository;
    
    /// <summary>
    /// Initializes a new instance of SaleRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public SaleRepository(
        DefaultContext context, 
        ISaleItemRepository saleItemRepository,
        IProductRepository productRepository
        )
    {
        _context = context;
        _saleItemRepository = saleItemRepository;
        _productRepository = productRepository;
    }

    /// <summary>
    /// Creates a new sale in the database
    /// </summary>
    /// <param name="sale">The sale to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sale</returns>
    public async Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default)
    {
        var result = await _context.Sales.AddAsync(sale, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return result.Entity;
    }

    /// <summary>
    /// Retrieves a sale by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the sale</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The sale if found, null otherwise</returns>
    public async Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Sales
            .Include(x=>x.Branch)
            .Include(x=>x.Customer)
            .Include(x=>x.Items)
                .ThenInclude(x=>x.Product)
            .FirstOrDefaultAsync(o=> o.Id == id && o.Status == SaleStatus.NotCancelled, cancellationToken);
    }

    /// <summary>
    /// Retrieves a sale by their email address
    /// </summary>
    /// <param name="email">The email address to search for</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The sale if found, null otherwise</returns>
    public async Task<Sale?> GetByNumberAsync(string number, CancellationToken cancellationToken = default)
    {
        return await _context.Sales
            .Include(x=>x.Branch)
            .Include(x=>x.Customer)
            .Include(x=>x.Items)
                .ThenInclude(x=>x.Product)
            .FirstOrDefaultAsync(b => b.Number == number, cancellationToken);
    }

    /// <summary>
    /// Deletes a sale from the database
    /// </summary>
    /// <param name="id">The unique identifier of the sale to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the sale was deleted, false if not found</returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var sale = await GetByIdAsync(id, cancellationToken);
        if (sale == null)
            return false;

        _context.Sales.Remove(sale);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
    
    /// <summary>
    /// Deletes a sale from the database
    /// </summary>
    /// <param name="id">The unique identifier of the sale to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the sale was deleted, false if not found</returns>
    public async Task<Sale?> UpdateAsync(Sale? sale, CancellationToken cancellationToken = default)
    {
        if (sale == null)
            return null;

        _context.Sales.Update(sale);
        await _context.SaveChangesAsync(cancellationToken);
        return sale;
    }

    public async Task<bool> CancelSale(Sale sale, CancellationToken cancellationToken = default)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var items = await _saleItemRepository.GetBySaleIdAsync(sale.Id, cancellationToken);
            foreach (var saleItem in items)
            {
                //var product = _productRepository.GetByIdAsync(saleItem.Product.Id, cancellationToken);
                //product.Quantity += saleItem.Quantity;
                saleItem.Cancel();
                await _saleItemRepository.UpdateAsync(saleItem, cancellationToken);
            }
            
            sale.Cancel();
            await UpdateAsync(sale, cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return true;
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
}