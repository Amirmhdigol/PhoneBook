using PhoneBook.Query.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Query.Users.DTOs;
public class UserDTO : BaseDTO
{
    public string Name { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
}