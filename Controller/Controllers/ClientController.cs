using Microsoft.AspNetCore.Mvc;
using DTO;
using Model;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase
{
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