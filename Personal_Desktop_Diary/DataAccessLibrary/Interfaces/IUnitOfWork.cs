using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IEventRepository Events { get; set; }
        IUserRepository Users { get; set; }
    }
}
