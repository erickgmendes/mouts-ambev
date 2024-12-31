using Ambev.DeveloperEvaluation.Application.Customers.CreateCustomers;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Customers.CreateCustomer;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings.Customers;

public class CreateCustomerRequestProfile : Profile
{
    public CreateCustomerRequestProfile()
    {
        CreateMap<CreateCustomerRequest, CreateCustomerCommand>();
        CreateMap<Customer, CreateCustomerResult>();
    }
}