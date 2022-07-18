using phoneBook.Common.Domain.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain;
public class User : BaseEntity
{
    private User()
    {

    }
    public User(string name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;
    }
    public static User RegisterUser(string name, string password, string email)
    {
        return new User(name, email, password);
    }
    public void AddToken(string hashedJwtToken, DateTime tokenExpireDate)
    {
        var token = new UserToken(hashedJwtToken, tokenExpireDate)
        {
            UserId = Id
        };
        UserTokens.Add(token);
    }

    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public List<UserToken> UserTokens { get; }
    public List<PhoneBookE> PhoneBooks { get; }
}