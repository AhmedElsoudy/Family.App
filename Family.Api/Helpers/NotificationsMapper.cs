using Family.Core.DTOs;
using Family.Core.Entities;

namespace Family.Api.Helpers
{
    public static class NotificationsMapper
    {
        public static NotificationsDto ToDto(this Notifications entity)
        {
            return new NotificationsDto
            {
                Id = entity.Id,
                PersonId = entity.PersonId,
                Title = entity.Title,
                Body = entity.Body,
                FormattedTime = FormatTime(entity.CreatedAt),
                GroupDate = GetGroupDate(entity.CreatedAt)
            };
        }

        public static IEnumerable<NotificationsDto> ToDtos(this IEnumerable<Notifications> entities)
        {
            return entities.Select(e => e.ToDto());
        }

        private static string FormatTime(DateTime dateTime)
        {
            string period = dateTime.Hour >= 12 ? "PM" : "AM";
            int hour = dateTime.Hour % 12;
            if (hour == 0) hour = 12;
            return $"{period} {hour:00}:{dateTime.Minute:00}";
        }

        private static string GetGroupDate(DateTime dateTime)
        {
            var today = DateTime.Today;
            var date = dateTime.Date;

            if (date == today)
                return "اليوم";
            if (date == today.AddDays(-1))
                return "أمس";
            if (date > today.AddDays(-7))
                return dateTime.ToString("dddd", new System.Globalization.CultureInfo("ar-SA"));

            return dateTime.ToString("MMM dd", new System.Globalization.CultureInfo("ar-SA"));
        }
    }
}
