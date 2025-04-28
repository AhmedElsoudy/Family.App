using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family.Core.Entities
{
    public class Branch : BaseEntity
    {
        public int ClanId { get; set; }
        public string Name { get; set; } = string.Empty;

        // Navigation properties
        public Clan Clan { get; set; } = null!;
        public ICollection<Person> Persons { get; set; } = new HashSet<Person>();


    }
}
