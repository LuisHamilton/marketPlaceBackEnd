using Microsoft.AspNetCore.Mvc;
using DTO;
using Model;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers;

[ApiController]
[Route("Product")]
public class ProductController : ControllerBase
{
    public void allProducts()
    {
        
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
            id = id
        };   
    }
    [HttpDelete]
    [Route("delete")]
    public void deleteProduct(ProductDTO product)
    {
        
    }
    [HttpPut]
    [Route("update")]
    public void updateProduct([FromBody] ProductDTO product)
    {
        
    }
}