using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using DTO;
using Model;

namespace Controller.Controllers;

[ApiController]
[Route("Owner")]
public class OwnerController : ControllerBase
{
    public IConfiguration _configuration;

    public OwnerController(IConfiguration config){
        _configuration = config;
    }

    [HttpPost]
    [Route("login")]
    public IActionResult tokenGenerate([FromBody]OwnerDTO login)
    {
        Response.Headers.Add("Access-Control-Allow-Origin", "*");
        if (login != null && login.login != null && login.passwd != null)
        {
            var user = Model.Owner.getByLogin(login);
            if(user != null)
            {
                var claims = new[]{
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("UserId", Model.Owner.findId(user).ToString()),
                    new Claim("UserName", user.name),
                    new Claim("Email", user.email),
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: signIn);
                
                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }
            else
            {
                return BadRequest("InvalidCredentials");    
            }
        }
        else
        {
            return BadRequest();
        }
    }

    [HttpPost]
    [Route("register")]
    public IActionResult registerOwner([FromBody] OwnerDTO owner)
    {
        var ownerModel = Model.Owner.convertDTOToModel(owner);
        var existe = ownerModel.verify(owner.login);
        if(existe){
            return null;
        }else{
            var id = ownerModel.save();
            return Ok(id);
        }
    }

    [HttpGet]
    [Route("get")]
    public IActionResult getInformations()
    {
        var OwnerID = UserToken.GetIdFromRequest(Request.Headers["Authorization"].ToString());
        var ownerDTO = Model.Owner.getById(OwnerID);
        return Ok(ownerDTO);
    }
}