using Application.DA;
using Application.Models;
using Application.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Application.Repositories.Common
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : Model
    {
        protected ApplicationContext DbContext;
        protected DbSet<T> DbSet;
        public GenericRepository(ApplicationContext context)
        {
            DbContext = context;
            DbSet = context.Set<T>();
        }

        public void Delete(object id)
        {
            T entity = DbSet.Find(id);
            this.Delete(entity);
        }

        public void Delete(T entity)
        {
            if(DbContext.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }

            DbSet.Remove(entity);
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = DbSet;
            if(filter!= null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if(orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public T GetByID(object id)
        {
            return DbSet.Find(id);
        }

        public long Insert(T entity)
        {
            DbSet.Add(entity);
            return entity.Id;
        }

        public void Update(T entity)
        {
            DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
