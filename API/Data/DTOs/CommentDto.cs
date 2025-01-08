using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Entities;

namespace API.Data.DTOs
{
    public class CommentDto
    {
        public int Id { get; set; }
        required public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        required public UserDto User { get; set; }
    }
}