using Microsoft.AspNetCore.Mvc;
using DTO;
using Model;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class OwnerController : ControllerBase
{
    [HttpPost]
    [Route("register")]
    public object registerOwner([FromBody] OwnerDTO owner)
    {
        var ownerModel = Model.Owner.convertDTOToModel(owner);
        var id = ownerModel.save();
        return new
        {
            nome = owner.name,
            dataAniversario = owner.date_of_birth,
            documento = owner.document,
            email = owner.email,
            telefone = owner.address,
            login = owner.login,
            senha = owner.passwd,
            endereco = owner.address,
            id = id
        };
    }
    [HttpGet]
    [Route("get/{document}")]
    public object getInformations(String document)
    {
        var ownerInfo = Model.Owner.findByDocument(document);
        return ownerInfo;
    }
}