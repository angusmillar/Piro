using System.Linq.Expressions;

namespace Piro.FhirServer.Application.Repository.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly AppContext Context;
    public GenericRepository(AppContext context)
    {
        Context = context;
    }
    public void Add(T entity)
    {
        Context.Set<T>().Add(entity);
    }
    public void AddRange(IEnumerable<T> entities)
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