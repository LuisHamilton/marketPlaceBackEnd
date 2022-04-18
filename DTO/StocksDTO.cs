namespace DTO;
public class StocksDTO
{
    //Atributos
    public int quantity;
    public Double unit_price;
    public StoreDTO store; //Dependência
    public ProductDTO product; //Dependência
}