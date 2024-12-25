using Ambev.DeveloperEvaluation.Application.Customers.CreateCustomers;
using Ambev.DeveloperEvaluation.Application.Customers.GetCustomers;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Customers.CreateCustomer;
using Ambev.DeveloperEvaluation.WebApi.Features.Customers.GetCustomer;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings;

public class CreateCustomerRequestProfile : Profile
{
    public CreateCustomerRequestProfile()
    {
        CreateMap<CreateCustomerRequest, CreateCustomerCommand>();
        CreateMap<GetCustomerResult, GetCustomerResponse>();
        CreateMap<Customer, CreateCustomerResult>();
    }
}