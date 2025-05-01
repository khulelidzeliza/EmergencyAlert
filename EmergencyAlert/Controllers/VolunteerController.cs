using AutoMapper;
using EmergencyAlert.Core;
using EmergencyAlert.Data;
using EmergencyAlert.DTO;
using EmergencyAlert.Enums.Statuses;
using EmergencyAlert.Models;
using EmergencyAlert.Request;
using EmergencyAlert.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmergencyAlert.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolunteerController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IJWTService _jwtservice;
        private readonly IMapper _mapper;


        public VolunteerController(DataContext context, IJWTService jWTService , IMapper mapper)
        {
            _context = context;
            _jwtservice = jWTService;
            _mapper = mapper;
        }

        [HttpPost("register-as-volunteer")]
        public ActionResult RegisterVolunteer (AddVolunteer req)
        {
            if (req == null)
            {
                var notfoundresponse = ApiResponseFactory.NotFoundResponse("user not found");
                return NotFound(notfoundresponse);
                 
            }

            var userExists = _context.Users.Any(u => u.Id == req.UserId);
            var volunteer = _mapper.Map<Volunteer>(req);

            _context.Volunteers.Add(volunteer);
            _context.SaveChanges();

            var response = ApiResponseFactory.SuccessResponse("succesfully joined ad volunteer");
            return Ok(response);
        }

        [HttpGet("get-volunteers")]
        public async Task<ActionResult<IEnumerable<VolunteersDetailDto>>> GetVolunteerDetails()
        {
            var details = _context.Volunteers.Include(v => v.User)
                .Select(u => u.User)
                .ToList();
            if(details == null)
            {
                var badresponse = ApiResponseFactory.NotFoundResponse("not found");
                return BadRequest(badresponse);
            }
            var result = _mapper.Map<List<VolunteersDetailDto>>(details);

            var response = ApiResponseFactory.SuccessResponse("there u go");
            return Ok(response);
        }


        [HttpPut("update-volunteer/{id}")]

        public ActionResult UpdateVolunteer(Guid id, UpdateVolunteerDto vdto)
        {
            var vExists = _context.Volunteers.FirstOrDefault(v => v.Id == id);

            if (vExists == null)
            {
                var badResponse = ApiResponseFactory.NotFoundResponse("no volunteers found ");
                return NotFound(badResponse);
            }

            _mapper.Map(vdto , vExists);

            _context.SaveChanges();

                var response = ApiResponseFactory.SuccessResponse(".");
            return Ok(response);
        }


        [HttpPut("update-volunteer-status/{id}")]

        public ActionResult UpdateStatus(Guid id , AVAILABILITY_STATUS status)
        {
            var vToUpdate = _context.Volunteers.FirstOrDefault(v => v.Id == id);

            if (vToUpdate == null) {
                var badresponse = ApiResponseFactory.NotFoundResponse("volunteer not found");
                return BadRequest(badresponse);
            }

            vToUpdate.AvailabilityStatus = status;
            _context.SaveChanges();

            var response = ApiResponseFactory.SuccessResponse("succesfully changed status");
            return Ok(response);
         }

        [HttpDelete("remove-volunteer")]

        public ActionResult RemoveVolunteer (Guid id)
        {
            var vExists = _context.Volunteers.FirstOrDefault(v => v.Id == id);

            if (vExists == null)
            {
                var badresponse = ApiResponseFactory.NotFoundResponse("volunteer not found");
                return NotFound(badresponse);
            }

            _context.Volunteers.Remove(vExists);
            _context.SaveChanges();

            var resp = ApiResponseFactory.SuccessResponse("volunteer removed from list succesfully");
            return Ok();
        }
    }
}
