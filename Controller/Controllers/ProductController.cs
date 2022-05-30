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
        Console.WriteLine(productID);
        Console.WriteLine(storeID);
        var response = Model.Product.getInformation(productID, storeID);
        var result = new ObjectResult(response);

        Response.Headers.Add("Access-Control-Allow-Origin", "*");

        return result;
    }

    [HttpPost]
    [Route("create")]
    public object createProduct([FromBody]ProductDTO product)
    {
        var productModel = Model.Product.convertDTOToModel(product);
        var id = productModel.save();
        return new
        {
            nome = product.name,
            codigoDeBarras=product.bar_code,
            imagem = product.image,
            descricao = product.description,
            id = id
        };   
    }
    [HttpDelete]
    [Route("delete/{bar_code}")]
    public String deleteProduct(String bar_code)
    {
        return Model.Product.deleteProduct(bar_code);
    }
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