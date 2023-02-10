using System.ComponentModel.DataAnnotations;

namespace KarmaBank.User.Service.Dtos.VolunteerDtos
{
    public record VolunteerDto(Guid Id, Guid OrganizationId, string FullName, string Email);

    public record CreateVolunteerDto([Required] Guid OrganizationId, string FullName, string Email);

    public record UpdateVolunteerDto([Required] string FullName, string Email);
}
