using phoneBook.Common.Domain.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain;
public class PhoneBookE : BaseEntity
{
    public PhoneBookE()
    {
    }
    public PhoneBookE(long userId)
    {
        UserId = userId;
    }   
    public long UserId { get; set; }
}

