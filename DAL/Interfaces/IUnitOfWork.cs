using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entity;
namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Author> Authors { get; }
        IRepository<Book> Books { get; }
        IRepository<Entity.AuthorsBooks> AuthorsBooks { get; }
        void Save();
    }
}
