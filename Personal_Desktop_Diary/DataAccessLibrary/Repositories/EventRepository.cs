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
    public class EventRepository : IEventRepository
    {
        private readonly DatabaseContext _context;
        public EventRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void CreateItem(Event item)
        {
            _context.Entry(item).State = EntityState.Added;
        }

        public void DeleteItem(Event item)
        {
            _context.Entry(item).State = EntityState.Deleted;
        }

        public IEnumerable<Event> GetAllItems()
        {
            IEnumerable<Event> items = _context.Set<Event>().AsEnumerable();
            if (items.Count() == 0)
                throw new Exception();
            return items;
        }

        public Event GetSingleItem(Expression<Func<Event, bool>> predicate)
        {
            Event item = _context.Set<Event>().FirstOrDefault(predicate);
            if (item == null)
                throw new Exception("Not found");
            return item;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateItem(Event item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
