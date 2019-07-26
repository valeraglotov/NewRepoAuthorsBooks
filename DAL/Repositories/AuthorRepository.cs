using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Data;
using DAL.Entity;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class AuthorRepository : IRepository<Author>
    {
        private readonly ApplicationDbContext _context;

        public AuthorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Author> Read(int id)
        {
            return await _context.Authors.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<bool> Remove(int id)
        {
            _context.Authors.Remove(_context.Authors.Single(a => a.Id == id));
            //_context.Entry(item).State = EntityState.Deleted;
            return Convert.ToBoolean(await _context.SaveChangesAsync());
        }

        public async Task<bool> Create(Author item)
        {
            await _context.Authors.AddAsync(item);
            _context.Entry(item).State = EntityState.Added;
            return Convert.ToBoolean(await _context.SaveChangesAsync());
        }

        public async Task<bool> Update(Author item)
        {
            _context.Authors.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            return Convert.ToBoolean(await _context.SaveChangesAsync());
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            return await GetAllQueryable();
        }

        private async Task<IQueryable<Author>> GetAllQueryable()
        {
            var authors = await _context.Authors.ToListAsync();
            return authors.AsQueryable();
        }

        public Task<IEnumerable<Book>> Find(Author item)
        {
            throw new NotImplementedException();
        }

    }
}
