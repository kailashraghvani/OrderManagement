﻿using Microsoft.EntityFrameworkCore;
using OrderManagement.Data;
using System.Linq.Expressions;
namespace OrderManagement.Application.Repositiry
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDBContex _appContext;
        private DbSet<T> table;
        public GenericRepository(ApplicationDBContex appContext)
        {
            _appContext = appContext;
            table = _appContext.Set<T>();
        }
        public void Add(T entity)
        {
            table.Add(entity);
            Save();
        }
        public void AddRange(List<T> entitys)
        {
            table.AddRange(entitys);
            Save();
        }
        public void Delete(T entity)
        {
            table.Remove(entity);
            Save();
        }
        public void DeleteRange(List<T> entitys)
        {
            table.RemoveRange(entitys);
            Save();
        }
        public void Update(T entity)
        {
            table.Attach(entity);
            _appContext.Entry(entity).State = EntityState.Modified;
            Save();
        }

        public IEnumerable<T> GetAll() => table.ToList();
        
        public T GetById(int id) => table.Find(id);
        
        private void Save()
        {
            _appContext.SaveChanges();
        }

        public T Select(Expression<Func<T, bool>> expression)
        {
            return _appContext.Set<T>().Where(expression).FirstOrDefault()!;
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return _appContext.Set<T>().Where(expression).ToList()!;
        }

        public IQueryable<T> GetAllwithInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var query = table.Where(predicate);
            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
