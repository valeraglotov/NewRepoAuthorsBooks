using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Common;
using DAL.Entity;
using DAL.Interfaces;
using DataExtensions;

namespace BLL
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepository<Author> _repository;

        public AuthorService(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateAuthor(AuthorModel item)
        {
            var mapper = Mapper.Map<Author>(item);
            return Mapper.Map<bool>(await _repository.Create(mapper));
        }

        public async Task<IEnumerable<AuthorModel>> GetAllAuthors()
        {
            IEnumerable<Author> authors = await _repository.GetAll();
            return Mapper.Map<IEnumerable<AuthorModel>>(authors);
        }

        public async Task<AuthorModel> GetAuthorById(int id)
        {
            return Mapper.Map<AuthorModel>(await _repository.Read(id));
        }

        public async Task<bool> RemoveAuthor(int id)
        {
            return Mapper.Map<bool>(await _repository.Remove(id));
        }

        public async Task<bool> UpdateAuthor(AuthorModel item)
        {
            var mapper = Mapper.Map<Author>(item);
            return await Task.FromResult(await _repository.Update(mapper));
        }

        public async Task<ShowModel> Search(ShowModel pageModel)
        {
            IEnumerable<Author> queryable = await _repository.GetAll();
            ShowModel model = pageModel;

            if (!string.IsNullOrEmpty(model.Term))
            {
                queryable = queryable.Where
                (c => c.Id.ToString().Equals(model.Term)
                          || c.FirstName.Equals(model.Term)
                          || c.LastName.Equals(model.Term));
            }

            model.TotalItemCount = queryable.Count();
            model.PageSize = (int)Math.Ceiling((double)model.TotalItemCount / model.RecordsPerPage);
            model.Page = model.Page > model.PageSize || model.Page < 1 ? 1 : model.Page;

            var skipped = (model.Page - 1) * model.RecordsPerPage;
            queryable = queryable.Skip(skipped).Take(model.RecordsPerPage);

            model.Authors = queryable.Select(u => new AuthorModel
            {
                Id = u.Id,
                LastName = u.LastName,
                FirstName = u.FirstName
            }).ToList();

            return model;
        }
    }
}
