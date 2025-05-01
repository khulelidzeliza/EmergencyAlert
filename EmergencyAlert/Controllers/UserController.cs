using Azure.Core;
using Azure;
using EmergencyAlert.Data;
using EmergencyAlert.Models;
using EmergencyAlert.Request;
using EmergencyAlert.Services.Interfaces;
using EmergencyAlert.SMTP;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmergencyAlert.Core;
using EmergencyAlert.Enums.Types;
using EmergencyAlert.Enums.Statuses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using EmergencyAlert.DTO;
using EmergencyAlert.Validator;

namespace EmergencyAlert.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly DataContext _context;
    private readonly IJWTService _jwtservice;
    private readonly IMapper _mapper;
    private readonly UserValidator _validator;

    public UserController(DataContext context, IJWTService jWTService , IMapper mapper , UserValidator validator)
    {
        _context = context;
        _jwtservice = jWTService;
        _mapper = mapper;
        _validator = validator;
    }

    [HttpPost("register")]
    public ActionResult Register(AddUser request)
    {
        var userExists = _context.Users.FirstOrDefault(u => u.Email == request.Email);
        if (userExists != null)
        {
            var response = ApiResponseFactory.BadRequestResponse("User Already Exists");
            return BadRequest(response);
        }

        var user = _mapper.Map<User>(request);

        user.HashedPassword = BCrypt.Net.BCrypt.HashPassword(request.HashedPassword);

        user.verificationCode = new Random(Guid.NewGuid().GetHashCode())
            .Next(1000, 9999).ToString();

        var result = _validator.Validate(user);
        if (!result.IsValid)
        {
            foreach (var error in result.Errors)
            {             
                return BadRequest(error);                
            }            
        }

        SMTPService smtpService = new SMTPService();
        smtpService.SendEmail(user.Email, "Verification", smtpService.GetVerificationEmailHtml(user.verificationCode));

        _context.Users.Add(user);
        _context.SaveChanges();     

        var responseSuccess = ApiResponseFactory.SuccessResponse(user);
        return Ok(responseSuccess);
    }

    [HttpPost("log-in")]

    public ActionResult Login(string email, string password)
    {
        var user = _context.Users.FirstOrDefault(x => x.Email == email);
        if (user == null)
        {
            var response = ApiResponseFactory.NotFoundResponse("user not found ");
            return NotFound(response);
        }
        else
        {
            if (BCrypt.Net.BCrypt.Verify(password, user.HashedPassword) && user.status == ACCOUNT_STATUS.VERIFIED)
            {
                var response = ApiResponseFactory.SuccessResponse("u have entered succesfully");
                return Ok(response);
            }
            else
            {
                var response = ApiResponseFactory.BadRequestResponse("something went wrong , try again");
                return BadRequest(response);
            }
        }
    }
    [HttpGet("confirm-email/{token}/{email}")]
    public ActionResult ConfirmEmail(string token, string email)
    {

        if (string.IsNullOrWhiteSpace(token) || string.IsNullOrWhiteSpace(email))
        {
            return BadRequest(ApiResponseFactory.BadRequestResponse("Token and email are required"));
        }

        var user = _context.Users.FirstOrDefault(u => u.Email == email && 
                u.verificationCode == token);

        if (user == null)
        {
            return NotFound(ApiResponseFactory.NotFoundResponse("User not found or token is invalid"));
        }

        user.status = ACCOUNT_STATUS.VERIFIED ;
        user.isEmailVerified = true ;
        user.verificationCode = null;

        _context.SaveChanges();

        return Ok(ApiResponseFactory.SuccessResponse("Verified successfully"));
    }

    [HttpGet("get-usernames/")]
    //[Authorize(Policy = "AdminOnly")]
    public ActionResult GetUserNames()
    {
        var user  = _context.Users.ToList();
        if (user  == null) {
            var badresponse = ApiResponseFactory.NotFoundResponse("user not found");
        }
        var usernames = _mapper.Map<List<UsersNamesDto>>(user);

        var response = ApiResponseFactory.SuccessResponse("there u go" );
        return Ok(usernames);
    }

    [HttpGet("get-profile/{id}")]
    
    public ActionResult GetProfile(Guid id) {

        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            var response = ApiResponseFactory.NotFoundResponse("user not found");
            return NotFound(response);

        }
        else
        {
            if (user.status == ACCOUNT_STATUS.VERIFIED)
            {
                var response = ApiResponseFactory.SuccessResponse("hello");
                return Ok(response);
            }
            else
            {
                var response = ApiResponseFactory.BadRequestResponse("user not verified");
                return BadRequest(response);
            }
        }
    }
    [HttpPut("update-profile/{id}")]
    public ActionResult UpdateProfile(Guid id, UpdateUsersNameDTO request)
    {
        var userexists = _context.Users.FirstOrDefault(u => u.Id == id);

        if (userexists == null)
        {
            var badresponse = ApiResponseFactory.NotFoundResponse("user not found");
            return NotFound(badresponse);
        }

        _mapper.Map(userexists , request);
        _context.SaveChanges();

        var returnInfo = _mapper.Map<UpdateUsersNameDTO>(userexists);

        var response = ApiResponseFactory.SuccessResponse("done");
        return Ok(response);
    }

    [HttpDelete("delete-user")]

    public ActionResult DeleteProfile(Guid id) { 
        var userExist = _context.Users.FirstOrDefault(x  => x.Id == id);

        if (userExist == null) {
            var notfoundresp = ApiResponseFactory.NotFoundResponse("user not found");
            return NotFound(notfoundresp);
        }

        _context.Users.Remove(userExist);
        _context.SaveChanges();

        var resp = ApiResponseFactory.SuccessResponse("user removed from list succesfully");
        return Ok();
    }
}




