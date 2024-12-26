using Ambev.DeveloperEvaluation.Application.Customers.UpdateCustomer;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.UpdateCustomer;

/// <summary>
/// Profile for mapping between Application and API CreateCustomer responses
/// </summary>
public class UpdateCustomerProfile: Profile
{
    /// <summary>
    /// Initializes the mappings for CreateCustomer feature
    /// </summary>
    public UpdateCustomerProfile()
    {
        CreateMap<UpdateCustomerRequest, UpdateCustomerCommand>();
        CreateMap<Customer, UpdateCustomerResult>();
        CreateMap<UpdateCustomerResult, UpdateCustomerResponse>();
    }
}