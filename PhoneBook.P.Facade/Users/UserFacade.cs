using MediatR;
using PhoneBook.Application.Users.AddToken;
using PhoneBook.Application.Users.Login;
using PhoneBook.Application.Users.Register;
using PhoneBook.Application.Utils;
using PhoneBook.Query.Users.DTOs;
using PhoneBook.Query.Users.GetById;
using PhoneBook.Query.Users.GetByName;
using PhoneBook.Query.Users.GetList;
using PhoneBook.Query.Users.GetTokenByJWTToken;
using PhoneBook.RazorPage.Models;

namespace PhoneBook.P.Facade.Users;

public class UserFacade : IUserFacade
{
    private readonly IMediator _mediator;

    public UserFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<bool> AddToken(AddUserTokenCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<UserTokenDTO?> GetTokenByJwtToken(string jwtToken)
    {
        var HashedJwtToken = Sha256Hasher.Hash(jwtToken);
        return await _mediator.Send(new GetTokenByJWTTokenQuery(HashedJwtToken));
    }

    public async Task<UserDTO?> GetUserById(long userId)
    {
        return await _mediator.Send(new GetUserByIdQuery(userId));
    }

    public async Task<UserDTO> GetUserByName(string name)
    {
        return await _mediator.Send(new GetUserByNameQuery(name));
    }

    public async Task<List<UserDTO>> GetUsers()
    {
        return await _mediator.Send(new GetUserListQuery());
    }

    public async Task<string> Login(LoginUserCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<bool> RegisterUser(RegisterUserCommand command)
    {
        return await _mediator.Send(command);
    }
}