using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;
using DAL.Entity;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace DAL.Repositories
{
    public class AuthorsBooksRepository : IRepository<Entity.AuthorsBooks>
    {
        private readonly ApplicationDbContext _context;

        public AuthorsBooksRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Entity.AuthorsBooks> Read(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Create(Entity.AuthorsBooks item)
        {
            var author = _context.Authors.FirstOrDefault(x => x.Id == item.AuthorId);
            var book = _context.Books.FirstOrDefault(x => x.Id == item.BookId);

            if (author == null || book == null)
            {
                return Convert.ToBoolean(await _context.SaveChangesAsync());
            }

            _context.AuthorsBooks.Add(item);
            return Convert.ToBoolean(await _context.SaveChangesAsync());
        }

        public Task<bool> Update(Entity.AuthorsBooks item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Entity.AuthorsBooks>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Book>> Find(Author item)
        {
            return await _context.Books.Where(x => x.AuthorsBooks.Any(ab => ab.AuthorId == item.Id)).ToListAsync();
        }
    }
}
