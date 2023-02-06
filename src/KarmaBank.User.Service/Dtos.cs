namespace KarmaBank.User.Service.Dtos.UsersDto
{
    public record VolunteerDto(Guid VolunteerId, Guid OrganizationId, string FullName, string Email);

    public record AdministratorDto(Guid Id, Guid OrganizationId, string UserName, string FullName, string Password, string PasswordSalt, string Email);

    public record CreateVolunteerDto(Guid OrganizationId, string FullName, string Email);

    public record CreateAdministratorDto(Guid OrganizationId, string UserName, string FullName, string Password, string Email);

    public record UpdateVolunteerDto(string FullName, string Email);

    public record UpdateAdministratorDto(string UserName, string FullName, string Password, string Email);
}