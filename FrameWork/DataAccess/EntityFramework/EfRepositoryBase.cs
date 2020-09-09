using Framework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Framework.DataAccess.EntityFramework
{
    public  class EfRepositoryBase<TEntity, TContext>:IEntityRepository<TEntity>
    where TEntity:class,IEntity, new()
    where TContext:DbContext, new()
    {// interceptor kullancağımız için transactionlarda unitofworke ihtiyaç var mı???
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();

            }
            
        }

        public void Add(TEntity entity)
        {
            using (var context= new TContext())
            {
               var addedEntity= context.Entry(entity);
               addedEntity.State = EntityState.Added;
               context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var modifiedEntity = context.Entry(entity);
                modifiedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
