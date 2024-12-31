using Ambev.DeveloperEvaluation.Application.Customers.CreateCustomers;
using Ambev.DeveloperEvaluation.Application.Customers.DeleteCustomers;
using Ambev.DeveloperEvaluation.Application.Customers.GetCustomers;
using Ambev.DeveloperEvaluation.Application.Customers.UpdateCustomer;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Customers.DeleteCustomer;
using Ambev.DeveloperEvaluation.WebApi.Features.Customers.CreateCustomer;
using Ambev.DeveloperEvaluation.WebApi.Features.Customers.GetCustomer;
using Ambev.DeveloperEvaluation.WebApi.Features.Customers.UpdateCustomer;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers;

/// <summary>
/// Controller for managing customer operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class CustomersController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of CustomersController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public CustomersController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Creates a new customer
    /// </summary>
    /// <param name="request">The customer creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created customer details</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateCustomerResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var validator = new CreateCustomerRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<CreateCustomerCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<CreateCustomerResponse>
            {
                Success = true,
                Message = "Customer created successfully",
                Data = _mapper.Map<CreateCustomerResponse>(response)
            });
        }
        catch (Exception e)
        {
            Log.Error(e, "Error occured while trying to create customer");
            return BadRequest(new ApiResponse
            {
                Success = false,
                Message = e.Message
            });
        }
    }

    /// <summary>
    /// Retrieves a customer by their ID
    /// </summary>
    /// <param name="id">The unique identifier of the customer</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The customer details if found</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetCustomerResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCustomer([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetCustomerRequest { Id = id };
        var validator = new GetCustomerRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetCustomerCommand>(request.Id);

        try
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponseWithData<GetCustomerResponse>
            {
                Success = true,
                Message = "Customer retrieved successfully",
                Data = _mapper.Map<GetCustomerResponse>(response)
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
    /// Deletes a customer by their ID
    /// </summary>
    /// <param name="id">The unique identifier of the customer to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Success response if the customer was deleted</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteCustomer([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new DeleteCustomerRequest { Id = id };
        var validator = new DeleteCustomerRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<DeleteCustomerCommand>(request.Id);

        try
        {
            await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Customer deleted successfully"
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
    /// Updates an existing customer
    /// </summary>
    /// <param name="id">The unique identifier of the customer to update</param>
    /// <param name="request">The customer update request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Success response if the customer was updated</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<UpdateCustomerResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateCustomer([FromRoute] Guid id, [FromBody] UpdateCustomerRequest request, CancellationToken cancellationToken)
    {
        var validator = new UpdateCustomerRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);
    
        try
        {
            var command = _mapper.Map<UpdateCustomerCommand>(request);
            command.Id = id;
            var response = await _mediator.Send(command, cancellationToken);
        
            return Ok(new ApiResponseWithData<UpdateCustomerResponse>
            {
                Success = true,
                Message = "Customer updated successfully",
                Data = _mapper.Map<UpdateCustomerResponse>(response)
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