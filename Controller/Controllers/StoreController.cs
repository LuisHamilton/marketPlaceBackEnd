using Microsoft.AspNetCore.Mvc;
using DTO;
using Model;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class StoreController : ControllerBase
{
    public void getAllStore()
    {
        
    }
    [HttpPost]
    [Route("register")]
    public object registerStore(StoreDTO store)
    {
        var storeModel = Model.Store.convertDTOToModel(store);
        var ownerInstance = Model.Owner.find(store.owner.document);
        var id = storeModel.save(ownerInstance);
        return new
        {
            nome = store.name,
            cnpj = store.CNPJ,
            purchases = store.purchases,
            owner = store.owner,
            id = id
        };
    }
    public void getStoreInformation(StoreDTO store)
    {
        
    }
}