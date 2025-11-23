using System.Linq;
using Microsoft.EntityFrameworkCore;
using PIS.Repositories.Contracts;

namespace PIS.Repositories;

public abstract class RepositoryBase<T> 
    : IRepositoryBase<T> where T : class, new()
{
    protected readonly RepositoryContext _context;

    protected RepositoryBase(RepositoryContext context)
    {
        _context = context;
    }

    public virtual IQueryable<T> GetAll()
    {
        return _context.Set<T>().AsNoTracking();
    }

    public virtual T? GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public virtual void Create(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }

    public virtual void Update(T entity)
    {
        _context.Set<T>().Update(entity);
        _context.SaveChanges();
    }

    public virtual void Delete(int id)
    {
        var entity = _context.Set<T>().Find(id);
        if (entity is not null)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
    }
}
