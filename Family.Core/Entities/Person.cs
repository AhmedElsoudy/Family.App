using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family.Core.Entities
{
    public class Person : BaseEntity
    {
        public int ClanId { get; set; }
        public int BranchId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string FatherName { get; set; } = string.Empty;
        public string MotherName { get; set; } = string.Empty;
        public string GrandFatherName { get; set; } = string.Empty;
        public string GrandMotherName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? FacebookAccount { get; set; }
        public string? InstagramAccount { get; set; }

        // Navigation properties
        public Clan Clan { get; set; } = null!;
        public Branch Branch { get; set; } = null!;
        public ICollection<Notifications> Notifications { get; set; } = new HashSet<Notifications>();







    }
}
