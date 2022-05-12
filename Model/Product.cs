using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Interfaces;
using DAO;
using DTO;

namespace Model;
public class Product : IValidateDataObject, IDataController<ProductDTO, Product>
{
    private String name;
    private String bar_code;
    public List<ProductDTO> productDTO = new List<ProductDTO>();
    
    //Métodos
    public static Product convertDTOToModel(ProductDTO obj)
    {
        var product = new Product();
        product.setName(obj.name);
        product.setBarCode(obj.bar_code);
        return product;
    }
    public Boolean validateObject()
    {
        if(this.getName() == null) { return false; }
        if(this.getBarCode() == null) { return false; }
        return true;
    }
    public void delete(ProductDTO obj){}
    public int save()
    {
        var id = 0;

        using(var context = new DaoContext())
        {
            var productDAO = new DAO.Product{
                name = this.name,
                bar_code = this.bar_code
            };
            context.Product.Add(productDAO);
            context.SaveChanges();
            id = productDAO.id;
        }
        return id;
    }
    public void update(ProductDTO obj){}

    public void updateProduct(String Bar_code){
        using (var context = new DaoContext()){
            var product = context.Product.Where(p=>p.bar_code == Bar_code).Single();
            product.name=this.name;
            product.bar_code=this.bar_code;
            context.SaveChanges();
        }
        

    }
    public ProductDTO findById(int id)
    {
        return new ProductDTO();
    }

    public static String deleteProduct(String Bar_Code)
    {
        using(var context = new DaoContext())
        {
            var productDao = context.Product.Where(p=>p.bar_code == Bar_Code).Single();
            var wishlistDao = context.WishList.Include(w=>w.products).Where(w=>w.products.id == productDao.id);
            var purchaseDao = context.Purchase.Include(p=>p.products).Where(p=>p.products.id == productDao.id);
            context.WishList.RemoveRange(wishlistDao);
            context.Purchase.RemoveRange(purchaseDao);
            context.Product.Remove(productDao);
            context.SaveChanges();
            return "Product removed successfuly";
        }
    }

    public int findId(){
        using(var context = new DaoContext())
        {
            var productDAO = context.Product.Where(c => c.bar_code == this.bar_code).Single();
            return productDAO.id;
        }
    }
    public List<ProductDTO> getAll()
    {
        return this.productDTO;
    }
    public ProductDTO convertModelToDTO()
    {
        var productDTO = new ProductDTO();
        productDTO.name = this.name;
        productDTO.bar_code = this.bar_code;
        return productDTO;
    }

    //GETs e SETs
    public String getName(){return name;}
    public void setName(String name){this.name=name;}
    public String getBarCode(){return bar_code;}
    public void setBarCode(String bar_code){this.bar_code=bar_code;}


}
