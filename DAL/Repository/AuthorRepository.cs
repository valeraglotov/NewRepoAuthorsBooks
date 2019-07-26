using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using DAL.Entity;
    
namespace DAL.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        //private AuthorService authorService;
        
        public IEnumerable<DAL.Entity.Author> GetAuthors()
        {
            return null;
        }

        public DAL.Entity.Author GetAuthor(int id)
        {
            throw new NotImplementedException();
        }

        public void CreateAuthor(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateAuthor(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteAuthor(int id)
        {
            throw new NotImplementedException();
        }
    }
}
