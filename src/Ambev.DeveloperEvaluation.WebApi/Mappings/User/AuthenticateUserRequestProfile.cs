using Ambev.DeveloperEvaluation.Application.Auth.AuthenticateUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Auth.AuthenticateUserFeature;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings.User;

public class AuthenticateUserRequestProfile : Profile
{
    public AuthenticateUserRequestProfile()
    {
        CreateMap<AuthenticateUserRequest, AuthenticateUserCommand>();
    }
}