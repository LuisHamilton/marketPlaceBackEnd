using DTO;
using Model;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers;

[ApiController]
[Route("Purchase")]
public class PurchaseController : ControllerBase
{
    [HttpPost]
    [Route("make/{productId}/{storeId}")]
    public IActionResult makePurchase([FromBody]PurchaseDTO purchase, int productId, int storeId)
    {
        var ClientId = UserToken.GetIdFromRequest(Request.Headers["Authorization"].ToString());
        var clientDTO = Model.Client.getById(ClientId);
        var productDTO = Model.Product.getById(productId);
        var storeDTO = Model.Store.getById(storeId);
        purchase.client = clientDTO;
        purchase.products.Add(productDTO);
        purchase.store = storeDTO;

        var purchaseModel = Model.Purchase.convertDTOToModel(purchase);
        var id = purchaseModel.save(ClientId, storeId, productId);
        return Ok();
    }

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