namespace DTO;
public class WishListDTO
{
    //Atributo
    public List<ProductDTO> products = new List<ProductDTO>();  //Dependencia
    public ClientDTO client; //Dependência
}