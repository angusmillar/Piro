using System.Linq.Expressions;
using Piro.FhirServer.Application.Domain.Models;

namespace Piro.FhirServer.Application.Repository.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : DbBase
{
    protected readonly AppContext Context;

    protected GenericRepository(AppContext context)
    {
        Context = context;
    }
    public void Add(T entity)
    {
        Context.Set<T>().Add(entity);
    }
    public virtual void AddRange(IEnumerable<T> entities)
    {
        Context.Set<T>().AddRange(entities);
    }
    public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
        return Context.Set<T>().Where(expression);
    }
    public IEnumerable<T> GetAll()
    {
        return Context.Set<T>().ToList();
    }
    public T? GetById(int id)
    {
        return Context.Set<T>().Find(id);
    }
    public void Remove(T entity)
    {
        Context.Set<T>().Remove(entity);
    }
    public void RemoveRange(IEnumerable<T> entities)
    {
        Context.Set<T>().RemoveRange(entities);
    }
}