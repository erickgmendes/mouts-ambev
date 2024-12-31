using Ambev.DeveloperEvaluation.Application.Customers.GetCustomers;
using Ambev.DeveloperEvaluation.WebApi.Features.Customers.GetCustomer;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings.Customers;

public class GetCustomerRequestProfile : Profile
{
    public GetCustomerRequestProfile()
    {
        CreateMap<GetCustomerResult, GetCustomerResponse>();
    }
}