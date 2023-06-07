using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.DTOs
{
    public class Response<T>
    {
        public object? Error { get; set; }
        public T? Data { get; set; }
    }
}