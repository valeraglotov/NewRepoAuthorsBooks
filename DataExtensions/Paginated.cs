using Common;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace DataExtensions
{
    public class Paginated
    {
        public Paginated() : this(1, 0, 3, 0)
        {

        }

        public Paginated(int pageSize, int page, int recordsPerPage, int totalItemCount)
        {
            PageSize = pageSize;
            TotalItemCount = totalItemCount;
            Page = page;
            RecordsPerPage = recordsPerPage;
        }

        public int PageSize;
        public int TotalItemCount;


        public string SortField { get; set; } = string.Empty;
        public string CurrentSortField { get; set; } = string.Empty;
        public string CurrentSortOrder { get; set; } = string.Empty;

        public string Term { get; set; } = string.Empty;
        public int Page { get; set; }
        public int RecordsPerPage { get; set; }
    }

    public class ShowModel : Paginated
    {
        public ShowModel():this(1,0,3,0)
        {
            
        }

        public ShowModel(int pageSize, int page, int recordsPerPage, int totalItemCount)
            :base(pageSize, page, recordsPerPage, totalItemCount)
        {
            
        }

        public IEnumerable<AuthorModel> Authors { get; set; } = new List<AuthorModel>();
    }
}
