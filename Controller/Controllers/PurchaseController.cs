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
    [Route("get/client/{document}")]
    public object getClientPurchase(String document)
    {
        return Model.Purchase.findByDocument(document);
    }
    [HttpGet]
    [Route("get/store/{CNPJ}")]
    public object getStorePurchase(String CNPJ)
    {
        return Model.Purchase.findByCNPJ(CNPJ);
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