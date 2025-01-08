using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.DTOs
{
    public class TagDto
    {
         public int Id { get; set; }
        required public string Name { get; set; }
    }
     public class CreateTagDto
    {
        required public string Name { get; set; }
    }
}