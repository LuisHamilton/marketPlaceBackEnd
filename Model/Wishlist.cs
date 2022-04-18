namespace Model;
using Interfaces;
public class WishList : IValidateDataObject
{
    //Atributo
    private List<Product> products = new List<Product>();  
    private Client client; //Dependência

    //Construtor
    public WishList(Client client)
    {
        this.client = client;
    }
    //Métodos
    public List<Product> getProducts(){return products;}
    public void addProductToWishList(Product product){ products.Add(product); }
    public Client getClient(){return client;}
    public void SetClient(Client client){this.client=client;}

    public Boolean validateObject()
    {
        if (this.getProducts() == null) { return false; }
        if (this.getClient() == null) { return false; }
        return true;
    }
}