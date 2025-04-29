using Family.Core.DTOs;
using Family.Core.Entities;

namespace Family.Api.Helpers
{
    public static class PersonDetailsMapper
    {
        public static PersonDetailsDto ToDetailsDto(this Person entity)
        {
            var age = CalculateAge(entity.BirthDate);

            return new PersonDetailsDto
            {
                Id = entity.Id,
                Name = entity.Name,
                PhotoUrl = entity.PhotoUrl,
                BirthDate = entity.BirthDate.ToString("yyyy-MM-dd"),
                BirthPlace = entity.Address,
                Age = $"{age} سنة",  
                ClanName = entity.Clan?.Name ?? string.Empty,
                BranchName = entity.Branch?.Name ?? string.Empty,
                FacebookAccount = entity.FacebookAccount,
                InstagramAccount = entity.InstagramAccount,
                PhoneNumber = entity.PhoneNumber
            };
        }

        private static int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--;
            return age;
        }

        //public static IEnumerable<PersonDto> ToDtos(this IEnumerable<Person> entities)
        //{
        //    return entities.Select(e => e.ToDto());
        //}

    }
}
