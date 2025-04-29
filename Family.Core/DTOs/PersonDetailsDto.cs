using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family.Core.DTOs
{
    public class PersonDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PhotoUrl { get; set; } = string.Empty;
        public string BirthDate { get; set; } = string.Empty;    // تاريخ الميلاد
        public string BirthPlace { get; set; } = string.Empty;   // مكان الميلاد
        public string Age { get; set; } = string.Empty;
        public string ClanName { get; set; } = string.Empty;
        public string BranchName { get; set; } = string.Empty;
        public string? FacebookAccount { get; set; }
        public string? InstagramAccount { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
