using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;
using DAL.Entity;

namespace DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Read(int id);
        Task<IEnumerable<Book>> Find(Author item);
        Task<bool> Create(T item);
        Task<bool> Update(T item);
        Task<bool> Remove(int id);
    }
}
