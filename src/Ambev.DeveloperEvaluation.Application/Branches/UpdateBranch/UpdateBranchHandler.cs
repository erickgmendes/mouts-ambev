using Ambev.DeveloperEvaluation.Application.Branches.GetBranch;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branches.UpdateBranch;

public class UpdateBranchHandler : IRequestHandler<UpdateBranchCommand, UpdateBranchResult>
{
    private readonly IBranchRepository _repository;
    private readonly IMapper _mapper;

    public UpdateBranchHandler(IBranchRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<UpdateBranchResult> Handle(UpdateBranchCommand command, CancellationToken cancellationToken)
    {
        var branch = await _repository.GetByIdAsync(command.Id);
        
        if (branch == null)
            throw new Exception("Branch not found");

        branch.Update(
            command.Name,
            command.Address,
            command.City,
            command.State,
            command.PostalCode
        );

        await _repository.UpdateAsync(branch);

        return _mapper.Map<UpdateBranchResult>(branch);
    }
}