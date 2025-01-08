using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Entities
{
    [Table("Tags")]
    public class Tag
    {
        public int Id { get; set; }
        required public string Name { get; set; }
        public List<EntryItem> EntryItems { get; set; } = new();
    }
}