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
    [HttpPost]
    [Route("make")]
    public object makePurchase(PurchaseDTO purchase)
    {
        var purchaseModel = Model.Purchase.convertDTOToModel(purchase);
        var id = purchaseModel.save();
        return new
        {
            data = purchase.data_purchase,
            tipopagamento=purchase.bar_code,
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