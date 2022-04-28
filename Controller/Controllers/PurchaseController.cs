using Microsoft.AspNetCore.Mvc;
using DTO;
using Model;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class PurchaseController : ControllerBase
{
    [HttpGet]
    [Route("getClient/{clientID}")]
    public object getClientPurchase(int clientID)
    {
        return new
        {
            id = clientID
        };
    }
    public void getStorePurchase(int storeID)
    {
        
    }
    public void makePurchase(PurchaseDTO purchase)
    {
        
    }
}