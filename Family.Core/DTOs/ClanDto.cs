using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family.Core.DTOs
{
    public class ClanDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string PhotoUrl { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string LeaderName { get; set; } = string.Empty;
        public string EstablishmentYear { get; set; } = string.Empty;
        public string SponsorName { get; set; } = string.Empty;
        public int PersonsCount { get; set; }

    }
}
