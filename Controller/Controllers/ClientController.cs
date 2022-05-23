using System;
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
[Route("Client")]
public class ClientController : ControllerBase
{
    public IConfiguration _configuration;

    public ClientController(IConfiguration config){
        _configuration = config;
    }

    [HttpPost]
    [Route("login")]
    public IActionResult tokenGenerate([FromBody]ClientDTO login)
    {
        if (login != null && login.login != null && login.passwd != null)
        {
            var user = Model.Client.getByLogin(login);

            if(user != null)
            {
                var claims = new[]{
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("UserId", Model.Client.findId(user).ToString()),
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
    public object registerClient([FromBody] ClientDTO client)
    {
        var clientModel = Model.Client.convertDTOToModel(client);
        var id = clientModel.save();
        return new
        {
            nome = client.name,
            dataAniversario = client.date_of_birth,
            documento = client.document,
            email = client.email,
            telefone = client.address,
            login = client.login,
            senha = client.passwd,
            endereco = client.address,
            id = id
        };
    }
    [HttpGet]
    [Route("get/{document}")]
    public object getInformations(String document)
    {
        return Model.Client.findByDocument(document);
    }
}