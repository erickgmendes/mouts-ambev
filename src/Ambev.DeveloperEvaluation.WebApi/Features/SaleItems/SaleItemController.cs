using Ambev.DeveloperEvaluation.Application.SaleItems.CancelSaleItem;
using Ambev.DeveloperEvaluation.Application.SaleItems.CreateSaleItem;
using Ambev.DeveloperEvaluation.Application.SaleItems.DeleteSaleItem;
using Ambev.DeveloperEvaluation.Application.SaleItems.GetSaleItem;
using Ambev.DeveloperEvaluation.Application.Sales.CancelSale;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.CancelSaleItem;
using Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.DeleteSaleItem;
using Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.CreateSaleItem;
using Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.GetSaleItem;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems;

/// <summary>
/// Controller for managing saleItem operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class SaleItemController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of SaleItemsController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public SaleItemController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Creates a new saleItem
    /// </summary>
    /// <param name="request">The saleItem creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created saleItem details</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateSaleItemResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateSaleItem([FromBody] CreateSaleItemRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var validator = new CreateSaleItemRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<CreateSaleItemCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);
            const string message = "Sale item created successfully";
            Log.Information(message);
            
            return Created(string.Empty, new ApiResponseWithData<CreateSaleItemResponse>
            {
                Success = true,
                Message = message,
                Data = _mapper.Map<CreateSaleItemResponse>(response)
            });
        }
        catch (Exception e)
        {
            Log.Error(e, "Error occured while trying to create sale item");
            return BadRequest(new ApiResponse
            {
                Success = false,
                Message = e.Message
            });
        }
    }

    /// <summary>
    /// Retrieves a saleItem by their ID
    /// </summary>
    /// <param name="id">The unique identifier of the saleItem</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The saleItem details if found</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetSaleItemResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetSaleItem([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetSaleItemRequest { Id = id };
        var validator = new GetSaleItemRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        try
        {
            var command = _mapper.Map<GetSaleItemCommand>(request.Id);
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponseWithData<GetSaleItemResponse>
            {
                Success = true,
                Message = "Sale item retrieved successfully",
                Data = _mapper.Map<GetSaleItemResponse>(response)
            });
        }
        catch (Exception e)
        {
            return BadRequest(new ApiResponse
            {
                Success = false,
                Message = e.Message
            });
        }
    }

    /// <summary>
    /// Deletes a saleItem by their ID
    /// </summary>
    /// <param name="id">The unique identifier of the saleItem to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Success response if the saleItem was deleted</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteSaleItem([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new DeleteSaleItemRequest { Id = id };
        var validator = new DeleteSaleItemRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<DeleteSaleItemCommand>(request.Id);

        try
        {
            await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Sale item deleted successfully"
            });
        }
        catch (Exception e)
        {
            return BadRequest(new ApiResponse
            {
                Success = false,
                Message = e.Message
            });
        }
    }
    
    /// <summary>
    /// Cancel an existing sale item 
    /// </summary>
    /// <param name="id">The unique identifier of the sale item to cancel</param>
    /// <param name="request">The sale item update request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Success response if the sale item was canceled</returns>
    [HttpPut("cancel/{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<CancelSaleItemResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CancelSaleItem([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new CancelSaleItemRequest { Id = id };
        var validator = new CancelSaleItemRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CancelSaleItemCommand>(request);
        try
        {
            var response = await _mediator.Send(command, cancellationToken);
            const string message = "Sale Item canceled successfully";
            Log.Information(message);
            
            return Ok(new ApiResponseWithData<CancelSaleItemResult>
            {
                Success = true,
                Message = message,
                Data = _mapper.Map<CancelSaleItemResult>(response)
            });
        }
        catch (Exception e)
        {
            return BadRequest(new ApiResponse
            {
                Success = false,
                Message = e.Message
            });
        }
    }
}