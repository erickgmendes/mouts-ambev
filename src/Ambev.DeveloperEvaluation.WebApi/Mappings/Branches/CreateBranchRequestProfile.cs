using Ambev.DeveloperEvaluation.Application.Branches.CreateBranch;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Branches.CreateBranch;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings.Branches;

public class CreateBranchRequestProfile : Profile
{
    public CreateBranchRequestProfile()
    {
        CreateMap<CreateBranchRequest, CreateBranchCommand>();
        CreateMap<Branch, CreateBranchResult>();
    }
}