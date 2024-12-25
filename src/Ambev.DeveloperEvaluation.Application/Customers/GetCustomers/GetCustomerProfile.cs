using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Customers.GetCustomers;

/// <summary>
/// Profile for mapping between Customer entity and GetCustomerResponse
/// </summary>
public class GetCustomerProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetCustomer operation
    /// </summary>
    public GetCustomerProfile()
    {
        CreateMap<Customer, GetCustomerResult>();
    }
}