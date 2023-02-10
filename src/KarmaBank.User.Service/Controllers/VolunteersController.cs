using KarmaBank.User.Service.Dtos.VolunteerDtos;
using Microsoft.AspNetCore.Mvc;

namespace KarmaBank.User.Service.Controllers
{
    [Route("volunteers")]
    [ApiController]
    public class VolunteersController : ControllerBase
    {
        private static readonly List<VolunteerDto> _volunteers = new()
        {
            new VolunteerDto(Guid.NewGuid(), Guid.NewGuid(), "Bob Smith", "bsmith@gmail.com"),
            new VolunteerDto(Guid.NewGuid(), Guid.NewGuid(), "Tiger Woods", "twoods@tiger.com"),
            new VolunteerDto(Guid.NewGuid(), Guid.NewGuid(), "Jack Nicklaus", "jack@golf.com")
        };

        [HttpGet]
        public IEnumerable<VolunteerDto> Get()
        {
            return _volunteers;
        }

        [HttpGet]
        [Route("{id}")]
        public VolunteerDto GetById(Guid id)
        {
            var volunteer = _volunteers.Where(vol => vol.Id == id).FirstOrDefault();
            return volunteer;
        }

        //POST /volunteers/
        [HttpPost]
        public ActionResult Post(CreateVolunteerDto createVolunteerDto)
        {
            var volunteer = new VolunteerDto(Guid.NewGuid(), Guid.NewGuid(), createVolunteerDto.FullName, createVolunteerDto.Email);
            _volunteers.Add(volunteer);
            return CreatedAtAction(nameof(GetById), new { id = volunteer.Id }, volunteer);
        }

        //PUT /volunteers/{id}
        [HttpPut]
        public IActionResult Put(Guid Id, UpdateVolunteerDto updateVolunteerDto)
        {
            var volunteer = _volunteers.FirstOrDefault(vol => vol.Id == Id);

            var updateVolunteer = volunteer with
            {
                FullName = volunteer.FullName,
                Email = volunteer.Email
            };

            var index = _volunteers.FindIndex(vol => vol.Id == Id);

            _volunteers[index] = updateVolunteer;

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(Guid Id)
        {
            var index = _volunteers.FindIndex(vol => vol.Id == Id);

            _volunteers.RemoveAt(index);

            return NoContent();
        }
    }
}
