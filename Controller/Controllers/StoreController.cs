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
    public object registerStore([FromBody]StoreDTO store)
    {
        var storeModel = Model.Store.convertDTOToModel(store);
        var ownerID = Model.Owner.findToStore(store.owner.document);
        var id = storeModel.save(ownerID);
        return new
        {
            nome = store.name,
            cnpj = store.CNPJ,
            purchases = store.purchases,
            owner = store.owner,
            id = id
        };
    }
    [HttpGet]
    [Route("get/{CNPJ}")]
    public object getStoreInformation(String CNPJ)
    {
        return Model.Store.findByCNPJ(CNPJ);
    }
}