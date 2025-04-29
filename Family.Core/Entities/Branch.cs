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
        public string Name { get; set; } = string.Empty;  // اسم الفرع
        public string PhotoUrl { get; set; } = string.Empty;  // صورة الفرع
        public string LeaderName { get; set; } = string.Empty;  // اسم رئيس الفرع
        public string EstablishmentYear { get; set; } = string.Empty;  // سنة التأسيس
        public string Region { get; set; } = string.Empty;  // المنطقة

        // Navigation properties
        public Clan Clan { get; set; } = null!;
        public ICollection<Person> Persons { get; set; } = new HashSet<Person>();


    }
}
