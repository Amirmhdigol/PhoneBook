using phoneBook.Common.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain.Repository;
public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetUserByName(string name);
}