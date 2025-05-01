using AutoMapper;
using EmergencyAlert.Core;
using EmergencyAlert.Data;
using EmergencyAlert.DTO;
using EmergencyAlert.Enums.Types;
using EmergencyAlert.Models;
using EmergencyAlert.Request;
using EmergencyAlert.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmergencyAlert.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmergencyEventContoller : ControllerBase
{
    private readonly DataContext _context;
    private readonly IJWTService _jwtservice;
    private readonly IMapper _mapper;


    public EmergencyEventContoller(DataContext context, IJWTService jWTService, IMapper mapper)
    {
        _context = context;
        _jwtservice = jWTService;
        _mapper = mapper;
    }

    [HttpPost("add-emergency")]

    public ActionResult PostEmergencies(AddEmergencyEvent req)
    {
        var emergencyexists = _context.Events.FirstOrDefault(e => e.Title == req.Title);

        if (emergencyexists != null)
        {
            var badresponse = ApiResponseFactory.NotFoundResponse("event not found");
            return NotFound(badresponse);
        }

        var emEvent = _mapper.Map<EmergencyEvent>(req);
        emEvent.StartTime = DateTime.Now;

        _context.Events.Add(emEvent);
        _context.SaveChanges();

        var response = ApiResponseFactory.SuccessResponse("u have added emergency event");
        return Ok(response);

     
    }

    [HttpGet("get-emergencies")]

    public ActionResult GetEmergencies(EVENT_TYPE type)
    {
        var ems = _context.Events.Where(e => e.EVENT_TYPE == type).ToList();

        if (ems == null)
        {
            return BadRequest();
        }   
        else {

            var result = _mapper.Map<List<EmergencyEvent>>(ems);
            
            return  Ok(result);
                }
    }


    [HttpGet("get-emergency/{id}")]
    public ActionResult GetSpecific(Guid id) 
    {
        var emgExists = _context.Events.FirstOrDefault(e => e.Id == id);
        if (emgExists == null) {
            var badResponse = ApiResponseFactory.NotFoundResponse("Event not found");
            return NotFound(badResponse);
        }

        var result = _mapper.Map<AddEmergencyEvent>(emgExists);
        return Ok(result);
    }

}