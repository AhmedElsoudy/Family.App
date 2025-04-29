using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family.Core.DTOs
{
    public class PersonDto
    {
        public int Id { get; set; }
        public int ClanId { get; set; }
        public int BranchId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PhotoUrl { get; set; } = string.Empty;
        public string Relationship { get; set; } = string.Empty;  // الجد أبي الأب, الأم, etc.
        public string ClanName { get; set; } = string.Empty;     // اسم العشيرة
        public string BranchName { get; set; } = string.Empty;

    }
}
