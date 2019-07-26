using System.Collections.Generic;
using System.Threading.Tasks;
using Common;

namespace BLL
{
    public interface IBookService
    {
        Task<IEnumerable<BookModel>> GetAllBooks();
        Task<BookModel> GetBookById(int id);
        Task<bool> UpdateBook(BookModel item);
        Task<bool> CreateBook(BookModel item);
        Task<bool> RemoveBook(int id);
    }
}