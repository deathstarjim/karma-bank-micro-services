namespace KarmaBank.User.Service.Dtos.VolunteerDtos
{
    public record VolunteerDto(Guid Id, Guid OrganizationId, string FullName, string Email);

    public record CreateVolunteerDto(Guid OrganizationId, string FullName, string Email);

    public record UpdateVolunteerDto(string FullName, string Email);
}
