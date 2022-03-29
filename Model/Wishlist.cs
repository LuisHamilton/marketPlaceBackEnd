namespace Model;
public class Wishlist
{
    //Atributo
    private List<Product> products = new List<Product>();  
    private Client client; //Dependência

    //Construtor
    public Wishlist(Client client)
    {
        this.client = client;
    }
    //Métodos
    public List<Product> getProducts(){return products;}
    public void addProductToWishList(Product product){ products.Add(product); }
    public Client getClient(){return client;}
    public void SetClient(Client client){this.client=client;}
}