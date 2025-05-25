using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Utilities.Helpers
{
    public class Pagination<T> where T : class
    {
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public IEnumerable<T> CurrentData { get; set; }
        public int Limit { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public Pagination(IEnumerable<T>data, int page, int limit) 
        {
            CurrentPage = page;
            Limit = limit;
            TotalPage = (int)Math.Ceiling(data.Count()/(double)Limit);
            //int total = data.Count() / limit;
            //if (data.Count() % limit > 0) total++;
            CurrentData = data.Skip((page -1) * limit).Take(limit);
            Start = CurrentPage - 2 < 1 ? 1 : CurrentPage - 2;
            End = CurrentPage + 2 > TotalPage ? TotalPage : CurrentPage + 2;
        }
    }
}
