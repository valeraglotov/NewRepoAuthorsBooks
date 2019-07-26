using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Common;
using DAL.Entity;
using DAL.Interfaces;

namespace BLL
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _repository;

        public BookService(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateBook(BookModel item)
        {
            var mapper = Mapper.Map<Book>(item);
            return Mapper.Map<bool>(await _repository.Create(mapper));
        }

        public async Task<IEnumerable<BookModel>> GetAllBooks()
        {
            IEnumerable<Book> books = await _repository.GetAll();
            return Mapper.Map<IEnumerable<BookModel>>(books);
        }

        public Task<BookModel> GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveBook(int id)
        {
            return Mapper.Map<bool>(await _repository.Remove(id));
        }

        public Task<bool> UpdateBook(BookModel item)
        {
            throw new NotImplementedException();
        }
    }

}
