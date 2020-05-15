
using Microsoft.EntityFrameworkCore;
using ShoppingCore.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ShoppingCore.Repository
{
    // This is used to Isolate the EntityFramework based Data Access Layer from the MVC Controller class

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private ShoppingCoreEntities _context = null;
        private DbSet<T> table = null;


        public GenericRepository(ShoppingCoreEntities _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        { 
            var model = table.Find(id); ;
            return model;
        }

        public T GetByParameter(Expression<Func<T, bool>> wherePredict)
        {
            return table.Where(wherePredict).FirstOrDefault();
        }

        public void Insert(T obj)
        {
            table.Add(obj);
            Save();
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            Save();
        }

        public void Remove(Expression<Func<T, bool>> wherePredict, Action<T> ForEachPredict)
        {
            T existing = table.Find(wherePredict);
            table.Remove(existing);
            Save();
        }

        public void Remove(T entity)
        {
            table.Remove(entity);
            Save();
        }

        public void RemovebyWhereClause(Expression<Func<T, bool>> wherePredict)
        {
            T entity = table.Where(wherePredict).FirstOrDefault();
            Remove(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }


        public IEnumerable<T> GetRecordsToShow(int pageNo, int pageSize, int currentPageNo, Expression<Func<T, bool>> wherePredict, Expression<Func<T, int>> orderByPredict)
        {
            if (wherePredict != null)
                return table.OrderBy(orderByPredict).Where(wherePredict).ToList();
            else
                return table.OrderBy(orderByPredict).ToList();
        }

        public int GetAllRecordsCount()
        {
            return table.Count();
        }

        public void UpdateByWhereClause(Expression<Func<T, bool>> wherePredict, Action<T> ForEachPredict)
        {
            table.Where(wherePredict).ToList().ForEach(ForEachPredict);
            Save();
        }

        public IEnumerable<T> GetListByParameter(Expression<Func<T, bool>> wherePredict)
        {
            return table.Where(wherePredict).ToList();
        }

        public IEnumerable<T> GetUniqueByParameter(Expression<Func<T, bool>> wherePredict)
        {
            return table.Where(wherePredict).Distinct();
        }

        public int GetAllRecordsCountByParameter(Expression<Func<T, bool>> wherePredict)
        {
            return table.Where(wherePredict).Count();
        }
    }

}