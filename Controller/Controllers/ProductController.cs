using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using DTO;
using Model;

namespace Controller.Controllers;

[ApiController]
[Route("Product")]
public class ProductController : ControllerBase
{
    [HttpGet]
    [Route("all")]
    public IActionResult allProducts()
    {
        var response = Product.getAllProducts();
        var result = new ObjectResult(response);

        Response.Headers.Add("Access-Control-Allow-Origin", "*");

        return result;
    }

    [HttpGet]
    [Route("{productID}/{storeID}")]
    public IActionResult getDetails(int productID, int storeID)
    {
        var response = Model.Product.getInformation(productID, storeID);
        var result = new ObjectResult(response);

        Response.Headers.Add("Access-Control-Allow-Origin", "*");

        return result;
    }
    [HttpGet]
    [Route("get/{id}")]
    public IActionResult getObject(int id){
        var response = Model.Product.getById(id);
        var result = new ObjectResult(response);

        Response.Headers.Add("Access-Control-Allow-Origin", "*");

        return result;
    }
    [HttpPost]
    [Route("register")]
    public IActionResult createProduct([FromBody]ProductDTO product)
    {
        var productModel = Model.Product.convertDTOToModel(product);
        var id = productModel.save();
        return new ObjectResult(id);
    }
    // [HttpDelete]
    // [Route("delete/{bar_code}")]
    // public String deleteProduct(String bar_code)
    // {
    //     return Model.Product.deleteProduct(bar_code);
    // }
    [HttpPut]
    [Route("update/{bar_code}")]
    public object updateProduct(ProductDTO product,String bar_code)
    {
        var productModel = Model.Product.convertDTOToModel(product);
        productModel.updateProduct(bar_code);
        return new
        {
            nome = product.name,
            codigoDeBarras=product.bar_code
        };
    }
}