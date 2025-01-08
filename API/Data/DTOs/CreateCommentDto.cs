using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.DTOs
{
    public class CreateCommentDto
    {
        required public string Text { get; set; }
    }
}