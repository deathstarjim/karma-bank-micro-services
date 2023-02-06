namespace KarmaBank.Organization.Service.Dtos.OrganizationDto
{
    public record OrganizationDto(Guid Id, string Name);

    public record CreateOrganizationDto(Guid Id, string Name);

    public record UpdateOrganizationDto(string Name);
}