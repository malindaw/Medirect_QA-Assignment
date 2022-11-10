using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreAPICaller.Entity
{
    public class Tag
    {
        public Tag(long id, string  name)
        {
            Id = id;
            Name = name;
        }
        public long Id { get; set; }
        public string? Name { get; set; }
    }
}
