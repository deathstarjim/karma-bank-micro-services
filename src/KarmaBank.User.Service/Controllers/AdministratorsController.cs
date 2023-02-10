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

        [HttpGet("{id}")]
        public ActionResult<AdministratorDto> GetById(Guid id)
        {
            var admin = _administrators.Where(admin => admin.Id == id).FirstOrDefault();

            if(admin == null)
                return NotFound();

            return admin;
        }

        //POST /volunteers/
        [HttpPost]
        public ActionResult Put(CreateAdministratorDto createAdministratorDto)
        {
            var administrator = new AdministratorDto(Guid.NewGuid(), Guid.NewGuid(), createAdministratorDto.UserName, createAdministratorDto.FullName, 
                createAdministratorDto.Password, "", createAdministratorDto.Email);

            _administrators.Add(administrator);

            return CreatedAtAction(nameof(GetById), new { id = createAdministratorDto.Id }, createAdministratorDto);
        }

        //PUT /administrators/{id}
        [HttpPut("{id}")]
        public IActionResult Put(Guid Id, UpdateAdministratorDto updateAdministratorDto)
        {
            var administrator = _administrators.FirstOrDefault(vol => vol.Id == Id);

            if (administrator == null)
                return NotFound();

            var updateAdministrator = administrator with
            {
                FullName = administrator.FullName,
                Email = administrator.Email
            };

            var index = _administrators.FindIndex(vol => vol.Id == Id);

            _administrators[index] = updateAdministrator;

            return NoContent();
        }

        //DELETE /administrators/id
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid Id)
        {
            var index = _administrators.FindIndex(vol => vol.Id == Id);

            if (index > 0)
                return NotFound();

            _administrators.RemoveAt(index);

            return NoContent();
        }

    }
}