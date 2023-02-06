using KarmaBank.Organization.Service.Dtos.OrganizationDto;
using Microsoft.AspNetCore.Mvc;

namespace KarmaBank.Organization.Service.Controllers
{
    [ApiController]
    [Route("organizations")]
    public class OrganizationController : ControllerBase
    {
        private static readonly List<OrganizationDto> _organizations = new()
        {
            new OrganizationDto(Guid.NewGuid(), "Bob''s Widgets"),
            new OrganizationDto(Guid.NewGuid(), "John Wick Solutions")
        };

        [HttpGet]
        public IEnumerable<OrganizationDto> Get()
        {
            return _organizations;
        }

        //Get organizations/12345
        [HttpGet("{id}")]
        public OrganizationDto Get(Guid id)
        {
            var org = _organizations.FirstOrDefault(org => org.Id == id);
            return org;
        }


    }
}