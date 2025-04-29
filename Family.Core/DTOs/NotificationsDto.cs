using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family.Core.DTOs
{
    public class NotificationsDto
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string FormattedTime { get; set; } = string.Empty;  // "PM 02:52" format
        public string GroupDate { get; set; } = string.Empty;

    }
}
