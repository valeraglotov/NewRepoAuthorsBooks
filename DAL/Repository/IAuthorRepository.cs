using System;
using System.Collections.Generic;
using System.Text;


namespace DAL.Repository
{
    public interface IAuthorRepository
    {
        IEnumerable<DAL.Entity.Author> GetAuthors();
        DAL.Entity.Author GetAuthor(int id);
        void CreateAuthor(int id);
        void UpdateAuthor(int id);
        void DeleteAuthor(int id);
    }
}
