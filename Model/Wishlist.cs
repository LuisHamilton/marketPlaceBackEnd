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
    public int save(String document, int productID)
    {
        var id = 0;

        using(var context = new DaoContext())
        {
            var clientDAO = context.Client.FirstOrDefault(c => c.document == document);
            var productDAO = context.Product.Where(p => p.id == productID).Single();

            var wishlistDAO = new DAO.WishList
            {
                client = clientDAO,
                products = productDAO
            };
            context.WishList.Add(wishlistDAO);
            context.Entry(wishlistDAO.client).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
            context.Entry(wishlistDAO.products).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
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

    public static String removeProductFromWishList(String Bar_Code)
    {
        using(var context = new DaoContext())
        {
            var productDao = context.Product.Where(p=>p.bar_code == Bar_Code).Single();
            var wishlistDao = context.WishList.Include(w=>w.products).Where(w=>w.products.id == productDao.id);
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

    //GETs e SETs
    public List<Product> getProducts(){return products;}
    public void addProductToWishList(Product product){ products.Add(product); }
    public Client getClient(){return client;}
    public void SetClient(Client client){this.client=client;}

}