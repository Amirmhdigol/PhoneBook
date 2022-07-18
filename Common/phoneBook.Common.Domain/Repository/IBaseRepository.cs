using phoneBook.Common.Domain.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phoneBook.Common.Domain.Repository;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<T?> GetAsync(long id);
    Task<T?> GetTracking(long id);
    Task AddAsync(T entity);
    Task<int> Save();
    T? Get(long id);
}