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
    [Route("get")]
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
    [HttpPost]
    [Route("make")]
    public object makePurchase([FromBody]PurchaseDTO purchase)
    {
        var purchaseModel = Model.Purchase.convertDTOToModel(purchase);
        var id = purchaseModel.save();
        return new
        {
            data = purchase.data_purchase,
            tipopagamento=purchase.payment_type,
            status=purchase.purchase_status,
            valor=purchase.purchase_values,
            numeroConfirmacao=purchase.number_confirmation,
            numeroNF=purchase.number_nf,
            cliente=purchase.client,
            loja=purchase.store,
            produtos=purchase.products,
            id = id
        };   
        
    }
}