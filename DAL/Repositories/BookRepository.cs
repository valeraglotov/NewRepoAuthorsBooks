using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;
using DAL.Entity;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        Task<Book> IRepository<Book>.Read(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(int id)
        {
            _context.Books.Remove(_context.Books.Single(a => a.Id == id));
            _context.SaveChangesAsync();
            return Task.FromResult(true);
        }

        Task<bool> IRepository<Book>.Create(Book item)
        {
            _context.Entry(item).State = item.Id == 0 ? EntityState.Added : EntityState.Modified;
            _context.Books.Add(item);
            _context.SaveChanges();
            return Task.FromResult(true);
        }

        Task<bool> IRepository<Book>.Update(Book item)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Book>> IRepository<Book>.GetAll()
        {
            return Task.FromResult((IEnumerable<Book>)_context.Books);
        }

        Task<IEnumerable<Book>> IRepository<Book>.Find(Author item)
        {
            throw new NotImplementedException();
        }
    }
}
