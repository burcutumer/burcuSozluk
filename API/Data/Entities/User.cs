using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace API.Data.Entities
{
    public class User : IdentityUser<int>
    {
        public string NickName { get; set; } = null!;
        public List<Entry> Entries { get; set; } = new();
    }
}