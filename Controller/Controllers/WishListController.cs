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
    [Route("addProduct/{productID}/{stocksID}")]
    public object addProductToWishList( int productID, int stocksID)
    {
        var ClientID = UserToken.GetIdFromRequest(Request.Headers["Authorization"].ToString());

        var newID = WishList.save(ClientID, productID, stocksID);

        return new
        {
            id = newID
        };
    }
    [HttpDelete]
    [Route("delete/{idStock}")]
    public String removeProductFromWishList(int idStock)
    {
        var ClientID = UserToken.GetIdFromRequest(Request.Headers["Authorization"].ToString());
        var wishlist = Model.WishList.removeProductFromWishList(idStock, ClientID);
        Response.Headers.Add("Access-Control-Allow-Origin", "*");
        return wishlist;
    }
    [HttpGet]
    [Route("get")]
    public IActionResult getWishListById(){
        var ClientID = UserToken.GetIdFromRequest(Request.Headers["Authorization"].ToString());
        var wish = Model.WishList.find(ClientID);
        var result = new ObjectResult(wish);
        Response.Headers.Add("Access-Control-Allow-Origin", "*");
        return result;
    }
    [HttpGet]
    [Route("verify/{idStock}")]
    public IActionResult verifyWishExistance(int idStock){
        var ClientID = UserToken.GetIdFromRequest(Request.Headers["Authorization"].ToString());
        var wish = Model.WishList.verifyWishExistance(ClientID, idStock);
        Response.Headers.Add("Access-Control-Allow-Origin", "*");
        if (wish == null)
            return NotFound();
        return Ok();
    }
}