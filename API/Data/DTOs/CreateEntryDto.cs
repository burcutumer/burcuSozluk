using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.DTOs
{
    public class CreateEntryDto
    {
        required public string Title { get; set; }
        required public string Description { get; set; }
        public List<string> Tags { get; set; } = new();
    }
}