using Microsoft.AspNetCore.Mvc;
using DTO;
using Model;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers;

[ApiController]
[Route("Address")]
public class AddressController : ControllerBase
{
    [HttpPost]
    [Route("register")]
    public object registerAddress([FromBody] AddressDTO address)
    {
        var addressModel = Model.Address.convertDTOToModel(address);
        var id = addressModel.save();
        return new
        {
            rua = address.street,
            estado = address.state,
            cidade = address.city,
            pais = address.country,
            codigoPostal = address.postal_code,
            id = id
        };
    }
    [HttpDelete]
    [Route("delete")]
    public void removeAddress([FromBody] AddressDTO address)
    {
        
    }
    [HttpPut]
    [Route("update")]
    public void updateAddress([FromBody] AddressDTO address)
    {
        
    }
}