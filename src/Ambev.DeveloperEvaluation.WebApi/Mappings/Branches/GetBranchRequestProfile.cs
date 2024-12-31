using Ambev.DeveloperEvaluation.Application.Branches.GetBranch;
using Ambev.DeveloperEvaluation.WebApi.Features.Branches.GetBranch;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings.Branches;

public class GetBranchRequestProfile : Profile
{
    public GetBranchRequestProfile()
    {
        CreateMap<GetBranchResult, GetBranchResponse>();
    }
}