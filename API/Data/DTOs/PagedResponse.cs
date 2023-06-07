using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.DTOs
{
    public class PagedResponse<T> : Response<T>
    {
        public int Skip { get; set; }
        public int Limit { get; set; }
        public int Total { get; set; }
    }
}