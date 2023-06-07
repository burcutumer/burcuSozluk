using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.DTOs
{
    public class TagDto
    {
         public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
     public class CreateTagDto
    {
        public string Name { get; set; } = null!;
    }
}