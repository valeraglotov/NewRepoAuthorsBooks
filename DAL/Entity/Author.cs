using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DAL.Entity
{
    public class Author : BaseEntity
    {
        public Author()
        {
            AuthorsBooks = new HashSet<AuthorsBooks>();
        }
      
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<AuthorsBooks> AuthorsBooks { get; set; }
    }
}
