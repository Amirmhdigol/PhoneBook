using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Users.AddToken;
public class AddUserTokenCommand : IRequest<bool>
{
    public AddUserTokenCommand(long userId, string hashedJwtToken, DateTime tokenExpireDate)
    {
        UserId = userId;
        HashedJwtToken = hashedJwtToken;
        TokenExpireDate = tokenExpireDate;
    }
    public long UserId { get; private set; }
    public string HashedJwtToken { get; private set; }
    public DateTime TokenExpireDate { get; private set; }
}
