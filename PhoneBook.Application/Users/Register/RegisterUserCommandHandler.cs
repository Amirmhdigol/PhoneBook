using MediatR;
using PhoneBook.Application.Utils;
using PhoneBook.Domain;
using PhoneBook.Domain.Repository;

namespace PhoneBook.Application.Users.Register;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, bool>
{
    private readonly IUserRepository _userRepository;
    public RegisterUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = User.RegisterUser(request.Name, Sha256Hasher.Hash(request.Password), request.Email);
        await _userRepository.AddAsync(user);
        await _userRepository.Save();
        return true;
    }
}