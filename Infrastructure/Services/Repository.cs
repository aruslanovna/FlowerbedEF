
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class Repository<TEntity> : IRepository<TEntity>
         where TEntity : class
    {
        private readonly DbSet<TEntity> flowerbedDb;

        private FlowerbedDbContext repositoryContext;

        public  Repository(FlowerbedDbContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;
            this.flowerbedDb = repositoryContext.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return flowerbedDb;
        }

        public IEnumerable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return flowerbedDb.Where(expression);
        }

        public void Create(TEntity entity)
        {
            flowerbedDb.Add(entity);
        }

        public void Update(TEntity entity)
        {
            flowerbedDb.Attach(entity);
            repositoryContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            if (repositoryContext.Entry(entity).State == EntityState.Detached)
            {
                flowerbedDb.Attach(entity);
            }

            flowerbedDb.Remove(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = flowerbedDb.Find(id);
            Delete(entityToDelete);
        }

        public async Task<TEntity> GetByID(object id)
        {
            return await flowerbedDb.FindAsync(id);
        }

        public bool Exist(object id)
        {
            var element = GetByID(id);
            if (element == null)
                 return false;
            return true;
        }

        public IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }

       public IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = flowerbedDb.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty)); 
        }
       

        public IQueryable<TEntity> GetAllLazyLoad(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] children)
        {
            children.ToList().ForEach(x => flowerbedDb.Include(x).Load());
            return flowerbedDb;
        }
    }
}
