using Microsoft.AspNetCore.Mvc;
using DTO;
using Model;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers;

[ApiController]
[Route("Stock")]
public class StockController : ControllerBase
{
    [HttpPost]
    [Route("register")]
    public IActionResult addProductToStock([FromBody] StocksDTO stock)
    {
        var OwnerID = UserToken.GetIdFromRequest(Request.Headers["Authorization"].ToString());
        var storeID = Model.Store.getIdByOwner(OwnerID);
        var storeDTO = Model.Store.getById(storeID);
        stock.store = storeDTO;
        var productID = Model.Product.getIdByBarCode(stock.product.bar_code);
        var stockModel = Model.Stocks.convertDTOToModel(stock);
        var id = stockModel.save(storeID, productID, stockModel.getQuantity(), stockModel.getUnitPrice());

        return Ok();
    }

    [HttpPut]
    [Route("update/{CNPJ}/{bar_code}")]
    public object updateStock(StocksDTO stock,String CNPJ, String bar_code) 
    {
        var stockModel = Model.Stocks.convertDTOToModel(stock);
        stockModel.updateStock(CNPJ,bar_code);
        return new
        {
            quantidade = stock.quantity,
            preco_unidade = stock.unit_price,
            loja = stock.store,
            produto = stock.product,
        };
    }

    [HttpGet]
    [Route("all")]
    public IActionResult allProducts()
    {
        var response = Stocks.getAllProducts();
        var result = new ObjectResult(response);

        Response.Headers.Add("Access-Control-Allow-Origin", "*");

        return result;
    }
    [HttpGet]
    [Route("ownerStock")]
    public IActionResult ownerProducts()
    {
        var OwnerID = UserToken.GetIdFromRequest(Request.Headers["Authorization"].ToString());
        var response = Stocks.getOwnerProducts(OwnerID);
        var result = new ObjectResult(response);

        Response.Headers.Add("Access-Control-Allow-Origin", "*");

        return result;
    }

    [HttpGet]
    [Route("{productID}/{storeID}")]
    public IActionResult getDetails(int productID, int storeID)
    {
        var response = Model.Stocks.getInformation(productID, storeID);
        var result = new ObjectResult(response);

        Response.Headers.Add("Access-Control-Allow-Origin", "*");

        return result;
    }
}