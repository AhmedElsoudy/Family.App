using Family.Core.DTOs;
using Family.Core.Entities;

namespace Family.Api.Helpers
{
    public static class ClanMapper
    {
        public static ClanDto ToDto(this Clan entity)
        {
            return new ClanDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                PhotoUrl = entity.PhotoUrl,
                Region = entity.Region,
                LeaderName = entity.LeaderName,
                EstablishmentYear = entity.EstablishmentYear,
                SponsorName = entity.SponsorName,
                PersonsCount = entity.Branches?.Sum(b => b.Persons?.Count ?? 0) ?? 0
            };
        }

        public static IEnumerable<ClanDto> ToDtos(this IEnumerable<Clan> entities)
        {
            return entities.Select(e => e.ToDto());
        }

    }
}
