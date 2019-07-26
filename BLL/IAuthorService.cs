using System.Collections.Generic;
using System.Threading.Tasks;
using Common;
using DAL.Entity;
using DataExtensions;

namespace BLL
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorModel>> GetAllAuthors();
        Task<AuthorModel> GetAuthorById(int id);
        Task<bool> UpdateAuthor(AuthorModel item);
        Task<bool> CreateAuthor(AuthorModel item);
        Task<bool> RemoveAuthor(int id);
        //IEnumerable<AuthorModel> Search
        //    (int page, int recordsPerPage, string term, out int pageSize, out int totalItemCount);

        Task<ShowModel> Search(ShowModel pageModel);

    }
}