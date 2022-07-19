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
    private String image;
    private String description;
    public List<ProductDTO> productDTO = new List<ProductDTO>();
    
    //Métodos
    public static Product convertDTOToModel(ProductDTO obj)
    {
        var product = new Product();
        product.setName(obj.name);
        product.setBarCode(obj.bar_code);
        product.setImage(obj.image);
        product.setDescription(obj.description);
        return product;
    }
    public Boolean validateObject()
    {
        if(this.getName() == null) { return false; }
        if(this.getBarCode() == null) { return false; }
        if(this.getImage() == null) { return false; }
        if(this.getDescription() == null) { return false; }
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
                bar_code = this.bar_code,
                image = this.image,
                description = this.description
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
            product.image=this.image;
            product.description=this.description;
            context.SaveChanges();
        }
        

    }
    public ProductDTO findById(int id)
    {
        return new ProductDTO();
    }
    public static ProductDTO getById(int Id)
    {
        using(var context = new DaoContext())
        {
            ProductDTO productDTO = new ProductDTO();
            var productDAO = context.Product.Where(p => p.id == Id).Single();
            productDTO.name = productDAO.name;
            productDTO.bar_code = productDAO.bar_code;
            productDTO.image = productDAO.image;
            productDTO.description = productDAO.description;
            return productDTO;
        }
    }
    public static int getIdByBarCode(String Bar_code){
        var id = 0;
        using(var context= new DaoContext()){
            var productDAO = context.Product.FirstOrDefault(p=>p.bar_code == Bar_code);
            id = productDAO.id;
        }
        return id;
    }

    // public static String deleteProduct(String Bar_Code)
    // {
    //     using(var context = new DaoContext())
    //     {
    //         var productDao = context.Product.Where(p=>p.bar_code == Bar_Code).Single();
    //         var wishlistDao = context.WishList.Include(w=>w.products).Where(w=>w.products.id == productDao.id);
    //         var purchaseDao = context.Purchase.Include(p=>p.products).Where(p=>p.products.id == productDao.id);
    //         context.WishList.RemoveRange(wishlistDao);
    //         context.Purchase.RemoveRange(purchaseDao);
    //         context.Product.Remove(productDao);
    //         context.SaveChanges();
    //         return "Product removed successfuly";
    //     }
    // }

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
    public static List<object> getAllProducts()
    {
        List<object> produtos = new List<object>();

        using (var context = new DaoContext())
        {
            var stocks = context.Stocks.Include(s => s.product).ToList();
            foreach (var stock in stocks)
            {
                produtos.Add(new
                {
                    id = stock.product.id,
                    name = stock.product.name,
                    bar_code = stock.product.bar_code,
                    image = stock.product.image,
                    description = stock.product.description,
                    price = stock.unit_price
                });
            }
        }
        return produtos;
    }
    public static object getInformation(int productID, int storeID)
    {
        using (var context = new DaoContext())
        {   
            try{
                var produto = context.Stocks.Include(s => s.store).Join(context.Product, s => s.product.bar_code, p => p.bar_code, (s, p) => new
                {
                    id = p.id,
                    storeid = s.store.id,
                    store = s.store.name,
                    name = p.name,
                    bar_code = p.bar_code,
                    description = p.description,
                    image = p.image,
                    price = s.unit_price,
                    quantity = s.quantity
                }).Where(x => x.id == productID && x.storeid == storeID).Single();

                return produto;

            }catch(Exception error){
                Console.Write(error);

            }
            
            return new{};
        }
    }
    public ProductDTO convertModelToDTO()
    {
        var productDTO = new ProductDTO();
        productDTO.name = this.name;
        productDTO.bar_code = this.bar_code;
        productDTO.image = this.image;
        productDTO.description = this.description;
        return productDTO;
    }

    //GETs e SETs
    public String getName(){return this.name;}
    public void setName(String name){this.name=name;}
    public String getBarCode(){return this.bar_code;}
    public void setBarCode(String bar_code){this.bar_code=bar_code;}
    public String getImage(){return this.image;}
    public void setImage(String image){this.image=image;}
    public String getDescription(){return this.description;}
    public void setDescription(String description){this.description=description;}

}
