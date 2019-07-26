using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Entities
{
    public class AuthorsBooksBL
    {

        public int Id { get; set; }
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public string Country { get; set; }

        public virtual BookBL Book { get; set; }

        public virtual AuthorBL Author { get; set; }
    }
}
