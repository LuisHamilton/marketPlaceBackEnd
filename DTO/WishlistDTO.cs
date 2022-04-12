namespace DTO;
public class WishListDTO
{
    //Atributo
    public List<ProductDTO> products = new List<ProductDTO>();  
    public ClientDTO client; //Dependência
}