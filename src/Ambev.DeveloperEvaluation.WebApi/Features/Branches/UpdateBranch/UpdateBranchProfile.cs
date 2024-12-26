using Ambev.DeveloperEvaluation.Application.Branches.GetBranch;
using Ambev.DeveloperEvaluation.Application.Branches.UpdateBranch;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branches.UpdateBranch;

/// <summary>
/// Profile for mapping between Application and API CreateBranch responses
/// </summary>
public class UpdateBranchProfile: Profile
{
    /// <summary>
    /// Initializes the mappings for CreateBranch feature
    /// </summary>
    public UpdateBranchProfile()
    {
        CreateMap<UpdateBranchRequest, UpdateBranchCommand>();
        CreateMap<UpdateBranchResult, UpdateBranchResponse>();
        CreateMap<UpdateBranchCommand, Branch>();
    }
}