using DTO;
using Model;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers;

[ApiController]
[Route("Purchase")]
public class PurchaseController : ControllerBase
{
    // [HttpGet]
    // [Route("get/client/{document}")]
    // public object getClientPurchase(String document)
    // {
    //     return Model.Purchase.findByDocument(document);
    // }
    // [HttpGet]
    // [Route("get/store/{CNPJ}")]
    // public object getStorePurchase(String CNPJ)
    // {
    //     return Model.Purchase.findByCNPJ(CNPJ);
    // }
    // [HttpPost]
    // [Route("make")]
    // public IActionResult makePurchase([FromBody]PurchaseDTO purchase)
    // {
    //     var ClientId = UserToken.GetIdFromRequest(Request.Headers["Authorization"].ToString());
    //     // var purchaseModel = Model.Purchase.convertDTOToModel(purchase);
    //     // var id = purchaseModel.save(ClientId, purchase.products.id, purchase.store.id, purchase.data_purchase, purchase.payment_type,
    //     // purchase.purchase_status, purchase.number_confirmation, purchase.number_nf, purchase.purchase_values);
    //     // return Ok(id);
    // }

    [HttpGet]
    [Route("all")]
    public IActionResult allPurchases()
    {
        var ClientID = UserToken.GetIdFromRequest(Request.Headers["Authorization"].ToString());
        var response = Purchase.getAllPurchases(ClientID);
        var result = new ObjectResult(response);

        Response.Headers.Add("Access-Control-Allow-Origin", "*");

        return result;
    }
    [HttpGet]
    [Route("allsales")]
    public IActionResult allSales()
    {
        var OwnerID = UserToken.GetIdFromRequest(Request.Headers["Authorization"].ToString());
        var storeID = Store.getStoreId(OwnerID);
        var response = Purchase.getAllSales(storeID);
        var result = new ObjectResult(response);

        Response.Headers.Add("Access-Control-Allow-Origin", "*");

        return result;
    }

    [HttpGet]
    [Route("{productId}/{storeId}")]
    public IActionResult getPurchase(int productId, int storeId)
    {
        var ClientID = UserToken.GetIdFromRequest(Request.Headers["Authorization"].ToString());
        var response = Purchase.getPurchaseDetail(ClientID, productId, storeId);
        var result = new ObjectResult(response);

        Response.Headers.Add("Access-Control-Allow-Origin", "*");

        return result;
    }
}