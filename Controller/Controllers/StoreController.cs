using Microsoft.AspNetCore.Mvc;
using DTO;
using Model;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers;

[ApiController]
[Route("Store")]
public class StoreController : ControllerBase
{
    [HttpGet]
    [Route("all")]
    public List<object> getAll()
    {
        return Model.Store.getAllStores();
    }
    [HttpPost]
    [Route("register")]
    public IActionResult registerStore([FromBody]StoreDTO store)
    {
        var OwnerID = UserToken.GetIdFromRequest(Request.Headers["Authorization"].ToString());
        var storeModel = Model.Store.convertDTOToModel(store);
        var id = storeModel.save(OwnerID);
        return Ok();
    }
    [HttpGet]
    [Route("get")]
    public IActionResult getStoreInformation()
    {
        var OwnerID = UserToken.GetIdFromRequest(Request.Headers["Authorization"].ToString());
        var storeDAO = Model.Store.getByOwner(OwnerID);
        if(storeDAO==null){
            return BadRequest();
        }
        else{
            return Ok();
        }
    }
}