using Microsoft.AspNetCore.Mvc;
using DTO;
using Model;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class WishListController : ControllerBase
{
    [HttpPost]
    [Route("addProduct")]
    public object addProductToWishList([FromBody] WishListDTO wishlist)
    {
        var wishlistModel = Model.WishList.convertDTOToModel(wishlist);

        foreach(var prods in wishlistModel.getProducts())
        {
            var client = wishlistModel.getClient();
            var prod = prods.findId();
            var id = wishlistModel.save(client.getDocument(), prod);
        }

        return new
        {
            documento = wishlist.client.document,
            produtos = wishlist.products
        };
    }
    public void removeProductToWishList(object request)
    {
        
    }
}