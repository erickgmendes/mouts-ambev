using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Branches.UpdateBranch;

public class BranchMappingProfile : Profile
{
    public BranchMappingProfile()
    {
        CreateMap<UpdateBranchRequest, UpdateBranchCommand>();
        CreateMap<Branch, UpdateBranchResponse>();
    }
}