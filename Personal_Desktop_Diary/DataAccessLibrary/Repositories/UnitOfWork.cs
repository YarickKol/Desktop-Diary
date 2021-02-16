using DataAccessLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        private IUserRepository userRepository;
        private IEventRepository eventRepository;
        private bool isDisposed;


        public IEventRepository Events { 
            get => eventRepository ?? (eventRepository = new EventRepository(_context)); 
            set => eventRepository = value; 
        }

        public IUserRepository Users
        {
            get => userRepository ?? (userRepository = new UserRepository(_context));
            set => userRepository = value;
        }

        public UnitOfWork()
        {
            _context = new DatabaseContext();
        }

        public void Dispose()
        {
            Dispose(true);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                _context.Dispose();
                isDisposed = true;
            }
        }
    }
}
