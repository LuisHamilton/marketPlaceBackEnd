using Microsoft.AspNetCore.Mvc;
using DTO;
using Model;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class StockController : ControllerBase
{
    [HttpPost]
    [Route("addProduct")]
    public object addProductToStock([FromBody] StocksDTO stock)
    {
        var stockModel = Model.Stocks.convertDTOToModel(stock);

        var prod = stockModel.getProduct();
        var loja = stockModel.getStore();

        var productID = prod.findId();
        var storeID = loja.findId();

        var id = stockModel.save(storeID, productID, stockModel.getQuantity(), stockModel.getUnitPrice());

        return new
        {
            quantidade = stock.quantity,
            preco_unidade = stock.unit_price,
            loja = stock.store,
            produto = stock.product,
            id = id
        };
    }
    public void updateStock(object request)
    {
        
    }
}