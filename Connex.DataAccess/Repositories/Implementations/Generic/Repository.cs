using Connex.Core.Entities;
using Connex.DataAccess.Contexts;
using Connex.DataAccess.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Connex.DataAccess.Repositories.Implementations;

public abstract class Repository<T> : IRepository<T> where T : BaseEntity, new()
{
    private readonly AppDbContext _context;
    private readonly DbSet<T> _table;

    public Repository(AppDbContext context)
    {
        _context = context;
        _table = _context.Set<T>();
    }

    public async Task<T> CreateAsync(T entity)
    {
        var entityEntry = await _table.AddAsync(entity);

        return entityEntry.Entity;
    }

    public T Delete(T entity)
    {
        var entityEntry = _table.Remove(entity);

        return entityEntry.Entity;
    }

    public IQueryable<T> GetAll(params string[] includes)
    {
        IQueryable<T> query = _getQueryWithIncludes(includes);

        return query;
    }


    public async Task<T?> GetAsync(Expression<Func<T, bool>> expression, params string[] includes)
    {
        var query = _getQueryWithIncludes(includes);

        var entity = await query.FirstOrDefaultAsync(expression);

        return entity;
    }

    public async Task<T?> GetAsync(int id, params string[] includes)
    {
        var query = _getQueryWithIncludes(includes);

        var entity = await query.FirstOrDefaultAsync(x => x.Id == id);

        return entity;
    }

    public IQueryable<T> GetFilter(Expression<Func<T, bool>> expression, params string[] inclues)
    {
        var query= _getQueryWithIncludes(inclues);

        query=query.Where(expression);

        return query;
    }

    public async Task<bool> IsExistAsync(Expression<Func<T, bool>> expression, params string[] includes)
    {
        var query = _getQueryWithIncludes(includes);

        var result = await query.AnyAsync(expression);

        return result;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public T Update(T entity)
    {
        var entityEntry=_table.Update(entity);

        return entityEntry.Entity;
    }



    private IQueryable<T> _getQueryWithIncludes(string[] includes)
    {
        var query = _table.AsQueryable();

        foreach (var include in includes)
        {
            query.Include(include);
        }

        return query;
    }
}
