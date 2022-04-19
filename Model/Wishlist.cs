using System;
using System.Collections.Generic;
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
    public WishList(Client client)
    {
        this.client = client;
    }

    public static WishList convertDTOToModel(WishListDTO obj)
    {
        var wishlist = new WishList(Client.convertDTOToModel(obj.client));

        foreach (var element in obj.products)
        {
            wishlist.addProductToWishList(Product.convertDTOToModel(element));
        }
        return wishlist;
    }
    public void delete(WishListDTO obj){}
    public int save()
    {
        var id = 0;

        using(var context = new DaoContext())
        {
            var clientDAO = context.Client.FirstOrDefault(c => c.id == 1);
            var productDAO = context.Product.Where(p => p.id == 1).Single();

            var wishlist = new DAO.WishList
            {
                client = clientDAO,
                products = productDAO
            };
            context.WishList.Add(wishlist);
            context.SaveChanges();
            id = wishlist.id;
        }
        return id;
    }
    public void update(WishListDTO obj){}
    public WishListDTO findById(int id)
    {
        return new WishListDTO();
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
    //Métodos
    public List<Product> getProducts(){return products;}
    public void addProductToWishList(Product product){ products.Add(product); }
    public Client getClient(){return client;}
    public void SetClient(Client client){this.client=client;}

}