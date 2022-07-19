using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Interfaces;
using DAO;
using DTO;

namespace Model;
public class WishList : IValidateDataObject, IDataController<WishListDTO, WishList>
{
    //Atributo
    private List<Product> products = new List<Product>();  
    private List<Stocks> stocks = new List<Stocks>();  
    private Client client; //Dependência
    public List<WishListDTO> wishlistDTO = new List<WishListDTO>();

    //Construtor
    public WishList(){}
    private WishList(Client client)
    {
        this.client = client;
    }

    //Métodos
    public static WishList convertDTOToModel(WishListDTO obj)
    {
        var wishlist = new WishList(Client.convertDTOToModel(obj.client));

        foreach (var prod in obj.products)
        {
            wishlist.addProductToWishList(Product.convertDTOToModel(prod));
        }
        return wishlist;
    }
    public void delete(WishListDTO obj){}
    public static int save(int clientID, int productID, int stocksID)
    {
        var id = 0;

        using(var context = new DaoContext())
        {
            var clientDAO = context.Client.FirstOrDefault(c => c.id == clientID);
            var productDAO = context.Product.Where(p => p.id == productID).Single();
            var stocksDAO = context.Stocks.FirstOrDefault(s => s.id == stocksID);
            var wishlistDAO = new DAO.WishList
            {
                client = clientDAO,
                products = productDAO,
                stocks = stocksDAO
            };
            context.WishList.Add(wishlistDAO);
            context.Entry(wishlistDAO.client).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
            context.Entry(wishlistDAO.products).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
            context.Entry(wishlistDAO.stocks).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
            context.SaveChanges();
            id = wishlistDAO.id;
        }
        return id;
    }
    public void update(WishListDTO obj){}
    public WishListDTO findById(int id)
    {
        return new WishListDTO();
    }

    public static String removeProductFromWishList(int idStock, int idClient)
    {
        using(var context = new DaoContext())
        {
            var wishlistDao = context.WishList.Include(w=>w.stocks).Include(c => c.client).Where(w => w.stocks.id == idStock && w.client.id == idClient);

            context.WishList.RemoveRange(wishlistDao);

            context.SaveChanges();
            return "Product removed from WishList successfuly";
        }
    }

    public List<WishListDTO> getAll()
    {
        return this.wishlistDTO;
    }

    public Boolean validateObject()
    {
        if (this.getProducts() == null) { return false; }
        if (this.getClient() == null) { return false; }
        return true;
    }

    public WishListDTO convertModelToDTO()
    {
        var wishlistDTO = new WishListDTO();

        wishlistDTO.client = this.client.convertModelToDTO();
        foreach(var element in products)
        {
            wishlistDTO.products.Add(element.convertModelToDTO());
        }
        return wishlistDTO;
    }
    public static List<object> find(int clientID){
        using(var context = new DaoContext()){
            var stocks = context.Stocks;
            var wishlist = context.WishList
                    .Include(c => c.client)
                    .Include(st=>st.stocks.store)
                    .Where(c => c.client.id == clientID)
                    .Join(stocks, w => w.stocks.id, s => s.id, (w,s) => new {
                productId = w.products.id,
                productName = w.products.name,
                productPrice = s.unit_price,
                productImg = w.products.image,
                storeId = w.stocks.store.id,
                productStore = w.stocks.store.name,
                stocksId = w.stocks.id
            }).ToList();

            List<object> dados = new List<object>();
            foreach (var wish in wishlist){
                dados.Add(wish);
            }
            return dados;
        }
    }
    public static object verifyWishExistance(int clientID, int stockID){
        using(var context = new DaoContext()){
            var stocks = context.Stocks;
            var wishlist = context.WishList
                    .Include(c => c.client)
                    .Include(st=>st.stocks.store)
                    .Where(w => w.client.id == clientID && w.stocks.id == stockID)
                    .Join(stocks, w => w.stocks.id, s => s.id, (w,s) => new {
                productId = w.products.id,
                productName = w.products.name,
                productPrice = s.unit_price,
                productImg = w.products.image,
                storeId = w.stocks.store.id,
                productStore = w.stocks.store.name
            }).FirstOrDefault();

            return wishlist;
        }
    }

    //GETs e SETs
    public List<Product> getProducts(){return products;}
    public void addProductToWishList(Product product){ products.Add(product); }
    public Client getClient(){return client;}
    public void SetClient(Client client){this.client=client;}
    public List<Stocks> getStocks(){return stocks;}
}