using Connex.Core.Entities;
using System.Linq.Expressions;

namespace Connex.DataAccess.Repositories.Abstractions;

public interface IRepository<T> where T : BaseEntity, new()
{
    IQueryable<T> GetAll(params string[] includes);
    IQueryable<T> GetFilter(Expression<Func<T, bool>> expression, params string[] inclues);
    Task<T?> GetAsync(Expression<Func<T, bool>> expression, params string[] includes);
    Task<T?> GetAsync(int id, params string[] includes);
    Task<bool> IsExistAsync(Expression<Func<T, bool>> expression, params string[] includes);
    Task<T> CreateAsync(T entity);
    T Update(T entity);
    T Delete(T entity);
    Task<int> SaveChangesAsync();
}
