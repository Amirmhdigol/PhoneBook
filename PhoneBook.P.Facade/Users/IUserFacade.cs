using PhoneBook.Application.Users.AddToken;
using PhoneBook.Application.Users.Login;
using PhoneBook.Application.Users.Register;
using PhoneBook.Query.Users.DTOs;
using PhoneBook.RazorPage.Models;

namespace PhoneBook.P.Facade.Users;

public interface IUserFacade
{
    Task<string> Login(LoginUserCommand command);
    Task<bool> RegisterUser(RegisterUserCommand command);
    Task<bool> AddToken(AddUserTokenCommand command);

    Task<UserDTO?> GetUserById(long userId);
    Task<UserDTO> GetUserByName(string name);
    Task<UserTokenDTO?> GetTokenByJwtToken(string jwtToken);
    Task<List<UserDTO>> GetUsers();
}