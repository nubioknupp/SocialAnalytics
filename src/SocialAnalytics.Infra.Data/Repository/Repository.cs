using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using SocialAnalytics.Domain.Interfaces.Repository;
using SocialAnalytics.Infra.Data.Context;

namespace SocialAnalytics.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected SocialAnalyticsContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository()
        {
            Db = new SocialAnalyticsContext();
            DbSet = Db.Set<TEntity>();
        }

        public virtual TEntity Add(TEntity obj)
        {
            var objReturn = DbSet.Add(obj);
            SaveChanges();
            return objReturn;
        }
        
        public TEntity FindById(Guid id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<TEntity> FindAll()
        {
            return DbSet.ToList();
        }

        public TEntity Update(TEntity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
            SaveChanges();

            return obj;
        }

        public void Remove(Guid id)
        {
            DbSet.Remove(FindById(id));
            SaveChanges();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
