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