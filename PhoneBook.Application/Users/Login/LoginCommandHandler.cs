using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using PhoneBook.Application.Users.AddToken;
using PhoneBook.Application.Utils;
using PhoneBook.Domain.Repository;
using PhoneBook.Query.Users.DTOs;
using UAParser;

namespace PhoneBook.Application.Users.Login;

public class LoginCommandHandler : IRequestHandler<LoginUserCommand, string>
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;
    IMediator _mediator;
    public LoginCommandHandler(IUserRepository userRepository, IConfiguration configuration, IMediator mediator)
    {
        _userRepository = userRepository;
        _configuration = configuration;
        _mediator = mediator;
    }

    public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByName(request.Name);
        if (user == null) throw new Exception("User NotFound");

        if (!Sha256Hasher.IsCompare(user.Password, request.Password))
            throw new Exception("User NotFound");

        /*var loginResult = */
        var token = await AddTokenAndGenerateJwt(new UserDTO { Name = user.Name, Email = user.Email, Password = user.Password, Id = user.Id, CreationDate = user.CreationDate });
        return token;
    }
    private async Task<string?> AddTokenAndGenerateJwt(UserDTO user)
    {
        var token = JWTTokenBuilder.BuildToken(user, _configuration);
        var hashJwt = Sha256Hasher.Hash(token);
        var tokenResult = await _mediator.Send(new AddUserTokenCommand(user.Id, hashJwt, DateTime.Now.AddDays(7)));

        if (!tokenResult) throw new Exception("Add Token Failed");
        return token;
    }
}