using MediatR;
using PhoneBook.Query.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Query.Users.GetById;
public record GetUserByIdQuery(long UserId) : IRequest<UserDTO>;
