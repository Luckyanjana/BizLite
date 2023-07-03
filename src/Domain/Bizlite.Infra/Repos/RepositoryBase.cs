using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Bizlite.Core.Interfaces;
using Bizlite.Infra.Entities;

namespace Bizlite.Infra.Repos
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly BizliteContext _bizliteContext;

        public RepositoryBase(BizliteContext bizliteContext) {
            _bizliteContext = bizliteContext;
        }
        public void Create(T entity)
        {
            _bizliteContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _bizliteContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll()
        {
           return _bizliteContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition)
        {
            return _bizliteContext.Set<T>().Where(condition).AsNoTracking();
        }

        public void Update(T entity)
        {
            _bizliteContext.Set<T>().Update(entity);
        }
    }
}
