using KarmaBank.User.Service.Dtos.AdministratorDtos;
using Microsoft.AspNetCore.Mvc;

namespace KarmaBank.User.Service.Controllers
{
    [ApiController]
    [Route("administrators")]
    public class AdministratorsController : ControllerBase
    {
        private static readonly List<AdministratorDto> _administrators = new()
        {
            new AdministratorDto(Guid.NewGuid(), Guid.NewGuid(), "jpiller", "Jim Piller", "P@ssword12!", "", "jim_piller@yahoo.com"),
            new AdministratorDto(Guid.NewGuid(), Guid.NewGuid(), "eanderson", "Erik Anderson", "P@ssword12!", "", "eanderson@whatever.com" )
        };

        [HttpGet]
        [Route("administrators")]
        public IEnumerable<AdministratorDto> GetAdministrators()
        {
            return _administrators;
        }



    }
}