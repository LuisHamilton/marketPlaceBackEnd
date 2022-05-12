using Microsoft.AspNetCore.Mvc;
using DTO;
using Model;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers;

[ApiController]
[Route("WishList")]
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
            var productID = prods.findId();
            var id = wishlistModel.save(client.getDocument(), productID);
        }

        return new
        {
            documento = wishlist.client.document,
            produtos = wishlist.products
        };
    }
    [HttpDelete]
    [Route("delete/{bar_code}")]
    public String removeProductFromWishList(String bar_code)
    {
        return Model.WishList.removeProductFromWishList(bar_code);
    }
}