using System.ComponentModel.DataAnnotations;

namespace KarmaBank.User.Service.Dtos.AdministratorDtos
{
    public record AdministratorDto(Guid Id, [Required] Guid OrganizationId, string UserName, string FullName, string Password, string PasswordSalt, string Email);

    public record CreateAdministratorDto(Guid Id, [Required] Guid OrganizationId, string UserName, string FullName, string Password, string Email);

    public record UpdateAdministratorDto(string UserName, string FullName, string Password, string Email);
}