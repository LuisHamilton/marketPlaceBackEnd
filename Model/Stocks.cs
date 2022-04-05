namespace Model;
using Interfaces;
public class Stocks : IValidateDataObject<Stocks>
{
    //Atributos
    private int quantity;
    private Store store; //Dependência
    private Product product; //Dependência

    //Construtores
    public Stocks(Store store, Product product)
    {
        this.store = store;
        this.product = product;
    }

    //Métodos
    public Store getStore(){return store;}
    public void setStore(Store store){this.store=store;}
    public Product getProduct(){return product;}
    public void setProduct(Product product){this.product=product;}
    public int getQuantity(){return quantity;}
    public void setQuantity(int quantity){this.quantity=quantity;}

    public Boolean validateObject(Stocks obj)
    {
        if(obj.getQuantity==null){return false;}
        if (obj.getStore == null) { return false; }
        if (obj.getProduct == null) { return false; }
        return true;
    }  
}