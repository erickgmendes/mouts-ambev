using Ambev.DeveloperEvaluation.Application.Branches.CreateBranch;
using Ambev.DeveloperEvaluation.Application.Branchs.CreateBranch;
using Ambev.DeveloperEvaluation.Application.Branchs.GetBranch;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Branches.CreateBranch;
using Ambev.DeveloperEvaluation.WebApi.Features.Branches.GetBranch;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings;

public class CreateBranchRequestProfile : Profile
{
    public CreateBranchRequestProfile()
    {
        CreateMap<CreateBranchRequest, CreateBranchCommand>();
        CreateMap<GetBranchResult, GetBranchResponse>();
        CreateMap<Branch, CreateBranchResult>();
    }
}