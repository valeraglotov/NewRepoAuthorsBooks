using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Entities
{
    public class BookBL
    {
        public BookBL()
        {
            AuthorsBooks = new List<AuthorsBooksBL>();
        }
        public int Id { get; set; }
        public string Publisher { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AuthorsBooksBL> AuthorsBooks { get; set; }
    }
}
