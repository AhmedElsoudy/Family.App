using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family.Core.Entities
{
    public class Clan : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string PhotoUrl { get; set; } = string.Empty;  // صورة العشيرة
        public string Region { get; set; } = string.Empty;    // المنطقة
        public string LeaderName { get; set; } = string.Empty; // اسم زعيم العشيرة
        public string EstablishmentYear { get; set; } = string.Empty; // سنة التأسيس
        public string SponsorName { get; set; } = string.Empty; // اسم راعي العشيرة

        // Navigation property
        public ICollection<Branch> Branches { get; set; } = new HashSet<Branch>();
    }


}
}
