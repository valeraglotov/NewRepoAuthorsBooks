using System.Collections.Generic;
using System.Threading.Tasks;
using Common;
using DAL.Entity;


namespace BLL
{
    public interface IAuthorsBooksService
    {
        Task<IEnumerable<AuthorsBooksModel>> GetAll();
        Task<AuthorsBooksModel> Read(int id);
        Task<IEnumerable<BookModel>> FindAuthorsBooks(AuthorModel item);
        Task<bool> CreateAuthorsBooks(AuthorsBooksModel item);
        Task<bool> Update(AuthorsBooksModel item);
        Task<bool> Remove(int id);
    }
}