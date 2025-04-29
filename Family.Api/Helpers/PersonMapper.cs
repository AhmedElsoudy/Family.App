using Family.Core.DTOs;
using Family.Core.Entities;

namespace Family.Api.Helpers
{
    public static class PersonMapper
    {
        public static PersonDto ToDto(this Person entity)
        {
            return new PersonDto
            {
                Id = entity.Id,
                ClanId = entity.ClanId,
                BranchId = entity.BranchId,
                Name = entity.Name,
                PhotoUrl = entity.PhotoUrl,
                Relationship = DetermineRelationship(entity),
                ClanName = entity.Clan?.Name ?? string.Empty,
                BranchName = entity.Branch?.Name ?? string.Empty
            };
        }

        public static IEnumerable<PersonDto> ToDtos(this IEnumerable<Person> entities)
        {
            return entities.Select(e => e.ToDto());
        }

        private static string DetermineRelationship(Person person)
        {
            // Logic to determine relationship based on the family tree structure
            // This would need to be customized based on your specific rules
            return "الجد أبي الأب"; // Example return
        }
    }
}
