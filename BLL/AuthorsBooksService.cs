using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Common;
using DAL.Entity;
using DAL.Interfaces;

namespace BLL
{
    public class AuthorsBooksService : IAuthorsBooksService
    {
        private readonly IRepository<DAL.Entity.AuthorsBooks> _repository;

        public AuthorsBooksService(IRepository<DAL.Entity.AuthorsBooks> repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateAuthorsBooks(AuthorsBooksModel item)
        {
            var mapper = Mapper.Map<DAL.Entity.AuthorsBooks>(item);
            return Mapper.Map<bool>(await _repository.Create(mapper));
        }

        public async Task<IEnumerable<BookModel>> FindAuthorsBooks(AuthorModel item)
        {
            var author = Mapper.Map<Author>(item);
            var autorsBooks = await _repository.Find(author);
            var bookModels = autorsBooks.Select(book =>
                new BookModel()
                {
                    Id = book.Id,
                    Name = book.Name,
                    Publisher = book.Publisher
                }).ToArray();

            return Mapper.Map<IEnumerable<BookModel>>(bookModels);
        }

        public Task<IEnumerable<AuthorsBooksModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<AuthorsBooksModel> Read(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(AuthorsBooksModel item)
        {
            throw new NotImplementedException();
        }
    }
}
