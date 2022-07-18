using phoneBook.Common.Domain.Repository;
using PhoneBook.Domain;
using PhoneBook.Domain.Repository;
using PhoneBook.Infrastructre._Utilities;
using Microsoft.EntityFrameworkCore;

namespace PhoneBook.Infrastructre.Persistent.EF.Users;
internal class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(PBContext context) : base(context)
    {
    }

    public async Task<User?> GetUserByName(string name)
    {
        return await _context.Users.FirstOrDefaultAsync(a => a.Name == name);
    }
}