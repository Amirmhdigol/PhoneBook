using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Users.Login;
public record LoginUserCommand(string Name, string Password) : IRequest<string>;
