using ShoppingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ShoppingCore.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetListByParameter(Expression<Func<T, bool>> wherePredict);
        IEnumerable<T> GetUniqueByParameter(Expression<Func<T, bool>> wherePredict);
        T GetByParameter(Expression<Func<T, bool>> wherePredict);
        
        T GetById(object id);
        IEnumerable<T> GetRecordsToShow(int pageNo, int pageSize, int currentPageNo, Expression<Func<T, bool>> wherePredict, Expression<Func<T, int>> orderByPredict);
        int GetAllRecordsCount();
        int GetAllRecordsCountByParameter(Expression<Func<T, bool>> wherePredict);
        void Insert(T obj);
        void Update(T obj);
        void UpdateByWhereClause(Expression<Func<T, bool>> wherePredict, Action<T> ForEachPredict);
        void Remove(T entity);
        void RemovebyWhereClause(Expression<Func<T, bool>> wherePredict);
        void Save();


    }
}