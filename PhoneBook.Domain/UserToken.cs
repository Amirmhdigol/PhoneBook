using phoneBook.Common.Domain.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain;
public class UserToken : BaseEntity
{
    private UserToken()
    {

    }
    public UserToken(string hashedJwtToken, DateTime tokenExpireDate)
    {
        HashedJwtToken = hashedJwtToken;
        TokenExpireDate = tokenExpireDate;
    }
    public long UserId { get; internal set; }
    public string HashedJwtToken { get; private set; }
    public DateTime TokenExpireDate { get; private set; }
}