using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DAL.Entity
{
    public class Book : BaseEntity
    {
        public string Publisher { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AuthorsBooks> AuthorsBooks { get; set; } = new HashSet<AuthorsBooks>();
    }
}
