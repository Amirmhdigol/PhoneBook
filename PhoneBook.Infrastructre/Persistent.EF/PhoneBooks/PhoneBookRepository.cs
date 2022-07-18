using PhoneBook.Domain;
using PhoneBook.Domain.Repository;
using PhoneBook.Infrastructre._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Infrastructre.Persistent.EF.PhoneBooks;
public class PhoneBookRepository : BaseRepository<PhoneBookE>, IPhoneBookRepository
{
    public PhoneBookRepository(PBContext context) : base(context)
    {
    }
}