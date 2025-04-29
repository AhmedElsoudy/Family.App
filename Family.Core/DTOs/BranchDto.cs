using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family.Core.DTOs
{
    public class BranchDto
    {
        public int Id { get; set; }
        public int ClanId { get; set; }
        public string Name { get; set; } = string.Empty;  // فرع العوامرة الشمالي
        public string PhotoUrl { get; set; } = string.Empty;
        public string LeaderName { get; set; } = string.Empty;  // اسم الزعيم - محمد العبدالله
        public string EstablishmentYear { get; set; } = string.Empty;  // تأسيس - ١٩٧٢
        public string Region { get; set; } = string.Empty;  // المنطقة - غير محدد
        public int PersonsCount { get; set; } // عدد الأفراد - ١٣٠ فرد

       
    }
}
