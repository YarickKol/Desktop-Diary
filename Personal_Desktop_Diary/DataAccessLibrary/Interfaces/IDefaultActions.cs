using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccessLibrary.Interfaces
{
    public interface IDefaultActions<T> where T:class
    {                
        void CreateItem(T item);
        void UpdateItem(T item);
        void DeleteItem(T item);
        bool SaveChanges();
        T GetSingleItem(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAllItems();
    }
}
