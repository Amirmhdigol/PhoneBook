using MediatR;
using PhoneBook.Domain.Repository;

namespace PhoneBook.Application.Users.AddToken;

public class AddUserTokenCommandHandler : IRequestHandler<AddUserTokenCommand, bool>
{
    private readonly IUserRepository _userRepository;
    public AddUserTokenCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> Handle(AddUserTokenCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetTracking(request.UserId);
        if (user == null) return false;

        user.AddToken(request.HashedJwtToken, request.TokenExpireDate);

        await _userRepository.Save();
        return true;
    }
}