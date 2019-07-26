using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Entities
{
    public class AuthorBL
    {
        public AuthorBL()
        {
            AuthorsBooks = new List<AuthorsBooksBL>();
        }

        public  int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<AuthorsBooksBL> AuthorsBooks { get; set; }
    }
}
