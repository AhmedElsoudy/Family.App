using Family.Core.DTOs;
using Family.Core.Entities;

namespace Family.Api.Helpers
{
    public static class BranchMapper
    {
        public static BranchDto ToDto(this Branch entity)
        {
            return new BranchDto
            {
                Id = entity.Id,
                ClanId = entity.ClanId,
                Name = entity.Name,
                PhotoUrl = entity.PhotoUrl,
                LeaderName = entity.LeaderName,
                EstablishmentYear = entity.EstablishmentYear,
                Region = entity.Region,
                PersonsCount = entity.Persons?.Count ?? 0
            };
        }

        public static IEnumerable<BranchDto> ToDtos(this IEnumerable<Branch> entities)
        {
            return entities.Select(e => e.ToDto());
        }
    }
}
