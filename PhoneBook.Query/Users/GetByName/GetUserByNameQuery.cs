using MediatR;
using PhoneBook.Query.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Query.Users.GetByName;
public record GetUserByNameQuery(string Name) : IRequest<UserDTO>;
