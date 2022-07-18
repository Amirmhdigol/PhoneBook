using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Users.Register;
public class RegisterUserCommand : IRequest<bool>
{
    public RegisterUserCommand(string name, string password, string emial)
    {
        Name = name;
        Password = password;
        Email = emial;
    }
    public string Name { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
}