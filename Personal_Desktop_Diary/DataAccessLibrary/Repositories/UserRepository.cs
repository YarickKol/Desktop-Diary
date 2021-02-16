using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLibrary.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void CreateItem(User item)
        {
            _context.Entry(item).State = EntityState.Added;
        }

        public void DeleteItem(User item)
        {
            _context.Entry(item).State = EntityState.Deleted;
        }

        public IEnumerable<User> GetAllItems()
        {
            IEnumerable<User> items = _context.Set<User>().AsEnumerable();
            if (items.Count() == 0)
                throw new Exception();
            return items;
        }

        public User GetSingleItem(Expression<Func<User, bool>> predicate)
        {
            //User item = _context.Set<User>().FirstOrDefault(predicate);
            //if (item == null)
            //    throw new Exception("Not found");
            return _context.Set<User>().FirstOrDefault(predicate);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateItem(User item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
