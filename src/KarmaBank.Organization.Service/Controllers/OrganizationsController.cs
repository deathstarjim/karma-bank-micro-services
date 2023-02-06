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
        public OrganizationDto GetById(Guid id)
        {
            var org = _organizations.FirstOrDefault(org => org.Id == id);
            return org;
        }

        [HttpPost]
        public ActionResult Post(CreateOrganizationDto createOrganizationDto)
        {
            var org = new OrganizationDto(Guid.NewGuid(), createOrganizationDto.Name);
            _organizations.Add(org);
            return CreatedAtAction(nameof(GetById), new { id = org.Id }, org);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, UpdateOrganizationDto updateOrganizationDto)
        {
            var org = _organizations.FirstOrDefault(org => org.Id == id);

            var updatedOrg = org with
            {
                Name = updateOrganizationDto.Name
            };

            var index = _organizations.FindIndex(org => org.Id == id);
            _organizations[index] = updatedOrg;

            return NoContent();

        }
    }
}