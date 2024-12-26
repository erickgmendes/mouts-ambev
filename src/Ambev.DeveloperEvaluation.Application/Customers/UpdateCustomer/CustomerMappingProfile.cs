using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Customers.UpdateCustomer;

public class CustomerMappingProfile : Profile
{
    public CustomerMappingProfile()
    {
        CreateMap<UpdateCustomerRequest, UpdateCustomerCommand>();
        CreateMap<Customer, UpdateCustomerResponse>();
    }
}