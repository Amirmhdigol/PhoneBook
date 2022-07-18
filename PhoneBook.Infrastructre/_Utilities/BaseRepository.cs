using Microsoft.EntityFrameworkCore;
using phoneBook.Common.Domain.Bases;
using phoneBook.Common.Domain.Repository;
using PhoneBook.Infrastructre.Persistent.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Infrastructre._Utilities;
public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly PBContext _context;
    public BaseRepository(PBContext context)
    {
        _context = context;
    }
    public virtual async Task<TEntity?> GetAsync(long id)
    {
        return await _context.Set<TEntity>().FirstOrDefaultAsync(t => t.Id.Equals(id)); ;
    }
    public async Task<TEntity?> GetTracking(long id)
    {
        return await _context.Set<TEntity>().AsTracking().FirstOrDefaultAsync(t => t.Id.Equals(id));

    }
    public async Task AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
    }
    public async Task<int> Save()
    {
        return await _context.SaveChangesAsync();
    }
    public TEntity? Get(long id)
    {
        return _context.Set<TEntity>().FirstOrDefault(t => t.Id.Equals(id));
    }
}