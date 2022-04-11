namespace DAO;
using Interfaces;
public class WishList : IValidateDataObject<WishList>
{
    //Atributo
    private List<Product> products = new List<Product>();  
    private Client client; //Dependência
}